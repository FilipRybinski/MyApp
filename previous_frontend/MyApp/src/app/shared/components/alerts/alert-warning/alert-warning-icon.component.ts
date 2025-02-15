import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-alert-warning',
  standalone: true,
  imports: [MatIcon, TranslateModule],
  template:
    '<div class="flex justify-between items-center"><span class="titlecase">{{data | translate}}</span> <mat-icon class="warning-icon-color">warning</mat-icon></div>',
})
export class AlertWarningComponent {
  protected data: string = inject(MAT_SNACK_BAR_DATA);
}
