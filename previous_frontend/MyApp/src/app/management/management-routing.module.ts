import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import * as Pages from './pages';

const routes: Routes = [{ path: '', component: Pages.ManagementComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ManagementRoutingModule {}
