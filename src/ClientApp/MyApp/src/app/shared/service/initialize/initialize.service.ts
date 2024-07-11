import { HttpClient } from '@angular/common/http';
import { AccountService } from '../../../account/service/account/account.service';
import { Injectable } from '@angular/core';

@Injectable()
export class InitializeService {
  constructor(
    private readonly _http: HttpClient,
    private readonly _accountService: AccountService
  ) {}

  public async initialize(): Promise<void> {
    try {
      console.log('InitializeService initialized');
    } catch (error) {
      console.error('Failed to initialize application', error);
    }
  }
}
