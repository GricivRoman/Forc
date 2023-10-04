import { Component, Inject, OnInit } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { AlertService } from '../../../shared/module-frontend/forc-alert/alert.service';
import { UserModel } from './user';
import { ReactiveFromComponent } from '../../../shared/reactive-form-component';
import { FormControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from '../../../shared/apiValidationErrorsResolving.service';
import { LocalStorageService } from 'src/app/modules/shared/local-storage/localStorage.service';
import { FileStorageService } from 'src/app/modules/shared/fileStorage.service';
import { Guid } from 'guid-typescript';

@Component({
	selector: 'app-personal-account',
	templateUrl: 'userProfile.component.html',
	styleUrls: ['userPage.component.css'],
	providers: [{provide: 'DataService', useClass: DataService} ]
})

// TODO в дальнейшем вынести функционал работы с картинкой в базовый комбонент ReactiveFromWithPictureComponent
export class UserProfileComponent extends ReactiveFromComponent<UserModel> implements OnInit {
	public picture: string = 'assets/images/UploadPicture.jpg';
	public selectedFile: File;

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
		protected override fileStorageService: FileStorageService,
		private localStorageService: LocalStorageService
	){
		super(dataService, alertService, errorResolvingService, fileStorageService);
		this.apiUrl = 'user';
		this.modelId = localStorageService.authInfo?.userId;
	}

	override ngOnInit(): void {
		super.ngOnInit();

		if(this.modelId){
			this.fileStorageService.get(this.modelId).subscribe({
				next: (data: any) => {
					this.picture = `data:image/jpg;base64,${data.file}`;
				}
			});
		}
	}

	public photoChanges(event: any){
		const filesList = event.target.files;
		if(filesList){
			this.picture = window.URL.createObjectURL(filesList[0]);
			this.selectedFile = filesList[0];
		}
	}

	override save(){
		super.save((id: Guid) => {
			if(id){
				const formData = new FormData();
				formData.append('File', this.selectedFile, this.selectedFile.name);
				formData.append('Id', id.toString());
				this.fileStorageService.save(formData).subscribe();
			}
		});
	}
}