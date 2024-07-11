import { Component } from '@angular/core';
import { PATH } from '../../../../constants/routing/path';
import { AccountService } from '../../../account/service/account/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  public readonly PATH = PATH;

  constructor(private readonly _accountService: AccountService) {}
}
