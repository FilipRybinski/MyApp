import { Component } from '@angular/core';
import { PATH } from '../constants/routing/path';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'MyAppZone';
  protected readonly PATH = PATH;
}
