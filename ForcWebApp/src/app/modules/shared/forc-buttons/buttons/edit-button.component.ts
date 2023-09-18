import { Component } from "@angular/core";
import { faPen } from '@fortawesome/free-solid-svg-icons';
import { BaseButtonComponent } from "../base-button.component";

@Component({
    selector: 'app-edit-btn',
    template: '<button class="btn btn-warning"><fa-icon [icon]="icon"></fa-icon></button>'
})
export class EditButtonComponent extends BaseButtonComponent {
    icon = faPen;
}