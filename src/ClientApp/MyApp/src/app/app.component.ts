import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/service/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'MyAppZone';

  constructor(private readonly _accountService: AccountService) {}

  ngOnInit(): void {
    this._accountService.getMyAccount().subscribe({
      next: res => console.log(res),
      error: res => console.log(res),
    });
  }
}
