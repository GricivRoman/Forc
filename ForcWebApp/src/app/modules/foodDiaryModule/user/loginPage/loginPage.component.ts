import { Component, OnInit } from '@angular/core'
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Router } from '@angular/router';


@Component({
    selector: 'app-login-page',
    templateUrl: 'loginPage.component.html'
})
export class LoginPageComponent implements OnInit{

    loginButtonDisabled: boolean = true;

    form = new FormGroup({
        name: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required, Validators.minLength(7)])
    });

    constructor(protected router: Router){

    }

    ngOnInit(): void {
        this.form.valueChanges.subscribe(() => {
            this.form.markAsTouched();
            this.loginButtonDisabled = !this.form.valid;
        });
    }

    login(){
        //send request to API
    }

    checkIn(){
        this.router.navigate(['user/checkin']);
    }
}