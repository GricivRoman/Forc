import { Observable } from 'rxjs';
import { BaseEntity } from '../../baseEntity';

export interface GridDataService<TClass extends BaseEntity> {
    getGridData(): Observable<TClass[]>;
}