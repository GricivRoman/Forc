import { Component, ComponentRef, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { UserTargetGridOptionsService } from './userTargetsGridOptions.service';
import { UserTargetsGridDataService } from './userTargetsGridData.service';
import { ModalWindowService } from 'src/app/modules/shared/module-frontend/forc-popup/modelWindow.service';
import { TargetCreationComponent } from './targetCreation/targetCreation.component';
import { Guid } from 'guid-typescript';
import { GridComponent } from 'src/app/modules/shared/module-frontend/forc-grid/grid.component';
import { UserTarget } from './userTarget';
import { DataService } from 'src/app/modules/shared/services/data.service';
import { AlertService } from 'src/app/modules/shared/module-frontend/forc-alert/alert.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertDialogStates } from 'src/app/modules/shared/module-frontend/forc-alert/alertDialogStates';

@Component({
	selector: 'app-user-targets',
	templateUrl: 'userTargets.component.html',
	providers: [UserTargetGridOptionsService, UserTargetsGridDataService, {provide: 'DataService', useClass: DataService}]
})

// TODO вынести работу с гридом в отдельный базовый класс
export class UserTargetsComponent {
	@ViewChild(GridComponent, {static: false}) grid : GridComponent<UserTarget>;

	public addButtonDisabled: boolean = false;
	public editButtonDisabled: boolean = false;
	public deleteButtonDisabled: boolean = false;

	@Input()
	public userId?: Guid;

	@Output() userTargetsLoaded = new EventEmitter<UserTarget[]>;

	constructor(
        public gridOptionService: UserTargetGridOptionsService,
        public gridDataService: UserTargetsGridDataService,
        private modalService: ModalWindowService,
		private dataService: DataService<UserTarget>,
		private alertService: AlertService)
	{
		dataService.url = 'user-target';
	}

	add(){
		this.openDialogWindow((componentRef: ComponentRef<TargetCreationComponent>) => {
			if(this.userId){
				this.setApiUrl(componentRef);
				componentRef.instance.model.userId = this.userId;
			}
		});
	}

	edit(){
		this.openDialogWindow((componentRef: ComponentRef<TargetCreationComponent>) => {
			componentRef.instance.modelId = this.grid.getSelectedRowsKeys()[0];
			this.setApiUrl(componentRef);
			componentRef.instance.ngOnInit();
		});
	}

	delete(){
		this.dataService.delete(this.grid.getSelectedRowsKeys()[0]).subscribe({
			next: () => {
				this.grid.refresh();
			},
			error: (errResponse: HttpErrorResponse) => {
				console.error(errResponse);
				this.alertService.showMessage(JSON.stringify(errResponse.error), AlertDialogStates.error);
			}
		});
	}

	setApiUrl(componentRef: ComponentRef<TargetCreationComponent>){
		componentRef.instance.apiUrl = this.dataService.url;
		componentRef.instance.refreshDataServiceUrl();
	}

	onRowDoubleClick = () => {
		this.edit();
	};

	openDialogWindow(initAction: (componentRef: ComponentRef<TargetCreationComponent>) => void) {
		this.modalService.openWithTwoButtons(
			TargetCreationComponent,
			'Set your target',
			'sm',
			true,
			(componentRef: ComponentRef<TargetCreationComponent>) => {
				initAction(componentRef);
			},
			(componentRef: ComponentRef<TargetCreationComponent>, popupRef) => {
				componentRef.instance.save(() => {
					this.grid.refresh();
					popupRef.close();
				});
			},
			(componentRef, popupRef) => {
				popupRef.close();
			}
		);
	}

	gridDataLoaded(data: UserTarget[]){
		this.userTargetsLoaded.emit(data);
	}
}