import {
  inject,
  makeStateKey,
  NgModule,
  StateKey,
  TransferState,
} from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { Languages } from '../enums/languages';
import { Observable } from 'rxjs';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { LANG_KEY } from '../constants/translation/translation';

function HttpLoaderFactory(http: HttpClient) {
  const transferState = inject(TransferState);
  return {
    getTranslation: (lang: string) => {
      const key: StateKey<object> = makeStateKey<object>(`${LANG_KEY}-${lang}`);
      const data = transferState.get(key, null);
      return data
        ? new Observable(observer => {
            observer.next(data);
            observer.complete();
          })
        : new TranslateHttpLoader(http).getTranslation(lang);
    },
  };
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
export class BrowserTranslationExtensionModule {}
