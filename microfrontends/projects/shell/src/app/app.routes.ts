import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { loadRemoteModule } from '@angular-architects/native-federation';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
      path: 'fee-tracker',
      loadComponent: () =>
          loadRemoteModule('feeTracker', './Component').then((m) => m.AppComponent),
  },
  {
      path: '**',
      component: HomeComponent,
  },
];
