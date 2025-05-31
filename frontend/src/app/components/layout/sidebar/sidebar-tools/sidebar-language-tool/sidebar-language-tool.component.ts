import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { BottomSheetLanguagesMenuComponent } from './bottom-sheet-languages-menu/bottom-sheet-languages-menu.component';
import { TranslatePipe } from '@ngx-translate/core';
import { MatIcon } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-sidebar-language-tool',
  imports: [CommonModule, MatIcon, MatTooltip, TranslatePipe],
  template: `
    <button
      mat-icon-button
      matTooltip="{{ 'Language' | translate }}"
      (click)="openBottomSheet()"
    >
      <mat-icon>language</mat-icon>
    </button>
  `,
})
export class SidebarLanguageToolComponent {
  private readonly bottomSheet = inject(MatBottomSheet);

  public openBottomSheet(): void {
    this.bottomSheet.open(BottomSheetLanguagesMenuComponent);
  }
}
