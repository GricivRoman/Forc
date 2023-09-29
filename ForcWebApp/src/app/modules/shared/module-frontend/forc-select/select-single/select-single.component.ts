import { Component, Input, OnInit } from '@angular/core';
import { SelectItem } from './select-item';
import { FormControl } from '@angular/forms';
import { SelectService } from '../../../select-services/select.service';
import { first } from 'rxjs';

@Component({
	selector: 'app-select-single',
	templateUrl: 'select-single.component.html',
	styleUrls: ['select-single.component.css']
})
export class SelectSingleComponent implements OnInit {

	@Input()
		selectService: SelectService;

	@Input()
		label:string = 'Label required';

	@Input()
		control: FormControl;

	private emptyResult: SelectItem[] = [
		{
			key: undefined,
			value: '(empty)'
		}
	];

	selectList: any[] = [{key: undefined, value: 'loading..'}];

	ngOnInit(): void {
		this.control.valueChanges.pipe(first()).subscribe(() => {
			this.selectService.getCurrentItem(this.control.value).subscribe({
				next: (item: SelectItem | undefined) => {
					if(item){
						this.selectList = [item];
					}
				}
			});
		});
	}

	selectorOpened() {
		this.selectService.getItemList().subscribe({
			next: (items: SelectItem[]) => {
				if(items.length > 0){
					const itemsToPush = items.filter(x => !this.selectList.includes(x));
					this.selectList = this.selectList.concat(itemsToPush);
				} else {
					this.selectList = this.emptyResult;
				}
			}
		});
	}
}