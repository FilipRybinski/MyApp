import { Component } from '@angular/core';
import { AccountService } from '../../service/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss',
})
export class AccountComponent {
  constructor(private _accountSerivce: AccountService) {}

  public test() {
    this._accountSerivce.test().subscribe();
  }
}
