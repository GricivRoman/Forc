import { NgModule } from "@angular/core";
import { DataInputComponent } from "./dataInput.component";
import { DataInputRoutingModule } from "./dataInput-routing.module";

@NgModule({
    imports: [
        DataInputRoutingModule
    ],
    declarations:[
        DataInputComponent
    ]   
})

export class DataInputModule {

}