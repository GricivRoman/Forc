import { NgModule } from '@angular/core'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { LoginPageComponent } from './loginPage/loginPage.component'
import { CheckInPageComponent } from './checkInPage/checkInPage.component'
import { AccountRoutingModule } from './account-routing.module'
import { CommonModule } from '@angular/common';
import { AccountService } from './account.service'
import { HttpClientModule } from '@angular/common/http'

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        AccountRoutingModule,
        CommonModule,
        HttpClientModule
    ],
    declarations: [
        LoginPageComponent,
        CheckInPageComponent
    ],
    providers: [
        AccountService
    ]
})
export class AccountModule {

}