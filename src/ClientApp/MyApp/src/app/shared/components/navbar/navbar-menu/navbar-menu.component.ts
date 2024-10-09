import { Component, inject } from '@angular/core';
import { getHomeUrl, PATH } from '../../../../../constants/routing/path';
import { Router } from '@angular/router';
import { SharedService } from '../../../../../service/shared/shared.service';
import { Store } from '@ngrx/store';
import { selectIsLoggedUserAuthorized } from '../../../../../store/startup/startup.selectors';
import { deauthorizeUser } from '../../../../../store/startup/startup.action';

@Component({
  selector: 'app-navbar-menu',
  templateUrl: './navbar-menu.component.html',
  styleUrl: './navbar-menu.component.scss',
})
export class NavbarMenuComponent {
  private readonly store = inject(Store);
  protected readonly PATH = PATH;
  public loggedInUser$ = this.store.selectSignal(selectIsLoggedUserAuthorized);

  constructor(
    private readonly sharedService: SharedService,
    private readonly router: Router
  ) {}

  public logout(): void {
    this.sharedService.logout().subscribe({
      next: () =>
        this.router
          .navigate(getHomeUrl())
          .then(() => this.store.dispatch(deauthorizeUser())),
    });
  }
}
