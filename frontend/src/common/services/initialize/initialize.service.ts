import { inject, Injectable } from '@angular/core';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { TranslateService } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { LANG_COOKIE } from '../../constants/translation/translation';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { firstValueFrom } from 'rxjs';
import { Identity } from '../../interfaces/identity/identity';
import { environment } from '../../../environments/environment';
import { HttpResponse } from '../../interfaces/http/httpResponse';
import { AppStore } from '../../store/app.store';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  private readonly appStore = inject(AppStore);
  private readonly http = inject(HttpClient);
  private readonly cookies = inject(SsrCookieService);
  private readonly translation = inject(TranslateService);

  public async initialize(): Promise<void> {
    await this.fetchInitializeData();
    const cookie = this.cookies.get(LANG_COOKIE);
    if (cookie) {
      this.translation.setDefaultLang(this.cookies.get(LANG_COOKIE));
    }
  }

  private async fetchInitializeData(): Promise<void> {
    try {
      const user = await firstValueFrom(
        this.http.get<HttpResponse<Identity>>(
          environment.URL.USERS.IS_AUTHORIZED
        )
      );
      const featureFlags = await firstValueFrom(
        this.http.get<HttpResponse<FeatureFlags>>(environment.URL.FEATURE_FLAGS)
      );
      this.appStore.attachInitialData(user.data, featureFlags.data);
      console.log('initialize data fetched', user, featureFlags);
    } catch (error) {
      return;
    }
  }
}
