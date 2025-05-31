import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { IDENTITY_PARAMS } from '../../routes/identity.routes';
import { IdentityService } from '../../services/identity/identity.service';
import { TranslatePipe } from '@ngx-translate/core';
import { MatIcon } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { MatButton } from '@angular/material/button';
import { IdentityActivationAction } from '../../../../common/interfaces/httpActions/identityActivationAction';
import { getGlobalHomeUrl } from '../../../../common/constants/routing/routing';

@Component({
  selector: 'app-identity-confirmation',
  imports: [CommonModule, MatIcon, MatTooltip, TranslatePipe, MatButton],
  template: ` <button mat-flat-button (click)="activateIdentity()">
    {{ 'Confirm' | translate }}
  </button>`,
})
export class IdentityConfirmationComponent implements OnInit {
  private readonly activatedRoute = inject(ActivatedRoute);
  private readonly identityService = inject(IdentityService);
  private readonly router = inject(Router);

  private id: string | null = null;
  private token: string | null = null;

  public ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.IDENTITY
    );
    this.token = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.TOKEN
    );
  }

  public activateIdentity(): void {
    if (this.id && this.token) {
      const body: IdentityActivationAction = {
        id: this.id,
        token: this.token,
      };
      this.identityService.identityActivation(body).subscribe({
        next: () => this.router.navigate(getGlobalHomeUrl()),
      });
    }
  }
}
