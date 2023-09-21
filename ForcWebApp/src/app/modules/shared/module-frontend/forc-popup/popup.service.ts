import { ComponentRef, Injectable } from '@angular/core';
import { ComponentType } from '@angular/cdk/portal';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { PopupComponent } from './popup.component';

@Injectable()
export class PopupService {
	constructor(private dialog: NgbModal){
	}
	private componentRef: ComponentRef<any>;

	public openWithCloseButton(
		component: ComponentType<any>,
		title: string = '',
		size: string = 'lg',
		centered: boolean = false,
		initAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {},
		closeAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {}
	){
		const modalComponent = this.openGeneric(component, title, size, centered, initAction, undefined, closeAction).componentInstance as PopupComponent;
		modalComponent.saveButtonVisible = false;
	}

	public openWithTwoButtons(
		component: ComponentType<any>,
		title: string = '',
		size: string = 'lg',
		centered: boolean = false,
		initAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {},
		saveAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {},
		closeAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {}
	){
		this.openGeneric(component, title, size, centered, initAction, saveAction, closeAction);
	}

	private openGeneric(
		component: ComponentType<any>,
		title: string = '',
		size: string = 'lg',
		centered: boolean = true,
		initAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {},
		saveAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {},
		closeAction: (componentRef: ComponentRef<any>, popupRef: NgbModalRef) => void = () => {}
	): NgbModalRef{
		PopupComponent.componentToWrap = component;
		const dialogRef = this.dialog.open(PopupComponent, {
			centered: centered,
			size: size,
			scrollable: true
		});

		const popupWindowInstance = dialogRef.componentInstance as PopupComponent;
		popupWindowInstance.title = title;

		dialogRef.shown.subscribe(() => {
			this.componentRef = dialogRef.componentInstance.inerRef._componentRef;

			popupWindowInstance.save = () => {
				saveAction(this.componentRef,dialogRef);
			};
			popupWindowInstance.close = () => {
				closeAction(this.componentRef,dialogRef);
			};

			initAction(this.componentRef,dialogRef);
		});

		return dialogRef;
	}
}