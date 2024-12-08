import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { getHomeUrl, PATH } from '../../../../../constants/routing/path';
import { Router } from '@angular/router';
import { SharedService } from '../../../../../service/shared/shared.service';
import { AppStore } from '../../../../../store/app.store';

@Component({
  selector: 'app-navbar-menu',
  templateUrl: './navbar-menu.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavbarMenuComponent {
  public readonly appStore = inject(AppStore);
  private readonly sharedService = inject(SharedService);
  private readonly router = inject(Router);

  protected readonly PATH = PATH;

  public logout(): void {
    this.sharedService.logout().subscribe({
      next: () =>
        this.router
          .navigate(getHomeUrl())
          .then(() => this.appStore.deauthorizeUser()),
    });
  }
}
