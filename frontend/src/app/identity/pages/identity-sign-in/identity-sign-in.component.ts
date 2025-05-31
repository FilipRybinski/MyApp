import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppStore } from '../../../../common/store/app.store';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { IdentityService } from '../../services/identity/identity.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { IdentitySignInAction } from '../../../../common/interfaces/httpActions/identitySignInAction';
import { TranslatePipe } from '@ngx-translate/core';
import { HttpResponse } from '../../../../common/interfaces/http/httpResponse';
import { Identity } from '../../../../common/interfaces/identity/identity';
import { getGlobalHomeUrl } from '../../../../common/constants/routing/routing';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AlertService } from '../../../../common/services/alert/alert.service';
import { IdentityResetPasswordRequestComponent } from '../../dialogs/identity-reset-password-request/identity-reset-password-request.component';

@Component({
  selector: 'app-identity-sign-in',
  imports: [
    CommonModule,
    MatFormFieldModule,
    TranslatePipe,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
  ],
  template: ` <div class="grid grid-cols-1 place-items-center py-24 ">
    <div
      class="col-span-1 p-4 m-2 flex flex-col gap-4 justify-evenly items-center w-80"
    >
      <div class="flex flex-col items-center gap-1">
        <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
        <p class="text-sm uppercase text-gray-400">
          {{ 'Welcome' | translate }}
        </p>
      </div>
      <form [formGroup]="form" class="flex flex-col w-full">
        <mat-form-field>
          <mat-label>{{ 'Email' | translate }}</mat-label>
          <input
            type="text"
            autocomplete="email"
            formControlName="email"
            matInput
          />
        </mat-form-field>
        <mat-form-field>
          <mat-label>{{ 'Password' | translate }}</mat-label>
          <input
            type="password"
            autocomplete="password"
            formControlName="password"
            matInput
          />
        </mat-form-field>
        <div class="flex flex-col gap-2">
          <button mat-button (click)="openResetPasswordDialog()">
            {{ 'ResetPassword' | translate }}
          </button>
          <button
            (click)="submit()"
            mat-flat-button
            [class.spinner]="isLoading"
            [disabled]="isLoading"
          >
            {{ 'SignIn' | translate }}
          </button>
        </div>
      </form>
    </div>
  </div>`,
})
export class IdentitySignInComponent implements OnInit {
  private readonly appStore = inject(AppStore);
  private readonly fb = inject(FormBuilder);
  private readonly identityService = inject(IdentityService);
  private readonly router = inject(Router);
  private readonly alertService = inject(AlertService);
  private readonly dialog = inject(MatDialog);

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    const body: IdentitySignInAction = {
      ...this.form.value,
    };
    this.isLoading = true;
    this.identityService.identitySignIn(body).subscribe({
      next: ({ data }: HttpResponse<Identity>) => {
        this.alertService.handleSuccess('Sign in successfully');
        this.isLoading = false;
        this.router
          .navigate(getGlobalHomeUrl())
          .then(() => this.appStore.attachIdentity(data));
      },
      error: () => (this.isLoading = false),
    });
  }

  public openResetPasswordDialog(): void {
    this.dialog.open(IdentityResetPasswordRequestComponent);
  }
}
