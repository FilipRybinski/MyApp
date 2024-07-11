import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PATH } from '../constants/routing/path';
import * as Pages from './shared/pages';

const routes: Routes = [
  {
    path: '',
    redirectTo: PATH.HOME,
    pathMatch: 'full',
  },
  {
    path: PATH.HOME,
    component: Pages.HomeComponent,
  },
  {
    path: PATH.ACCOUNT,
    loadChildren: () =>
      import('./account/account.module').then(m => m.AccountModule),
  },
  {
    path: PATH.DASHBOARD,
    loadChildren: () =>
      import('./dashboard/dashboard.module').then(m => m.DashboardModule),
  },
  {
    path: PATH.FINANCE,
    loadChildren: () =>
      import('./finance/finance.module').then(m => m.FinanceModule),
  },
  {
    path: PATH.MANAGEMENT,
    loadChildren: () =>
      import('./management/management.module').then(m => m.ManagementModule),
  },
  {
    path: PATH.MARKETPLACE,
    loadChildren: () =>
      import('./marketplace/marketplace.module').then(m => m.MarketplaceModule),
  },
  {
    path: PATH.PAGE_NOT_FOUND,
    component: Pages.PageNotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
