import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { IDENTITY_PARAMS } from '../../routes/identity.routes';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { IdentityService } from '../../services/identity/identity.service';
import { IdentityResetPasswordSubmissionAction } from '../../../../common/interfaces/httpActions/identityResetPasswordSubmissionAction';

@Component({
  selector: 'app-identity-reset-password',
  imports: [
    CommonModule,
    MatButton,
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule,
    TranslatePipe,
  ],
  template: ` <div class="grid grid-cols-1 place-items-center py-24 ">
    <div
      class="col-span-1 p-4 m-2 flex flex-col gap-4 justify-evenly items-center w-80"
    >
      <div class="flex flex-col items-center gap-1">
        <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
        <p class="text-sm uppercase text-gray-400">
          {{ 'ResetPassword' | translate }}
        </p>
      </div>
      <form [formGroup]="form" class="flex flex-col w-full">
        <mat-form-field>
          <mat-label>{{ 'Password' | translate }}</mat-label>
          <input
            type="password"
            autocomplete="password"
            formControlName="password"
            matInput
          />
        </mat-form-field>
        <mat-form-field>
          <mat-label> {{ 'ConfirmPassword' | translate }}</mat-label>
          <input
            type="password"
            autocomplete="password"
            formControlName="confirmPassword"
            matInput
          />
        </mat-form-field>
        <div class="flex flex-col gap-2">
          <button
            (click)="passwordSubmission()"
            mat-flat-button
            [class.spinner]="isLoading"
            [disabled]="isLoading"
          >
            {{ 'Confirm' | translate }}
          </button>
        </div>
      </form>
    </div>
  </div>`,
})
export class IdentityResetPasswordComponent implements OnInit {
  private readonly activatedRoute = inject(ActivatedRoute);
  private readonly fb = inject(FormBuilder);
  private readonly identityService = inject(IdentityService);

  private id: string | null = null;
  private token: string | null = null;

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.IDENTITY
    );
    this.token = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.TOKEN
    );

    this.initForm();
  }

  public passwordSubmission(): void {
    if (!this.form.valid || !this.id || !this.token) {
      return;
    }

    const { password } = this.form.value;
    const body: IdentityResetPasswordSubmissionAction = {
      id: this.id,
      token: this.token,
      password,
    };
    this.identityService.identityResetPasswordSubmission(body).subscribe();
  }

  private initForm(): void {
    this.form = this.fb.group({
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }
}
