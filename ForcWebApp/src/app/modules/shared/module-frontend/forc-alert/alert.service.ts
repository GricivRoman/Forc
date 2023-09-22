import { Injectable } from "@angular/core";
import { NgDialogAnimationService } from 'ng-dialog-animation';
import { AlertComponent } from "./alert.component";

@Injectable()
export class AlertService {
    constructor(private dialog: NgDialogAnimationService){
	}

	showMessage(message: string) {
        const showedDialogsCount = document.getElementsByClassName('alertDialog').length;

        const dialogRef = this.dialog.open(AlertComponent, {
			data: message,
			hasBackdrop: false,
			ariaModal: true,
			panelClass: 'alertDialog',
			animation: {
				outgoingOptions: {
				  keyframes: [
					{ opacity: 1 },
                    { opacity: 0.5 },
					{ opacity: 0 },
				  ],
				  keyframeAnimationOptions: { id: `${showedDialogsCount+1}`, duration: 2000 },
				}
			},
            position: {
                right: '1rem',
                top: `${5*(showedDialogsCount+1)}rem`
            }
		});

        dialogRef.afterOpened().subscribe(() => {
            setTimeout(() => {
                dialogRef.close();
            }, 3000);
        })
	}
}