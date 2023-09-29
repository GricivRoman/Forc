import { Observable, of } from 'rxjs';
import { SelectItem } from '../../module-frontend/forc-select/select-single/select-item';
import { SelectService } from '../select.service';

export class SexSelectService implements SelectService {
	items: SelectItem[] = [
		{
			key: 1,
			value: 'Male'
		},
		{
			key: 2,
			value: 'Female'
		}
	];

	public getItemList(): Observable<SelectItem[]> {
		return of(this.items);
	}

	getCurrentItem(key: any): Observable<SelectItem | undefined> {
		const item = this.items.find(x => x.key === key);
		return of(item);
	}
}