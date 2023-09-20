import { Component } from '@angular/core';
import { PopupService } from '../../shared/module-frontend/forc-popup/popup.service';
import { UserProfileComponent } from '../userProfile/userProfilecomponent';

@Component({
    selector: 'app-food-diary',
    templateUrl: 'foodDiary.component.html'
})
export class FoodDiaryComponent {
    constructor(private popupService: PopupService){
    }
    
    click(){
        this.popupService.openWithTwoButtons(
            UserProfileComponent,
            'CustomTitle',
            undefined,
            true,
            (ref, popupRef) => {
            },
            (ref, popupRef) => {
                console.log('save');
                console.log(ref);
            },
            (ref, popupRef) => {
                console.log('close');
                popupRef.close();
            }
        );
    }
}