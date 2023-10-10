import { Component, Inject, ViewChild } from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { AlertService } from '../../../shared/module-frontend/forc-alert/alert.service';
import { UserModel } from './user';
import { FormControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from '../../../shared/services/apiValidationErrorsResolving.service';
import { LocalStorageService } from 'src/app/modules/shared/local-storage/localStorage.service';
import { ReactiveFromWithPicture } from 'src/app/modules/shared/base-components/reactiveFromWithPictire';
import { UserTarget } from './userTargets/userTarget';
import { DailyRateComponent } from './dailyRate/dailyRate.component';

@Component({
	selector: 'app-personal-account',
	templateUrl: 'userProfile.component.html',
	providers: [{ provide: 'DataService', useClass: DataService } ]
})

export class UserProfileComponent extends ReactiveFromWithPicture<UserModel> {
	@ViewChild(DailyRateComponent, {static: false}) dailyRate: DailyRateComponent;

	override form = new FormGroup({
		name: new FormControl(''),
		gender: new FormControl(''),
		birthDate: new FormControl(new Date()),
		sex: new FormControl(''),
		physicalActivity: new FormControl(''),
		height: new FormControl(''),
		photo: new FormControl('')
	});

	constructor(
		@Inject('DataService') protected override dataService: DataService<UserModel>,
		protected override alertService: AlertService,
		protected override errorResolvingService: ApiValidationErrorsResolvingService,
		private localStorageService: LocalStorageService
	){
		super(dataService, alertService, errorResolvingService);
		this.apiUrl = 'user';
		this.modelId = localStorageService.authInfo?.userId;
	}

	userTargetsLoaded(data: UserTarget[]){
		const lastTargetDailyRate = data[0]?.dailyRate;

		this.dailyRate.form.patchValue({
			colories: lastTargetDailyRate?.caloriesRate ?? 0,
			carbohydrates: lastTargetDailyRate?.carbohydrateRate ?? 0,
			fats: lastTargetDailyRate?.fatRate ?? 0,
			proteins: lastTargetDailyRate?.proteinRate ?? 0
		});
	}
}