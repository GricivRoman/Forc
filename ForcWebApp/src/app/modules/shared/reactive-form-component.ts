import { Component, OnInit, OnDestroy } from '@angular/core';
import { DataService } from './data.service';
import { BaseEntity } from './baseEntity';
import { AlertService } from './module-frontend/forc-alert/alert.service';
import { AbstractControl, FormGroup } from '@angular/forms';
import { ApiValidationErrorsResolvingService } from './apiValidationErrorsResolving.service';
import { Observer, takeUntil, Subject } from 'rxjs';
import { Guid } from 'guid-typescript';
import { AlertDialogStates } from './module-frontend/forc-alert/alertDialogStates';
import { DatePipe } from '@angular/common';

@Component({
	selector: 'app-reactive-form-component',
	template: ''
})
export class ReactiveFromComponent<TEntity extends BaseEntity> implements OnInit, OnDestroy{
	private readonly _destroy$ = new Subject<void>;
	public readonly destroy$ = this._destroy$.asObservable();

	public form: FormGroup;
	public model: TEntity;
	protected modelSource: TEntity;
	public apiUrl: string;
	public modelId?: Guid;

	public saveButtonDisabled: boolean;

	constructor(
        protected dataService: DataService<TEntity>,
        protected alertService: AlertService,
        protected errorResolvingService: ApiValidationErrorsResolvingService
	){
	}

	ngOnInit() {
		this.dataService.url = this.apiUrl;
		if(this.modelId){
			this.setModel(this.modelId);
		}

		this.form.valueChanges.pipe(takeUntil(this.destroy$)).subscribe(() => this.onFormValueChange());
	}

	onFormValueChange(){
		this.form.markAsTouched();

		// TODO реализовать метод Equals, для сравнения равенства значений всех полей
		// this.saveButtonDisabled = this.model === this.modelSource;
	}

	public setModel(id: Guid) {
		this.dataService.get(id).pipe(takeUntil(this.destroy$)).subscribe({
			next: (data: TEntity) => {
				this.model = data;
				this.modelSource = { ... this.model };
				this.initFrom(this.model);
			},
			error: (err) => {
				this.showError(err);
			}
		});
	}

	public save(saveAction?: () => void){
		if(!this.form?.valid){
			this.alertService.showMessage('The form invalid', AlertDialogStates.error);
		}
		this.updateModel();
		if(this.model?.id){
			this.dataService.update(this.model).pipe(takeUntil(this.destroy$)).subscribe(this.afterSaveOrUpdateAction(saveAction));
		} else {
			this.dataService.save(this.model).pipe(takeUntil(this.destroy$)).subscribe(this.afterSaveOrUpdateAction(saveAction));
		}
	}

	public delete(id: Guid){
		this.dataService.delete(id);
	}

	public initFrom(data: TEntity){
		Object.keys(this.form.controls).forEach((controlKey) => {
			(Object(this.form.controls[controlKey]) as AbstractControl).setValue(this.getValueToSetToForm(data, controlKey), {
				emitEvent: true
			});
		});
	}

	protected updateModel(){
		Object.keys(this.form.controls).forEach((controlKey) => {
			Object(this.model)[controlKey] = (Object(this.form.controls[controlKey]) as AbstractControl).value;
		});
	}

	ngOnDestroy(){
		this._destroy$.next();
		this._destroy$.complete();
	}

	private afterSaveOrUpdateAction(saveAction?: () => void): Partial<Observer<any>>{
		return {
			next: () => {
				this.alertService.showMessage('Saved successful', AlertDialogStates.success);
				if(saveAction){
					saveAction();
				}
			},
			error: (err) => {
				this.errorResolvingService.resolveApiValidationErrors(this.form, err);
				this.showError(err);
			}
		};
	}

	private showError(err: any){
		if(typeof err.error === 'string' ){
			this.alertService.showMessage(err.error, AlertDialogStates.error);
		}
	}

	private getValueToSetToForm(data: TEntity, controlKey: string): any{
		const fieldValue = Object(data)[controlKey];
		const date = new Date(fieldValue);
		
		return typeof fieldValue === 'string' && isFinite(+date) ? this.getDateString(date) : fieldValue;
	}

	private getDateString(date: Date): string {
		const datePipe: DatePipe = new DatePipe('en-US');
		const dateString = datePipe.transform(date, 'YYY-MM-dd');
		return dateString as string;
	}
}