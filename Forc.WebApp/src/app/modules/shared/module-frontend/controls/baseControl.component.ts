import { Component, Input, OnInit } from '@angular/core';
import { FormControl, ValidationErrors } from '@angular/forms';

@Component({
	selector: 'app-base-control',
	template: ''
})
export class BaseControlComponent implements OnInit {
	public err: string;
	public shouldShowError: boolean;
	public controlIsOcupated: boolean;

	@Input()
		label:string;

	@Input()
		control: FormControl;

	mapErrorMessage(err: ValidationErrors): string {
		const key = err[0];
		const errBody = err[1];
		switch(key){
		case 'required':
			return `${this.label} field is required`;
		case 'minlength':
			return `Required min length is ${errBody.requiredLength} but you entered ${errBody.actualLength}`;
		case 'email':
			return 'Field must contains an e-male type string';
		default:
			return errBody;
		}
	}

	ngOnInit(): void {
		this.control.valueChanges.subscribe(() => this.checkErrors());
		this.control.statusChanges.subscribe(() => this.checkErrors());
	}

	checkErrors() {
		this.shouldShowError = this.control.invalid && !this.controlIsOcupated;

		if(this.shouldShowError) {
			this.showError();
		}
	}

	showError() {
		const errors: ValidationErrors = this.control.errors as ValidationErrors;
		this.err = this.mapErrorMessage(Object.entries(errors)[0]);
	}

	onControlFocus() {
		this.controlIsOcupated = true;
	}

	onContolBlur() {
		this.controlIsOcupated = false;
		this.checkErrors();
	}
}