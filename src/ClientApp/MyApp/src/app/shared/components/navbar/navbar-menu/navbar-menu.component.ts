import { ChangeDetectionStrategy, Component } from '@angular/core';
import { getHomeUrl, PATH } from '../../../../../constants/routing/path';
import { AuthService } from '../../../../../service/auth/auth.service';
import { Router } from '@angular/router';
import { SharedService } from '../../../service';

@Component({
  selector: 'app-navbar-menu',
  templateUrl: './navbar-menu.component.html',
  styleUrl: './navbar-menu.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavbarMenuComponent {
  protected readonly PATH = PATH;

  constructor(
    public readonly authService: AuthService,
    private readonly sharedService: SharedService,
    private readonly router: Router
  ) {}

  public logout(): void {
    this.sharedService.logout().subscribe({
      next: () =>
        this.router
          .navigate(getHomeUrl())
          .then(() => (this.authService.setAuthUser = null)),
    });
  }
}
