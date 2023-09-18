import { Component } from "@angular/core";
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { BaseButtonComponent } from "../base-button.component";

@Component({
    selector: 'app-delete-btn',
    template: '<button class="btn btn-danger"><fa-icon [icon]="icon"></fa-icon></button>'
})
export class DeleteButtonComponent extends BaseButtonComponent {
    icon = faTrash;
}