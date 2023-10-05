import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserProfileComponent } from './userPage/userProfilecomponent';

const routes: Routes = [
	{
		path: '',
		component: UserProfileComponent
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class UserProfileRoutingModule { }