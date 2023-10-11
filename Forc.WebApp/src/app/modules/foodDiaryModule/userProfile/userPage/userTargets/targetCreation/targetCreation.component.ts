import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserTarget } from '../userTarget';
import { ReactiveFromComponent } from 'src/app/modules/shared/base-components/reactiveForm.component';
import { DataService } from 'src/app/modules/shared/services/data.service';
import { AlertService } from 'src/app/modules/shared/module-frontend/forc-alert/alert.service';
import { ApiValidationErrorsResolvingService } from 'src/app/modules/shared/services/apiValidationErrorsResolving.service';
import { ForcValidators } from 'src/app/modules/shared/validation/forcValidators';
import { takeUntil } from 'rxjs';

@Component({
	selector: 'app-target-weight',
	templateUrl: 'targetCreation.component.html',
	providers: [{provide: 'DataService', useClass: DataService}, AlertService, ApiValidationErrorsResolvingService]
})
export class TargetCreationComponent extends ReactiveFromComponent<UserTarget> implements OnInit{
	constructor(
		@Inject('DataService') protected override dataService: DataService<UserTarget>,
		protected override alertService: AlertService,
		protected override errorResolvingService: ApiValidationErrorsResolvingService)
	{
		super(dataService, alertService, errorResolvingService);
		this.createEmptyModel = () => new UserTarget();
	}

	override form = new FormGroup({
		dateStart: new FormControl<Date>(new Date()),
		dateFinish: new FormControl<Date>(new Date(), ForcValidators.laterThan(new Date())),
		currentBodyWeight: new FormControl<number>(0, ForcValidators.greaterThan(0)),
		targetBodyWeight: new FormControl<number>(0, ForcValidators.greaterThan(0))
	});

	override ngOnInit(): void {
		super.ngOnInit();

		this.form.controls.dateStart.valueChanges.pipe(takeUntil(this.destroy$)).subscribe((dateStart) => this.dateStartChanges(dateStart));
	}

	dateStartChanges(dateStart: Date | null){
		if(dateStart){
			this.form.controls.dateFinish.clearValidators();
			this.form.controls.dateFinish.setValidators([ForcValidators.laterThan(new Date(dateStart))]);
		} else {
			this.form.controls.dateFinish.setValidators(ForcValidators.laterThan(new Date()));
		}
		this.form.controls.dateFinish.updateValueAndValidity();
	}
}