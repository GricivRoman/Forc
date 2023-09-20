import { NgModule } from "@angular/core";
import { FoodDiaryRoutingModule } from "./foodDiary-routing.module";
import { FoodDiaryComponent } from "./foodDiary.component";
import { PopupService } from "../../shared/module-frontend/forc-popup/popup.service";
import { UserProfileModule } from "../userProfile/userProfile.module";
import { DiaryMenuModule } from "../diaryMenu/diaryMenu.module";

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
        PopupService
    ]
})
export class FoodDiaryModule {

}