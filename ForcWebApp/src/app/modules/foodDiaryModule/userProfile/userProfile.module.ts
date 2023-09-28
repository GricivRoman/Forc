import { NgModule } from '@angular/core';
import { UserProfileComponent } from './userPage/userProfilecomponent';
import { UserProfileRoutingModule } from './userProfile-routing.module';
import { ForcControlsModule } from '../../shared/module-frontend/controls/forc-controls.module';
import { DataService } from '../../shared/data.service';
import { AlertService } from '../../shared/module-frontend/forc-alert/alert.service';
import { SelectModule } from '../../shared/module-frontend/forc-select/select.module';

@NgModule({
	imports: [
		UserProfileRoutingModule,
		ForcControlsModule,
		SelectModule
	],
	declarations: [
		UserProfileComponent
	],
	providers: [
		DataService,
		AlertService
	]
})
export class UserProfileModule {
}