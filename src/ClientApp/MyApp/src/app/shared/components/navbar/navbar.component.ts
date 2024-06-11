import { Component } from '@angular/core';
import { StoreService } from '../../service/store.service';
import { PATH } from '../../../../constants/routing/path';
import { AccountService } from '../../../account/service/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  public readonly PATH = PATH;

  constructor(
    public readonly _storeService: StoreService,
    private readonly _accountService: AccountService
  ) {}

  public logOut() {
    this._accountService.logOut().subscribe({
      next: () => {
        this._storeService.loadInitialState();
      },
    });
  }
}
