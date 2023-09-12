import { NgModule } from "@angular/core";
import { FoodDiaryRoutingModule } from "../foodDiary-routing.module";
import { FoodDiaryComponent } from "./foodDiary.component";

@NgModule({
    imports: [
        FoodDiaryRoutingModule,
    ],
    declarations:[
        FoodDiaryComponent
    ]
})
export class FoodDiaryModule {

}