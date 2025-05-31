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
import { Observable, Observer } from 'rxjs';
import { LANG_KEY } from '../constants/translation/translation';
import * as fs from 'node:fs';

const TRANSLATION_PATH = './dist/my-app/browser/assets/i18n';
const EXTENSION_FILE = 'json';
const BUFFER_ENCODING = 'utf8';

function HttpLoaderFactory() {
  const transferState = inject(TransferState);
  return {
    getTranslation: (lang: string) => {
      const key: StateKey<object> = makeStateKey<object>(`${LANG_KEY}-${lang}`);
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
