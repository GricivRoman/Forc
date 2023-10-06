import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
	selector: 'app-daily-rate',
	templateUrl: 'dailyRate.component.html'
})
export class DailyRateComponent{
	form = new FormGroup({
		colories: new FormControl(''),
		proteins: new FormControl(''),
		fats: new FormControl(''),
		carbohydrates: new FormControl('')
	});
}