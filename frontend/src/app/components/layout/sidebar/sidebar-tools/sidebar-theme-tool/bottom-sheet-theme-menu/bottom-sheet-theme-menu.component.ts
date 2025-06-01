import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatListItem, MatNavList } from '@angular/material/list';
import { TranslatePipe } from '@ngx-translate/core';
import { MatIcon } from '@angular/material/icon';

interface Theme {
  name: string;
  icon: string;
}

@Component({
  selector: 'app-bottom-sheet-theme-menu',
  imports: [CommonModule, MatNavList, MatListItem, TranslatePipe, MatIcon],
  template: `
    <mat-nav-list>
      @for (theme of themes; track theme.name) {
      <mat-list-item
        [activated]="isActivated(theme.name)"
        (click)="changeTheme(theme.name)"
      >
        <div class="flex items-center gap-4">
          <mat-icon>{{ theme.icon }}</mat-icon>
          <span matListItemTitle>{{ theme.name | translate }}</span>
        </div>
      </mat-list-item>
      }
    </mat-nav-list>
  `,
})
export class BottomSheetThemeMenuComponent {
  public readonly themes: Theme[] = [
    {
      name: 'light',
      icon: 'light_mode',
    },
    {
      name: 'dark',
      icon: 'dark_mode',
    },
  ];

  public changeTheme(theme: string): void {
    document.body.classList.remove('dark', 'light');
    document.body.classList.add(theme);
  }

  public isActivated(theme: string): boolean {
    return document.body.classList.contains(theme);
  }
}
