import { Component } from '@angular/core';
import { PATH } from '../../../../constants/routing/path';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent {
  protected readonly PATH = PATH;
}
