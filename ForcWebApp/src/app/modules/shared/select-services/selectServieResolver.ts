import { Injectable } from '@angular/core';
import { SelectService } from './select.service';
import { ImplementedSelectServices } from './implementedSelectServices';
import { EmptySelectService } from './emptySelect.service';
import { SexSelectService } from './services/sexSelect.service';

@Injectable()
export class SelectServiceResolver {
	public resolve(implementedSelectServices: number) : SelectService {
		switch(implementedSelectServices){
		case ImplementedSelectServices.sexSelectService:
			return new SexSelectService;
		default:
			return new EmptySelectService;
		}
	}
}