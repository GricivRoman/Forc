import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import ('./modules/foodDiaryModule/foodDiaryHomePage/foodDiary.module').then(m => m.FoodDiaryModule)
  },
  {
    path: 'personal-account',
    loadChildren: () => import ('./modules/foodDiaryModule/personalAccount/personalAccount.module').then(m => m.PersonalAccountModule)
  },
  {
    path: 'diary-menu',
    loadChildren: () => import ('./modules/foodDiaryModule/diaryMenu/diaryMenu.module').then(m => m.DiaryMenuModule)
  },
  {
    path: 'user',
    loadChildren: () => import ('./modules/foodDiaryModule/user/user.module').then(x => x.UserModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
