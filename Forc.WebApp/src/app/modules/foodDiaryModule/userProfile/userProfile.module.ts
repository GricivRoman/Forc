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
import { DailyRateComponent } from './userPage/dailyRate/dailyRate.component';
import { ModalWindowService } from '../../shared/module-frontend/forc-popup/modelWindow.service';
import { TargetCreationComponent } from './userPage/userTargets/targetCreation/targetCreation.component';
import { GridModule } from '../../shared/module-frontend/forc-grid/grid.module';
import { UserTargetsComponent } from './userPage/userTargets/userTargets.component';
import { ForcButtonsModule } from '../../shared/module-frontend/forc-buttons/forc-buttons.module';

@NgModule({
	imports: [
		UserProfileRoutingModule,
		ForcControlsModule,
		SelectModule,
		CommonModule,
		PhysicalActiviTySelectModule,
		SexSelectModule,
		ReactiveFormsModule,
		ForcImageModule,
		GridModule,
		ForcButtonsModule
	],
	declarations: [
		UserProfileComponent,
		DailyRateComponent,
		TargetCreationComponent,
		UserTargetsComponent
	],
	providers: [
		AlertService,
		ModalWindowService
	]
})
export class UserProfileModule {
}