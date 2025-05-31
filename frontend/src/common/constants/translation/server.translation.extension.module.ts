import {
  inject,
  makeStateKey,
  NgModule,
  StateKey,
  TransferState,
} from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Observer } from 'rxjs';
import { LANG_KEY } from './translation';
import { Languages } from '../../enums/languages';

const TRANSLATION_PATH = './dist/frontend/browser/i18n';
const EXTENSION_FILE = 'json';
const BUFFER_ENCODING = 'utf8';

function HttpLoaderFactory() {
  const transferState = inject(TransferState);
  return {
    getTranslation: (lang: string) => {
      const key: StateKey<object> = makeStateKey<object>(`${LANG_KEY}-${lang}`);
      const fs = require('fs');
      const data = JSON.parse(
        fs.readFileSync(
          `${TRANSLATION_PATH}/${lang}.${EXTENSION_FILE}`,
          BUFFER_ENCODING
        )
      );
      transferState.set(key, data);
      return new Observable((observer: Observer<unknown>) => {
        observer.next(data);
        observer.complete();
      });
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
export class ServerTranslationExtensionModule {}
