import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
	selector: 'app-target-weight',
	templateUrl: 'targetCreation.component.html'
})
export class TargetCreationComponent {

	form = new FormGroup({
		dateStart: new FormControl(''),
		dateFinish: new FormControl(''),
		currentBodyWeight: new FormControl(''),
		targetBodyWeight: new FormControl('')
	});
}