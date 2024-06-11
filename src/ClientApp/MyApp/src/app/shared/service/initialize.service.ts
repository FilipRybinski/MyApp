import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { StoreService } from './store.service';
import { AccountService } from '../../account/service/account.service';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  constructor(
    private readonly _http: HttpClient,
    private readonly _storeService: StoreService,
    private readonly _accountService: AccountService
  ) {}

  public async initialize(): Promise<void> {
    try {
      await firstValueFrom(this._accountService.getMyAccount()).then(
        async user => {
          this._storeService.user = user;
          this._storeService.flags = await firstValueFrom(
            this._accountService.getFeatureFlags()
          );
        }
      );
    } catch (error) {
      console.error('Failed to initialize application', error);
    }
  }
}
