import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { TextControlComponent } from "./forc-text/textControl.component";
import { CommonModule } from "@angular/common";
import { PasswordControlComponent } from "./forc-password/PasswordControlComponent";
import { EmailControlComponent } from "./forc-email/emailControlComponent";
import { NumberControlComponent } from "./forc-number/numberControlComponent";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [
        TextControlComponent,
        PasswordControlComponent,
        EmailControlComponent,
        NumberControlComponent
    ],
    exports: [
        TextControlComponent,
        PasswordControlComponent,
        EmailControlComponent,
        NumberControlComponent
    ],
    providers: [

    ]
})
export class ForcControlsModule {

}