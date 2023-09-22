import { Component } from '@angular/core';
import { PopupService } from '../../shared/module-frontend/forc-popup/popup.service';
import { UserProfileComponent } from '../userProfile/userProfilecomponent';
import { DialogService } from '../../shared/module-frontend/forc-dialog/dialog.service';

@Component({
	selector: 'app-food-diary',
	templateUrl: 'foodDiary.component.html'
})
export class FoodDiaryComponent {
	constructor(private popupService: PopupService, private dialogService: DialogService){
	}

	click(){
		// this.popupService.openWithTwoButtons(
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

		this.dialogService.openYesNoDialog('Вы хорошо себя чувствуете?').subscribe((answer)=>{
			console.log(answer);
		});
	}
}