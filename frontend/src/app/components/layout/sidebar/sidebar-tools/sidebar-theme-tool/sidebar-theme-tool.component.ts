import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { TranslatePipe } from '@ngx-translate/core';
import { MatTooltip } from '@angular/material/tooltip';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { BottomSheetThemeMenuComponent } from './bottom-sheet-theme-menu/bottom-sheet-theme-menu.component';

@Component({
  selector: 'app-sidebar-theme-tool',
  imports: [CommonModule, MatIcon, TranslatePipe, MatTooltip],
  template: `
    <button
      mat-icon-button
      matTooltip="{{ 'Theme' | translate }}"
      (click)="openBottomSheet()"
    >
      <mat-icon>brightness_medium</mat-icon>
    </button>
  `,
})
export class SidebarThemeToolComponent {
  private readonly bottomSheet = inject(MatBottomSheet);

  public openBottomSheet(): void {
    this.bottomSheet.open(BottomSheetThemeMenuComponent);
  }
}
