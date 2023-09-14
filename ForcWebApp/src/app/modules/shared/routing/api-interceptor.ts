import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import  config from '../../../../assets/configuration.json'
import { LocalStorageService } from "../localStorage.service";
const baseUrl = config.serverUrl;

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
    authToken: string;
    constructor(private localStorageService: LocalStorageService){
        this.localStorageService.$authInfo.subscribe((info)=>{
            if(info){
                this.authToken = info.token;
            }
        });
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const apiReq = req.clone({
            url: `${baseUrl}/${req.url}`,
            setHeaders: {
                'Content-Type' : 'application/json; charset=utf-8',
                'Accept'       : 'application/json',
                'Authorization': `Bearer ${this.authToken}`
            }
        });
        return next.handle(apiReq);
    }
}