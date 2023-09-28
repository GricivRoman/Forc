import { NgModule } from '@angular/core';
import { SelectSingleComponent } from './select-single/select-single.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        MatInputModule,
        MatSelectModule,
        MatFormFieldModule
    ],
    declarations: [
        SelectSingleComponent
    ],
    exports: [
        SelectSingleComponent
    ],
    providers: [

    ]
})
export class SelectModule {

}