import { Component, Input, Output, EventEmitter, OnInit, Inject } from '@angular/core';
import { Guid } from 'guid-typescript';
import { FileStorageService } from '../../fileStorage.service';

@Component({
	selector: 'app-forc-image',
	templateUrl: 'forcImage.component.html',
	styleUrls: ['forcImage.component.css'],
	providers: [{provide: 'FileStorage', useClass: FileStorageService}]
})
export class ForcImageComponent implements OnInit {
	public picture: string = 'assets/images/UploadPicture.jpg';
	public selectedFile: File;

	@Input()
		modelId?: Guid;

	@Input()
		apiUrl: string;

	@Output() fileChanged = new EventEmitter<File>;

	constructor(@Inject('FileStorage') private fileStorageService: FileStorageService){
	}

	ngOnInit(): void {
		this.fileStorageService.url = this.apiUrl;
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
			this.fileChanged.emit(this.selectedFile);
		}
	}

	public Save = (id: Guid) => {
		if(id){
			const formData = new FormData();
			formData.append('File', this.selectedFile, this.selectedFile.name);
			formData.append('Id', id.toString());
			this.fileStorageService.save(formData).subscribe();
		}
	};
}