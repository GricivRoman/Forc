import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FoodDiaryComponent } from './foodDiaryHomePage/foodDiary.component';
import { PersonalAccountComponent } from './personalAccount/personalAccount.component';
import { DiaryMenuComponent } from './diaryMenu/diaryMenu.component';

const routes: Routes = [
  {
    path: '',
    component: FoodDiaryComponent
  },
  {
    path: 'personal-account',
    component: PersonalAccountComponent
  },
  {
    path: 'diary-menu',
    component: DiaryMenuComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FoodDiaryRoutingModule { }