import { Injectable, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { HttpClient } from '@angular/common/http';
import { AppStore } from '../../store/app.store';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { TranslateService } from '@ngx-translate/core';
import { LANG_COOKIE } from '../../constants/translation/translation';

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
    this.cookies.get(LANG_COOKIE) &&
      this.translation.setDefaultLang(this.cookies.get(LANG_COOKIE));
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
    } catch (error) {
      return;
    }
  }
}
