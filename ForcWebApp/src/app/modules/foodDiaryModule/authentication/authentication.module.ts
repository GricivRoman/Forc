import { NgModule } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { LoginPageComponent } from './loginPage/loginPage.component'
import { CheckInPageComponent } from './checkInPage/checkInPage.component'
import { AuthenticationRoutingModule } from './authentication-routing.module'
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './authentication.service'
import { HttpClientModule } from '@angular/common/http'

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        AuthenticationRoutingModule,
        CommonModule,
        HttpClientModule
    ],
    declarations: [
        LoginPageComponent,
        CheckInPageComponent
    ],
    providers: [
        AuthenticationService
    ]
})
export class AuthenticationModule {

}