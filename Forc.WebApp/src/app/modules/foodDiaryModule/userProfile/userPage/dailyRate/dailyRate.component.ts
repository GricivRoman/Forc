import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
	selector: 'app-daily-rate',
	templateUrl: 'dailyRate.component.html'
})
export class DailyRateComponent{
	form = new FormGroup({
		colories: new FormControl<number>(0),
		proteins: new FormControl<number>(0),
		fats: new FormControl<number>(0),
		carbohydrates: new FormControl<number>(0)
	});
}