import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PATH } from '../constants/routing/path';
import * as Pages from './shared/pages';
import * as Guards from '../guards/index';

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
    canActivate: [Guards.featureFlagGuard],
    loadChildren: () =>
      import('./dashboard/dashboard.module').then(m => m.DashboardModule),
  },
  {
    path: PATH.FINANCE,
    canActivate: [Guards.featureFlagGuard],
    loadChildren: () =>
      import('./finance/finance.module').then(m => m.FinanceModule),
  },
  {
    path: PATH.MANAGEMENT,
    canActivate: [Guards.featureFlagGuard],
    loadChildren: () =>
      import('./management/management.module').then(m => m.ManagementModule),
  },
  {
    path: PATH.MARKETPLACE,
    canActivate: [Guards.authorizeGuard],
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
