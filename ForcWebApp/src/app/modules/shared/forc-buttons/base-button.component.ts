import { Component, Input } from "@angular/core";
import { IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-base-btn',
    template: ''
})
export abstract class BaseButtonComponent {
    @Input()
    disabled: boolean;

    abstract icon: IconDefinition;
}