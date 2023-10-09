import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserTarget } from '../userTarget';
import { ReactiveFromComponent } from 'src/app/modules/shared/base-components/reactiveForm.component';
import { DataService } from 'src/app/modules/shared/services/data.service';
import { AlertService } from 'src/app/modules/shared/module-frontend/forc-alert/alert.service';
import { ApiValidationErrorsResolvingService } from 'src/app/modules/shared/services/apiValidationErrorsResolving.service';

@Component({
	selector: 'app-target-weight',
	templateUrl: 'targetCreation.component.html',
	providers: [{provide: 'DataService', useClass: DataService}, AlertService, ApiValidationErrorsResolvingService]
})
export class TargetCreationComponent extends ReactiveFromComponent<UserTarget> {
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
		dateFinish: new FormControl<Date>(new Date()),
		currentBodyWeight: new FormControl<number>(0),
		targetBodyWeight: new FormControl<number>(0)
	});
}