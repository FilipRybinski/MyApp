import { AfterViewInit, Component, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { handleLoadingAnimation } from '../utils/loading-animation.util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements AfterViewInit {
  title = 'MyAppZone';

  constructor(@Inject(PLATFORM_ID) private platform: object) {}

  public ngAfterViewInit(): void {
    isPlatformBrowser(this.platform) && handleLoadingAnimation();
  }
}
