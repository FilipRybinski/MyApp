import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-alert-success',
  standalone: true,
  imports: [MatIcon, TranslateModule],
  template:
    '<div class="flex justify-between items-center"><span class="titlecase">{{data | translate}}</span><mat-icon class="success-icon-color">done</mat-icon></div>',
})
export class AlertSuccessComponent {
  protected data: string = inject(MAT_SNACK_BAR_DATA);
}
