import { Observable } from 'rxjs';
import { SelectItem } from '../selectItem';

export interface SelectService {
    getItemList(): Observable<SelectItem[]>;
}