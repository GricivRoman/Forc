import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PhysicalActivityService } from './physicalActivitySelect.service';
import { SelectService } from '../../module-frontend/forc-select/select.service';

@Component({
	selector: 'app-select-physical-activity',
	template: `
        <app-select-single
            [label]="label"
            [control]="control"
            [selectService]="selectService"
        ></app-select-single>
    `
})
export class PhysicalActivitySelectComponent {

	@Input()
		label:string = 'Label required';

	@Input()
		control: FormControl;

	public selectService: SelectService;

	constructor(public physicalActivityService: PhysicalActivityService){
		this.selectService = physicalActivityService;
	}
}