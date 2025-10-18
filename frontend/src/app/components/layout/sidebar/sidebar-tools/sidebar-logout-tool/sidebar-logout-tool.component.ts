import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { TranslatePipe } from '@ngx-translate/core';
import { IdentityService } from '../../../../../identity/services/identity/identity.service';
import { AppStore } from '../../../../../../common/store/app.store';
import { getGlobalHomeUrl } from '../../../../../../common/constants/routing/routing';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar-logout-tool',
  imports: [CommonModule, MatIcon, MatTooltip, TranslatePipe],
  template: ` <button
    mat-icon-button
    matTooltip="{{ 'Logout' | translate }}"
    (click)="logout()"
  >
    <mat-icon>logout</mat-icon>
  </button>`,
})
export class SidebarLogoutToolComponent {
  private readonly identityService = inject(IdentityService);
  private readonly appStore = inject(AppStore);
  private readonly router = inject(Router);

  public logout(): void {
    this.identityService.identityLogout().subscribe({
      next: ({ isSuccess }) => {
        if (isSuccess) {
          this.router
            .navigate(getGlobalHomeUrl())
            .then(() => this.appStore.detachIdentity());
        }
      },
    });
  }
}
