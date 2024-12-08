import { Component, inject } from '@angular/core';
import {
  availableLanguages,
  LANG_COOKIE,
} from '../../../../../../constants/translation/translation';
import { Language } from '../../../../../../interfaces/translation/translation';
import { Languages } from '../../../../../../enums/languages';
import { TranslateService } from '@ngx-translate/core';
import { SsrCookieService } from 'ngx-cookie-service-ssr';

@Component({
  selector: 'app-bottom-sheet-languages-menu',
  templateUrl: './bottom-sheet-languages-menu.component.html',
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
