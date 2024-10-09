import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadInitialData } from '../../store/startup/startup.action';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  constructor(private readonly store: Store) {}

  public async initialize(): Promise<void> {
    this.store.dispatch(loadInitialData());
  }
}
