import { NgModule } from '@angular/core';
import { UserProfileComponent } from './userPage/userProfilecomponent';
import { UserProfileRoutingModule } from './userProfile-routing.module';
import { ForcControlsModule } from '../../shared/module-frontend/controls/forc-controls.module';
import { DataService } from '../../shared/data.service';
import { AlertService } from '../../shared/module-frontend/forc-alert/alert.service';
import { SelectModule } from '../../shared/module-frontend/forc-select/select.module';
import { SelectServiceResolver } from '../../shared/select-services/selectServieResolver';
import { CommonModule } from '@angular/common';

@NgModule({
	imports: [
		UserProfileRoutingModule,
		ForcControlsModule,
		SelectModule,
		CommonModule
	],
	declarations: [
		UserProfileComponent
	],
	providers: [
		DataService,
		AlertService,
		SelectServiceResolver
	]
})
export class UserProfileModule {
}