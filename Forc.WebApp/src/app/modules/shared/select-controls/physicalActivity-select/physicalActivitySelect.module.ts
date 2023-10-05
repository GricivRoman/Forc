import { NgModule } from '@angular/core';
import { SelectModule } from '../../module-frontend/forc-select/select.module';
import { PhysicalActivitySelectComponent } from './physicalActivitySelect.component';
import { DataService } from '../../services/data.service';
import { PhysicalActivityService } from './physicalActivitySelect.service';

@NgModule({
	imports: [
		SelectModule
	],
	declarations: [
		PhysicalActivitySelectComponent
	],
	exports: [
		PhysicalActivitySelectComponent
	],
	providers: [
		DataService,
		PhysicalActivityService
	]
})
export class PhysicalActiviTySelectModule {

}