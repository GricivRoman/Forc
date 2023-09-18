import { Component } from "@angular/core";
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { BaseButtonComponent } from "../base-button.component";

@Component({
    selector: 'app-add-btn',
    template: '<button class="btn btn-success"><fa-icon [icon]="icon"></fa-icon></button>'
})
export class AddButtonComponent extends BaseButtonComponent {
    icon = faPlus;
}