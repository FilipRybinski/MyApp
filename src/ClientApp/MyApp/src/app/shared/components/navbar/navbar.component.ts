import { Component } from '@angular/core';
import { PATH } from '../../../../constants/routing/path';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  protected readonly PATH = PATH;
}
