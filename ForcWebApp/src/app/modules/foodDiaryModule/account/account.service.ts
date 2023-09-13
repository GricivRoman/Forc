import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { LoginModel } from "./loginModel";
import { CheckInModel } from "./checkInModel";
import { ApiRoutingService } from "../../shared/routing/api-routing-service";

@Injectable()
export class AccountService {
    constructor(private http: HttpClient, private routingService: ApiRoutingService){
        routingService.routerPath = "account/";
    }

    login(model: LoginModel){
        this.http.post(this.routingService.getFullRouterPath('login'), model).subscribe({
            next : (token) => {
                console.log(token)
                //Поместить куда-то информацию о токене и времени жизни
                ///Как залогинился, получить юзера
            },
            error: (err) => {
                console.log(err);
            }
        });
    }

    checkIn(model: CheckInModel){
        this.http.post(this.routingService.getFullRouterPath('checkin'), model).subscribe({
            next : (response) => {
                console.log(response)
            },
            error: (err) => {
                console.log(err);
            }
        });
    }
}