import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { CheckInModel } from '../checkInModel';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
	selector: 'app-check-in-page',
	templateUrl: 'checkInPage.component.html'
})
export class CheckInPageComponent implements OnInit {
	model: CheckInModel;
	checkInButtonDisabled = true;

	form = new FormGroup({
		userName: new FormControl('', [Validators.required, Validators.minLength(3)]),
		email: new FormControl('', [Validators.required, Validators.email]),
		password: new FormControl('', [Validators.required, Validators.minLength(7)])
	});

	constructor(protected router: Router,
        private route: ActivatedRoute,
        private service: AuthenticationService){
	}

	ngOnInit(): void {
		this.form.valueChanges.subscribe(() => {
			this.form.markAsTouched();
			this.checkInButtonDisabled = !this.form.valid;
		});
	}

	backToLogin(){
		this.router.navigate(['user/login'], { queryParams: {
			returlUrl: this.route.snapshot.queryParams['returlUrl']
		}});
	}

	checkIn(){
		if(this.form.valid){
			this.model = this.form.value as CheckInModel;
			this.service.checkIn(this.model).subscribe({
				error: (errResponse: HttpErrorResponse) => {
					Object.keys(this.form.controls).forEach(controlKey => {
						const errs = errResponse.error[`${controlKey[0].toUpperCase()}${controlKey.substring(1)}`];
						const currentControl = Object(this.form.controls)[controlKey] as FormControl;
						currentControl.setErrors(errs);
					});
				}
			});
		}
	}
}