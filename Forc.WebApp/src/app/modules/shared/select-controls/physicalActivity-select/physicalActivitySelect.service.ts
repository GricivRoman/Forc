import { Observable } from 'rxjs';
import { SelectItem } from '../../models/selectItem';
import { SelectService } from '../../module-frontend/forc-select/select.service';
import { DataService } from '../../services/data.service';
import { Injectable, Inject } from '@angular/core';

@Injectable()
export class PhysicalActivityService implements SelectService {

	constructor(@Inject('PA_DataService') private dataService: DataService<SelectItem>){
		dataService.url = 'physical-activity';
	}
	public getItemList(): Observable<SelectItem[]> {
		return this.dataService.getSelectItemList();
	}
}