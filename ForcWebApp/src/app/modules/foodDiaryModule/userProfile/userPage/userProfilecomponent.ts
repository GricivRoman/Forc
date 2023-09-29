import { Component } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { AlertService } from '../../../shared/module-frontend/forc-alert/alert.service';
import { UserModel } from './user';
import { ReactiveFromComponent } from '../../../shared/reactive-form-component';
import { FormControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from '../../../shared/apiValidationErrorsResolving.service';
import { LocalStorageService } from 'src/app/modules/shared/local-storage/localStorage.service';
import { SelectServiceResolver } from 'src/app/modules/shared/select-services/selectServieResolver';
import { SelectService } from 'src/app/modules/shared/select-services/select.service';
import { ImplementedSelectServices } from 'src/app/modules/shared/select-services/implementedSelectServices';

@Component({
	selector: 'app-personal-account',
	templateUrl: 'userProfile.component.html'
})
export class UserProfileComponent extends ReactiveFromComponent<UserModel> {
	override form = new FormGroup({
		name: new FormControl(''),
		gender: new FormControl(''),
		birthDate: new FormControl(new Date()),
		sex: new FormControl(''),
		physicalActivity: new FormControl(''),
		height: new FormControl('')
	});

	sexSelectService: SelectService;

	constructor(
		protected override dataService: DataService<UserModel>,
		protected override alertService: AlertService,
		protected override errorResolvingService: ApiValidationErrorsResolvingService,
		private localStorageService: LocalStorageService,
		private selectServiceResolver: SelectServiceResolver
	){
		super(dataService, alertService, errorResolvingService);
		this.apiUrl = 'user';
		this.modelId = localStorageService.authInfo?.userId;

		this.sexSelectService = selectServiceResolver.resolve(ImplementedSelectServices.sexSelectService);
	}

	override save(){
		super.save();
		console.log(1);
	}
}