import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { AlertService } from '../../../shared/module-frontend/forc-alert/alert.service';
import { UserModel } from './user';
import { ReactiveFromComponent } from '../../../shared/reactive-form-component';
import { FormControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from '../../../shared/apiValidationErrorsResolving.service';
import { LocalStorageService } from 'src/app/modules/shared/local-storage/localStorage.service';
import { HttpClient } from '@angular/common/http';

@Component({
	selector: 'app-personal-account',
	templateUrl: 'userProfile.component.html',
	providers: [{provide: 'DataService', useClass: DataService} ]
})
export class UserProfileComponent extends ReactiveFromComponent<UserModel> implements AfterViewInit {
	public picture: string;
	
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
		private localStorageService: LocalStorageService,
		private http: HttpClient
	){
		super(dataService, alertService, errorResolvingService);
		this.apiUrl = 'user';
		this.modelId = localStorageService.authInfo?.userId;
	}

	// TODO вынести в момент, после инициализации формы
	ngAfterViewInit(): void {

		this.http.get(`${this.apiUrl}/photo/${this.modelId}`).subscribe({
			next: (data: any) => {
				this.picture = `data:image/jpg;base64,${data.file}`;
			}
		});
	}

	override save(){
		super.save();
	}

	// TODO фото загружаем отдельным обращением на сервер
	public photoChanges(event: any){
		const filesList = event.target.files;
		if(filesList){
			this.picture = window.URL.createObjectURL(filesList[0]);
		}
		console.log(filesList[0]);
		// TODO шлем запрос на сейв файла после основного запроса на сейв страницы, получаем ID и по нему сохраняем
		const formData = new FormData();
		if(this.model.id){
			formData.append('File', filesList[0], filesList[0].name);
			formData.append('Id', this.model.id.toString());	
			this.http.post(`${this.apiUrl}/photo`, formData).subscribe();
		}		
	}
}