import { SelectItem } from '../module-frontend/forc-select/select-single/select-item';
import { SelectService } from './select.service';
import { Observable, of } from 'rxjs';

export class EmptySelectService implements SelectService{
	public getItemList(): Observable<SelectItem[]> {
		return of([]);
	}

	getCurrentItem(): Observable<SelectItem | undefined> {
		return of();
	}
}