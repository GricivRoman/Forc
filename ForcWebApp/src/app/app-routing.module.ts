import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutGuard } from './modules/foodDiaryModule/account/authGuard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import ('./modules/foodDiaryModule/foodDiaryHomePage/foodDiary.module').then(m => m.FoodDiaryModule)
  },
  {
    path: 'personal-account',
    loadChildren: () => import ('./modules/foodDiaryModule/userProfile/userProfile.module').then(m => m.UserProfileModule),
    canActivate: [AutGuard]
  },
  {
    path: 'diary-menu',
    loadChildren: () => import ('./modules/foodDiaryModule/diaryMenu/diaryMenu.module').then(m => m.DiaryMenuModule)
  },
  {
    path: 'user',
    loadChildren: () => import ('./modules/foodDiaryModule/account/account.module').then(x => x.AccountModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
