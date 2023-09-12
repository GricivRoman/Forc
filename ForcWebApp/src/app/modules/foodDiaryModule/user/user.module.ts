import { NgModule } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { LoginPageComponent } from './loginPage/loginPage.component'
import { CheckInPageComponent } from './checkInPage/checkInPage.component'
import { UserRoutingModule } from './user-routing.module'
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        UserRoutingModule,
        CommonModule
    ],
    declarations: [
        LoginPageComponent,
        CheckInPageComponent
    ]
})
export class UserModule {

}