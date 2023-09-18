import { NgModule } from "@angular/core";
import { DiaryMenuComponent, DiaryMenuGridOptionService } from "./diaryMenu.component";
import { DiaryMenuRoutingModule } from "./diaryMenu-routing.module";
import { GridModule } from "../../shared/grid/grid.module";
import { ForcButtonsModule } from "../../shared/forc-buttons/forc-buttons.module";

@NgModule({
    imports: [
        DiaryMenuRoutingModule,
        GridModule,
        ForcButtonsModule
    ],
    declarations:[
        DiaryMenuComponent
    ],
    providers: [
        DiaryMenuGridOptionService
    ]
})
export class DiaryMenuModule {

}