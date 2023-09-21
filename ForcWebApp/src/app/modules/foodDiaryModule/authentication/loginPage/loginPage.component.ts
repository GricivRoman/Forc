import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { LoginModel } from '../loginModel';

@Component({
	selector: 'app-login-page',
	templateUrl: 'loginPage.component.html'
})
export class LoginPageComponent implements OnInit{
	model: LoginModel;
	loginButtonDisabled = true;

	form = new FormGroup({
		userName: new FormControl('', [Validators.required, Validators.minLength(3)]),
		password: new FormControl('', [Validators.required, Validators.minLength(7)])
	});

	constructor(protected router: Router,
        private route: ActivatedRoute,
        private service: AuthenticationService){
	}

	ngOnInit(): void {
		this.form.valueChanges.subscribe(() => {
			this.form.markAsTouched();
			this.loginButtonDisabled = !this.form.valid;
		});
	}

	login(){
		if(this.form.valid){
			this.model = this.form.value as LoginModel;
			this.service.login(this.model);
		}
	}

	checkIn(){
		this.router.navigate(['user/checkin'], { queryParams : {
			returnUrl: this.route.snapshot.queryParams['returnUrl']
		}});
	}
}