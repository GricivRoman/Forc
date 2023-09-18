import { Observable } from "rxjs";

export interface GridDataService {
    getGridData(): Observable<any[]>;
}