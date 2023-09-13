import { NgModule } from "@angular/core";
import { PersonalAccountComponent } from "./personalAccount.component";
import { PersonalAccountRoutingModule } from "./personalAccount-routing.module";

@NgModule({
    imports: [
        PersonalAccountRoutingModule
    ],
    declarations:[
        PersonalAccountComponent
    ]
})
export class PersonalAccountModule {

}