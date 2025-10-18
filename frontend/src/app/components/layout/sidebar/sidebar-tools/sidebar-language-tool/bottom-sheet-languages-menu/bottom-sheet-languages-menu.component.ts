import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatListItem, MatNavList } from '@angular/material/list';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { Language } from '../../../../../../../common/interfaces/translation/translation';
import {
  availableLanguages,
  LANG_COOKIE,
} from '../../../../../../../common/constants/translation/translation';
import { Languages } from '../../../../../../../common/enums/languages';

@Component({
  selector: 'app-bottom-sheet-languages-menu',
  imports: [CommonModule, MatNavList, MatListItem, TranslatePipe],
  template: `
    <mat-nav-list>
      @for (language of languages; track language.language) {
      <mat-list-item
        [activated]="language.language === defaultLanguage"
        (click)="changeLanguage(language.language)"
      >
        <div class="flex items-center gap-4">
          <div
            class="w-8 h-8 bg-contain bg-center bg-no-repeat {{
              language.icon
            }}"
            matListItemIcon
          ></div>
          <span matListItemTitle>{{ language.name | translate }}</span>
        </div>
      </mat-list-item>
      }
    </mat-nav-list>
  `,
})
export class BottomSheetLanguagesMenuComponent {
  private readonly translateService = inject(TranslateService);
  private readonly cookies = inject(SsrCookieService);

  public readonly languages: Language[] = availableLanguages;

  public get defaultLanguage(): string {
    return (
      this.translateService.currentLang ??
      this.translateService.getDefaultLang()
    );
  }

  public changeLanguage(language: Languages): void {
    this.cookies.set(LANG_COOKIE, language);
    this.translateService.use(language);
  }
}
