import { NgModule } from "@angular/core";
import { DiaryMenuComponent, DiaryMenuGridOptionService } from "./diaryMenu.component";
import { DiaryMenuRoutingModule } from "./diaryMenu-routing.module";
import { GridModule } from "../../shared/grid/grid.module";

@NgModule({
    imports: [
        DiaryMenuRoutingModule,
        GridModule
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