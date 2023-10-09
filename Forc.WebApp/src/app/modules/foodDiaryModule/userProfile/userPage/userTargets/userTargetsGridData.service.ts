import { GridDataService } from 'src/app/modules/shared/module-frontend/forc-grid/grid-data.service';
import { UserTarget } from './userTarget';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { DataService } from 'src/app/modules/shared/services/data.service';

@Injectable()
export class UserTargetsGridDataService implements GridDataService<UserTarget> {
	constructor(private dataService: DataService<UserTarget>){
		this.dataService.url = 'user-target';
	}

	getGridData(): Observable<UserTarget[]>{
		return this.dataService.getList();
	}
}