import { Component, Inject, ViewChild } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { AlertService } from '../../../shared/module-frontend/forc-alert/alert.service';
import { UserModel } from './user';
import { ReactiveFromComponent } from '../../../shared/reactive-form-component';
import { FormControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from '../../../shared/apiValidationErrorsResolving.service';
import { LocalStorageService } from 'src/app/modules/shared/local-storage/localStorage.service';
import { ForcImageComponent } from 'src/app/modules/shared/module-frontend/forc-image/forcImage.component';

@Component({
	selector: 'app-personal-account',
	templateUrl: 'userProfile.component.html',
	providers: [{ provide: 'DataService', useClass: DataService } ]
})

// TODO в дальнейшем вынести функционал работы с картинкой в базовый комбонент ReactiveFromWithPictureComponent
export class UserProfileComponent extends ReactiveFromComponent<UserModel> {
	@ViewChild(ForcImageComponent, {static: false}) imageComponent: ForcImageComponent;

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

	override save() {
		super.save(this.imageComponent.Save);
	}
}