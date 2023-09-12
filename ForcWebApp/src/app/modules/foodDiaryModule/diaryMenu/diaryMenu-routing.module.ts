import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiaryMenuComponent } from './diaryMenu.component';

const routes: Routes = [
  {
    path: '',
    component: DiaryMenuComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiaryMenuRoutingModule { }