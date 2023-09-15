import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { TextControlComponent } from "./forc-text/textControl.component";
import { CommonModule } from "@angular/common";
import { EmailControlComponent } from "./forc-email/emailControlComponent";
import { NumberControlComponent } from "./forc-number/numberControlComponent";
import { CheckBoxControlComponent } from "./forc-checkbox/checkBoxControlComponent";
import { PasswordControlComponent } from "./forc-password/passwordControlComponent";

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
        NumberControlComponent,
        CheckBoxControlComponent
    ],
    exports: [
        TextControlComponent,
        PasswordControlComponent,
        EmailControlComponent,
        NumberControlComponent,
        CheckBoxControlComponent
    ],
    providers: [

    ]
})
export class ForcControlsModule {

}