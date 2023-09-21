import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FoodDiaryComponent } from './foodDiary.component';

const routes: Routes = [
	{
		path: '',
		component: FoodDiaryComponent
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class FoodDiaryRoutingModule { }