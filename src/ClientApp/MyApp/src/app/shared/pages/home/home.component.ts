import { Component } from '@angular/core';
import { AccountService } from '../../../account/service/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  constructor(private _accountService: AccountService) {}

  public signIn() {
    this._accountService.SignIn().subscribe();
  }
}
