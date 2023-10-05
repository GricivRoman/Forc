import { Component, ViewChild } from '@angular/core';
import { ReactiveFromComponent } from './reactiveForm.component';
import { ForcImageComponent } from './module-frontend/forc-image/forcImage.component';
import { EntityWithImage } from './entityWithImage';
import { Guid } from 'guid-typescript';

@Component({
	selector: 'app-reactive-form-component-with-picture',
	template: ''
})
export class ReactiveFromWithPicture<TEntity extends EntityWithImage> extends ReactiveFromComponent<TEntity> {
	@ViewChild(ForcImageComponent, {static: false}) imageComponent: ForcImageComponent;

	override setModel(id: Guid){
		super.setModel(id, () => this.imageComponent.setPicture(this.model));
	}

	override save() {
		super.save(this.imageComponent.Save);
	}
}