import { Component, inject } from '@angular/core';
import { availableLanguages } from '../../../../../../constants/translation/translation';
import { Language } from '../../../../../../interfaces/translation/translation';
import { Languages } from '../../../../../../enums/languages';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-bottom-sheet-languages-menu',
  templateUrl: './bottom-sheet-languages-menu.component.html',
})
export class BottomSheetLanguagesMenuComponent {
  private readonly translateService = inject(TranslateService);

  public readonly languages: Language[] = availableLanguages;

  public get defaultLanguage(): string {
    return (
      this.translateService.currentLang ??
      this.translateService.getDefaultLang()
    );
  }

  public changeLanguage(language: Languages): void {
    this.translateService.use(language);
  }
}
