import { Component, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-check-in-page',
    templateUrl: 'checkInPage.component.html'
})
export class CheckInPageComponent implements OnInit {
    checkInButtonDisabled = true;

    form = new FormGroup({
        name: new FormControl('', [Validators.required]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, Validators.minLength(7)])
    });

    constructor(protected router: Router,
        protected route: ActivatedRoute){

    }

    ngOnInit(): void {
        this.form.valueChanges.subscribe(() => {
            this.form.markAsTouched();
            this.checkInButtonDisabled = !this.form.valid;
        });
    }

    backToLogin(){
        this.router.navigate(['user/login']);
    }

    checkIn(){
        //send request to API
    }
}