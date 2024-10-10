import { Injectable } from '@angular/core';
import { loadInitialData } from '../../state/startup/startup.action';
import { Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  constructor(private readonly store: Store) {}

  public async initialize(): Promise<void> {
    this.store.dispatch(loadInitialData());
  }
}
