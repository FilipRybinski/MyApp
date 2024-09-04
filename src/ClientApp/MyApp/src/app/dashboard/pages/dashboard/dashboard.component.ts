import { Component } from '@angular/core';
import { PATH } from '../../../../constants/routing/path';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
  protected readonly PATH = PATH;
}
