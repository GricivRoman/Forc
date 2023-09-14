import { Directive, Input, OnInit } from "@angular/core";
import { FormControl, ValidationErrors } from "@angular/forms";

@Directive({
    selector: 'app-forc-text',
})
export class BaseControlComponent implements OnInit {
    public err: string;
    public shouldShowError: boolean;
    public controlIsOcupated: boolean;

    @Input()
    label:string;

    @Input()
    control: FormControl;

    mapErrorMessage(key: string): string{
        switch(key){
            case 'required':
                return `${this.label} field is required`
            case 'minlength':
                return `Required min length is ${this.control.getError('minlength').requiredLength} but you entered ${this.control.getError('minlength').actualLength}`
            case 'email':
                return `Field must contains an e-male type string`
            default:
                return ''
        };
    }

    ngOnInit(): void {
        this.control.valueChanges.subscribe(() => this.checkErrors());
    }

    checkErrors() {
        this.shouldShowError = this.control.invalid && !this.controlIsOcupated;

        if(this.shouldShowError) {
            this.showError();
        }
    }

    showError() {
        const errors: ValidationErrors = this.control.errors as ValidationErrors;
        this.err = this.mapErrorMessage(Object.keys(errors)[0]);
    }

    onControlFocus() {
        this.controlIsOcupated = true;
    }

    onContolBlur() {
        this.controlIsOcupated = false;
        this.checkErrors();
    }
}