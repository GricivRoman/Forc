import { Observable, of } from 'rxjs';
import { SelectItem } from '../../selectItem';
import { SelectService } from '../select.service';
import { SexEnum, SexEnumDictionary } from '../../enums/sexEnum';

export class SexSelectService implements SelectService {
	items: SelectItem[] = [
		{
			id: SexEnum.male,
			value: SexEnumDictionary.list.get(SexEnum.male) as string
		},
		{
			id: SexEnum.female,
			value: SexEnumDictionary.list.get(SexEnum.female) as string
		}
	];

	public getItemList(): Observable<SelectItem[]> {
		return of(this.items);
	}
}