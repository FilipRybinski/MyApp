import { Component } from '@angular/core';
import { availableLanguages } from '../../../../../../constants/translation/translation';
import { Language } from '../../../../../../interfaces/translation/translation';
import { Languages } from '../../../../../../enums/languages';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-bottom-sheet-languages-menu',
  templateUrl: './bottom-sheet-languages-menu.component.html',
})
export class BottomSheetLanguagesMenuComponent {
  public readonly languages: Language[] = availableLanguages;

  constructor(private readonly translateService: TranslateService) {}

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
