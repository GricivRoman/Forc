import { Component,ComponentRef } from '@angular/core';
import { UserTargetGridOptionsService } from './userTargetsGridOptions.service';
import { UserTargetsGridDataService } from './userTargetsGridData.service';
import { ModalWindowService } from 'src/app/modules/shared/module-frontend/forc-popup/modelWindow.service';
import { TargetCreationComponent } from './targetCreation/targetCreation.component';

@Component({
	selector: 'app-user-targets',
	templateUrl: 'userTargets.component.html',
	providers: [UserTargetGridOptionsService, UserTargetsGridDataService]
})
export class UserTargetsComponent {
	public addButtonDisabled: boolean = false;
	public editButtonDisabled: boolean = false;
	public deleteButtonDisabled: boolean = false;

	constructor(
        public gridOptionService: UserTargetGridOptionsService,
        public gridDataService: UserTargetsGridDataService,
        private modalService: ModalWindowService)
	{
	}

	add(){
		this.modalService.openWithTwoButtons(
			TargetCreationComponent,
			'Set your target',
			'sm',
			true,
			() => {

			},
			(componentRef: ComponentRef<TargetCreationComponent>) => {
				console.log(componentRef.instance.form);
				//Запрос на сэйв цели и расчета дневной нормы
			},
			(componentRef, popupRef) => {
				popupRef.close();
			}
		);
	}

	edit(){

	}

	delete(){

	}

}