import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-alert-warning',
  standalone: true,
  imports: [MatIcon],
  template:
    '<div class="d-flex justify-content-between align-content-center"><span class="titlecase">{{data}}</span> <mat-icon class="warning-icon-color">warning</mat-icon></div>',
})
export class AlertWarningComponent {
  protected data: string = inject(MAT_SNACK_BAR_DATA);
}
