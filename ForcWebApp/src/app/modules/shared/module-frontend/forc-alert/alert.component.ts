import { Component, Inject } from '@angular/core';
import { MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-alert',
    templateUrl: 'alert.component.html',
    standalone: true,
	imports: [MatDialogModule]
})
export class AlertComponent {
    constructor(@Inject(MAT_DIALOG_DATA) public message: string){
	}
}