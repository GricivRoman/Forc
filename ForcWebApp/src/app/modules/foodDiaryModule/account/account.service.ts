import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { LoginModel } from "./loginModel";
import { CheckInModel } from "./checkInModel";
import { LocalStorageService } from "../../shared/localStorage.service";
import { ActivatedRoute, Router } from "@angular/router";

@Injectable()
export class AccountService {
    constructor(private http: HttpClient,
        private localStorageService: LocalStorageService,
        private router: Router,
        private route: ActivatedRoute){
    }

    get loginRequired(): boolean {
        return this.localStorageService.authInfo == null || new Date(this.localStorageService.authInfo.expiration) < new Date(Date.now());
    }

    login(model: LoginModel){
        this.http.post('account/login', model).subscribe({
            next : (response) => {
                this.localStorageService.authInfo = response;
                this.router.navigate([this.route.snapshot.queryParams['returnUrl']]);
            },
            error: (err) => {
                console.log(err);
            }
        });
    }

    checkIn(model: CheckInModel){
        this.http.post('account/checkin', model).subscribe({
            next : () => {
                const loginModel: LoginModel = {
                    userName: model.userName,
                    password: model.password
                }
                this.login(loginModel);
            },
            error: (err) => {
                console.log(err);
            }
        });
    }
}