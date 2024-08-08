import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import * as Pages from './pages';
import { PATH } from '../../constants/routing/path';

const routes: Routes = [
  {
    path: '',
    component: Pages.AccountComponent,
  },
  { path: PATH.SIGN_IN, component: Pages.SigninComponent },
  { path: PATH.SIGN_UP, component: Pages.SignupComponent },
  {
    path: PATH.SETTINGS,
    component: Pages.SettingsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
