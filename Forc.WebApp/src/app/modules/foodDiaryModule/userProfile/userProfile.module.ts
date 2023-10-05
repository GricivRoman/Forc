import { NgModule } from '@angular/core';
import { UserProfileComponent } from './userPage/userProfilecomponent';
import { UserProfileRoutingModule } from './userProfile-routing.module';
import { ForcControlsModule } from '../../shared/module-frontend/controls/forc-controls.module';
import { AlertService } from '../../shared/module-frontend/forc-alert/alert.service';
import { SelectModule } from '../../shared/module-frontend/forc-select/select.module';
import { CommonModule } from '@angular/common';
import { PhysicalActiviTySelectModule } from '../../shared/select-controls/physicalActivity-select/physicalActivitySelect.module';
import { SexSelectModule } from '../../shared/select-controls/sex-select/sexSelect.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ForcImageModule } from '../../shared/module-frontend/forc-image/forcImage.module';

@NgModule({
	imports: [
		UserProfileRoutingModule,
		ForcControlsModule,
		SelectModule,
		CommonModule,
		PhysicalActiviTySelectModule,
		SexSelectModule,
		ReactiveFormsModule,
		ForcImageModule
	],
	declarations: [
		UserProfileComponent
	],
	providers: [
		AlertService
	]
})
export class UserProfileModule {
}