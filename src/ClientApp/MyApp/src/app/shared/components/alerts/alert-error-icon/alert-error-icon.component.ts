import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-alert-error',
  standalone: true,
  imports: [MatIcon, TranslateModule],
  template:
    '<div class="flex justify-between items-center"><span class="titlecase">{{data | translate}}</span><mat-icon class="error-icon-color">error</mat-icon></div>',
})
export class AlertErrorComponent {
  protected data: string = inject(MAT_SNACK_BAR_DATA);
}
