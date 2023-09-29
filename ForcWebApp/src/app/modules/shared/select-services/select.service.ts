import { Observable } from 'rxjs';
import { SelectItem } from '../module-frontend/forc-select/select-single/select-item';

export interface SelectService {
    getItemList(): Observable<SelectItem[]>;
    getCurrentItem(key: any): Observable<SelectItem | undefined>;
}