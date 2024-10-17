import { Component, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsStartupLoading } from '../state/startup/startup.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'MyAppZone';
  private readonly store = inject(Store);
  public readonly isLoading = this.store.selectSignal(selectIsStartupLoading);
}
