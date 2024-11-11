import { Injectable, inject, PLATFORM_ID } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { HttpClient } from '@angular/common/http';
import { AppStore } from '../../store/app.store';
import { isPlatformBrowser, isPlatformServer } from '@angular/common';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { TranslateService } from '@ngx-translate/core';
import { LANG_COOKIE } from '../../constants/translation/translation';
import { Languages } from '../../enums/languages';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  private readonly appStore = inject(AppStore);
  private readonly platform = inject(PLATFORM_ID);
  private readonly http = inject(HttpClient);
  private readonly cookies = inject(SsrCookieService);
  private readonly translation = inject(TranslateService);

  public async initialize(): Promise<void> {
    environment.ssr
      ? isPlatformServer(this.platform) && (await this.fetchInitializeData())
      : isPlatformBrowser(this.platform) && (await this.fetchInitializeData());
  }

  private async fetchInitializeData(): Promise<void> {
    try {
      const user = await firstValueFrom(
        this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED)
      );
      const featureFlags = await firstValueFrom(
        this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS)
      );
      this.appStore.attachInitialData(user, featureFlags);
      isPlatformBrowser(this.platform) &&
        this.translation.use(this.cookies.get(LANG_COOKIE) ?? Languages.ENG);
    } catch (error) {
      return;
    }
  }
}
