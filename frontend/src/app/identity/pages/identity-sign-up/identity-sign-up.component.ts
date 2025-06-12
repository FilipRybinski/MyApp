import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TranslatePipe } from '@ngx-translate/core';
import { IdentityService } from '../../services/identity/identity.service';
import { Router } from '@angular/router';
import { IdentitySignUpAction } from '../../../../common/interfaces/httpActions/identitySignUpAction';
import { IDENTITY_ROUTING_PATH } from '../../routes/identity.routes';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AlertService } from '../../../../common/services/alert/alert.service';

@Component({
  selector: 'app-identity-sign-up',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    TranslatePipe,
    MatInputModule,
    MatButtonModule,
  ],
  template: `
    <div class="grid grid-cols-1 place-items-center p-4 m-2 ">
      <div
        class="col-span-1 p-4  flex flex-col gap-4 justify-evenly items-center w-80"
      >
        <div class="flex flex-col items-center gap-1">
          <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
          <p class="text-sm uppercase">
            {{ 'JoinToUs' | translate }}
          </p>
        </div>
        <form [formGroup]="form" class="flex flex-col w-full">
          <mat-form-field>
            <mat-label>{{ 'UserName' | translate }}</mat-label>
            <input
              type="text"
              autocomplete="off"
              formControlName="username"
              matInput
            />
          </mat-form-field>
          <mat-form-field>
            <mat-label>{{ 'Name' | translate }}</mat-label>
            <input
              type="text"
              autocomplete="off"
              formControlName="name"
              matInput
            />
          </mat-form-field>
          <mat-form-field>
            <mat-label>{{ 'Surname' | translate }}</mat-label>
            <input
              type="text"
              autocomplete="off"
              formControlName="surname"
              matInput
            />
          </mat-form-field>
          <mat-form-field>
            <mat-label>{{ 'Email' | translate }}</mat-label>
            <input
              type="text"
              autocomplete="off"
              formControlName="email"
              matInput
            />
          </mat-form-field>
          <mat-form-field>
            <mat-label>{{ 'Password' | translate }}</mat-label>
            <input
              type="password"
              autocomplete="off"
              formControlName="password"
              matInput
            />
          </mat-form-field>
          <mat-form-field>
            <mat-label>{{ 'ConfirmPassword' | translate }}</mat-label>
            <input
              type="password"
              autocomplete="off"
              formControlName="confirmPassword"
              matInput
            />
          </mat-form-field>
          <button
            mat-flat-button
            [class.spinner]="isLoading"
            [disabled]="isLoading"
            (click)="submit()"
          >
            {{ 'SignUp' | translate }}
          </button>
        </form>
      </div>
    </div>
  `,
})
export class IdentitySignUpComponent implements OnInit {
  private readonly identityService = inject(IdentityService);
  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);
  private readonly alertService = inject(AlertService);

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      username: ['', [Validators.required]],
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    this.isLoading = true;
    const body: IdentitySignUpAction = {
      email: this.form.value.email,
      username: this.form.value.username,
      name: this.form.value.name,
      surname: this.form.value.surname,
      password: this.form.value.password,
    };
    this.identityService.identitySignUp(body).subscribe({
      next: () => {
        this.isLoading = false;
        this.alertService.handleSuccess('Sign up successfully');
        this.router.navigate([
          IDENTITY_ROUTING_PATH.IDENTITY,
          IDENTITY_ROUTING_PATH.SIGN_IN,
        ]);
      },
      error: () => (this.isLoading = false),
    });
  }
}
