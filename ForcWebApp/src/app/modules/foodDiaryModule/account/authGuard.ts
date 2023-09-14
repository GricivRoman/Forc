import { Injectable, inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { AccountService } from "./account.service";

@Injectable()
export class AuthActivatorService{
    constructor(private authService: AccountService, private router: Router) {
    }

    CanActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean{
        if (this.authService.loginRequired) {
            this.router.navigate(["user/login"], { queryParams: {
                returnUrl: state.url
            }});

            return false;
        } else {
            return true;
        }
    }
}

export const AutGuard: CanActivateFn = (route, state) => {
    return inject(AuthActivatorService).CanActivate(route, state);
};