import { Component } from '@angular/core';
import { PATH } from '../../../../constants/routing/path';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  protected readonly PATH = PATH;
}
