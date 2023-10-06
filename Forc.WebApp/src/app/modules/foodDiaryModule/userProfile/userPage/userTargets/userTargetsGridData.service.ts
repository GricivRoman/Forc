import { GridDataService } from 'src/app/modules/shared/module-frontend/forc-grid/grid-data.service';
import { UserTarget } from './userTarget';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class UserTargetsGridDataService implements GridDataService<UserTarget> {
	getGridData(): Observable<UserTarget[]>{
		return of();
	}
}