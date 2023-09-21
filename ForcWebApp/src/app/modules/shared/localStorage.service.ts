import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs';

@Injectable({providedIn: 'root'})
export class LocalStorageService {
	$authInfo = new BehaviorSubject(this.authInfo);

	set authInfo(data) {
		this.$authInfo.next(data);
		const value = JSON.stringify(data);
		localStorage.setItem('auth_info', value);
	}

	get authInfo() {
		return JSON.parse(localStorage.getItem('auth_info') as string);
	}

	clearAuthInfo(){
		localStorage.removeItem('auth_info');
		this.$authInfo.next(null);
	}
}