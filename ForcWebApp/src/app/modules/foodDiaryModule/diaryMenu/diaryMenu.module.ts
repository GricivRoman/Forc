import { NgModule } from "@angular/core";
import { DiaryMenuComponent } from "./diaryMenu.component";
import { DiaryMenuRoutingModule } from "./diaryMenu-routing.module";

@NgModule({
    imports: [
        DiaryMenuRoutingModule
    ],
    declarations:[
        DiaryMenuComponent
    ]
})
export class DiaryMenuModule {

}