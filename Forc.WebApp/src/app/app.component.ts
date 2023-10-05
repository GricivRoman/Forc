import { Component } from '@angular/core';
import { faCarrot } from '@fortawesome/free-solid-svg-icons';
import { LocalStorageService } from './modules/shared/local-storage/localStorage.service';
import { Router } from '@angular/router';
import { AuthResponse } from './modules/shared/local-storage/auth-response';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html'
})
export class AppComponent {
	authorized: boolean;
	profileMask = 'Unauthorized';

	constructor(private localStorageService: LocalStorageService,
    private router: Router) {
		localStorageService.$authInfo.subscribe((info: AuthResponse | null) => {
			this.authorized = info != null;
			this.profileMask = info != null ? info.userName : 'Unauthorized';
		});
	}

	logout(){
		this.localStorageService.clearAuthInfo();
		this.router.navigate(['']);
	}

	login(){
		this.router.navigate(['user/login'], {queryParams: {
			returnUrl: this.router.url
		}});
	}

	protected title = 'ForcWebApp';
	protected carrotIcon = faCarrot;
}
