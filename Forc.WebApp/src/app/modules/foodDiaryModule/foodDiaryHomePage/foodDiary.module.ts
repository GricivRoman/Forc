import { NgModule } from '@angular/core';
import { FoodDiaryRoutingModule } from './foodDiary-routing.module';
import { FoodDiaryComponent } from './foodDiary.component';
import { ModalWindowService } from '../../shared/module-frontend/forc-popup/modelWindow.service';
import { UserProfileModule } from '../userProfile/userProfile.module';
import { DiaryMenuModule } from '../diaryMenu/diaryMenu.module';
import { DialogService } from '../../shared/module-frontend/forc-dialog/dialog.service';
import { AlertService } from '../../shared/module-frontend/forc-alert/alert.service';

@NgModule({
	imports: [
		FoodDiaryRoutingModule,
		UserProfileModule,
		DiaryMenuModule
	],
	declarations:[
		FoodDiaryComponent
	],
	providers: [
		ModalWindowService,
		DialogService,
		AlertService
	]
})
export class FoodDiaryModule {

}