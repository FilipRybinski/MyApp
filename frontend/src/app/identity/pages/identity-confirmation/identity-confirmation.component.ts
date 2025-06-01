import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { IDENTITY_PARAMS } from '../../routes/identity.routes';
import { IdentityService } from '../../services/identity/identity.service';
import { TranslatePipe } from '@ngx-translate/core';
import { MatButton } from '@angular/material/button';
import { IdentityActivationAction } from '../../../../common/interfaces/httpActions/identityActivationAction';
import { getGlobalHomeUrl } from '../../../../common/constants/routing/routing';

@Component({
  selector: 'app-identity-confirmation',
  imports: [CommonModule, TranslatePipe, MatButton],
  template: `
    <div class="grid grid-cols-1 place-items-center py-24 ">
      <div
        class="col-span-1 p-4 m-2 flex flex-col gap-4 justify-evenly items-center "
      >
        <div class="flex flex-col items-center gap-1 w-full">
          <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
          <p class="text-sm uppercase text-gray-400">
            <strong>{{ 'ThanksForRegistration' | translate }}</strong
            ><br />
            {{ 'ActivationInfo' | translate }} „{{
              'Confirm' | translate
            }}”.<br /><br />
            {{ 'ActivationIgnore' | translate }}
          </p>
        </div>
        <div>
          <button mat-flat-button (click)="activateIdentity()">
            {{ 'Confirm' | translate }}
          </button>
        </div>
      </div>
    </div>
  `,
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
