import { NgModule } from "@angular/core";
import { UserProfileComponent } from "./userProfilecomponent";
import { UserProfileRoutingModule } from "./userProfile-routing.module";

@NgModule({
    imports: [
        UserProfileRoutingModule
    ],
    declarations:[
        UserProfileComponent
    ]
})
export class UserProfileModule {

}