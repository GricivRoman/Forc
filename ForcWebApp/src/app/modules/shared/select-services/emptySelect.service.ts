import { SelectItem } from '../selectItem';
import { SelectService } from './select.service';
import { Observable, of } from 'rxjs';

export class EmptySelectService implements SelectService{
	public getItemList(): Observable<SelectItem[]> {
		return of([]);
	}
}