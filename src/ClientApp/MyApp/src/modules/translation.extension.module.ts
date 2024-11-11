import { NgModule } from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { translationConfig } from '../constants/translation/translation';
import { Languages } from '../enums/languages';

function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(
    http,
    translationConfig.directory,
    translationConfig.extension
  );
}

@NgModule({
  imports: [
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
      defaultLanguage: Languages.ENG,
    }),
  ],
})
export class TranslationExtensionModule {}
