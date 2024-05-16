import { Component } from '@angular/core';
import { AccountService } from '../../service/account.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
})
export class SignupComponent {
  constructor(private _accountService: AccountService) {}

  public signIn() {
    this._accountService.SignIn().subscribe();
  }
}
