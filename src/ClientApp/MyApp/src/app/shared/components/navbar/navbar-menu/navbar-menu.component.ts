import { Component, OnDestroy, OnInit } from '@angular/core';
import { getHomeUrl, PATH } from '../../../../../constants/routing/path';
import { AuthService } from '../../../../../service/auth/auth.service';
import { Router } from '@angular/router';
import { SharedService } from '../../../service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar-menu',
  templateUrl: './navbar-menu.component.html',
  styleUrl: './navbar-menu.component.scss',
})
export class NavbarMenuComponent implements OnInit, OnDestroy {
  protected readonly PATH = PATH;
  public isAuth!: boolean;

  private subscription$ = new Subscription();

  constructor(
    public readonly authService: AuthService,
    private readonly sharedService: SharedService,
    private readonly router: Router
  ) {}

  public ngOnInit(): void {
    this.subscription$.add(this.handleIsAuthChange());
  }

  public logout(): void {
    this.sharedService.logout().subscribe({
      next: () =>
        this.router
          .navigate(getHomeUrl())
          .then(() => (this.authService.setAuthUser = null)),
    });
  }

  private handleIsAuthChange(): Subscription {
    return this.authService.isAuthChanged$.subscribe(
      isAuth => (this.isAuth = isAuth)
    );
  }

  public ngOnDestroy(): void {
    this.subscription$.unsubscribe();
  }
}
