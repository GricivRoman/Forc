import { Component } from '@angular/core';
import { ModalWindowService } from '../../shared/module-frontend/forc-popup/modelWindow.service';
import { DialogService } from '../../shared/module-frontend/forc-dialog/dialog.service';
import { AlertService } from '../../shared/module-frontend/forc-alert/alert.service';
import { AlertDialogStates } from '../../shared/module-frontend/forc-alert/alertDialogStates';

@Component({
	selector: 'app-food-diary',
	templateUrl: 'foodDiary.component.html'
})
export class FoodDiaryComponent {
	constructor(private ModalWindowService: ModalWindowService, private dialogService: DialogService, private alertService: AlertService){
	}

	click(){
		// this.ModalWindowService.openWithTwoButtons(
		// 	UserProfileComponent,
		// 	'CustomTitle',
		// 	undefined,
		// 	true,
		// 	() => {
		// 	},
		// 	(ref) => {
		// 		console.log('save');
		// 		console.log(ref);
		// 	},
		// 	(ref, popupRef) => {
		// 		console.log('close');
		// 		popupRef.close();
		// 	}
		// );

		// this.dialogService.openYesNoDialog('Вы хорошо себя чувствуете?').subscribe((answer)=>{
		// 	console.log(answer);
		// });

		this.alertService.showMessage('Saved succesful', AlertDialogStates.error);
	}
}