import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '@ngx-translate/core';
import {
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { IdentityService } from '../../services/identity/identity.service';
import { IdentityResetPasswordRequestAction } from '../../../../common/interfaces/httpActions/identityResetPasswordRequestAction';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { BasicHttpResponse } from '../../../../common/interfaces/http/httpResponse';
import { MatInput } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-identity-reset-password-request',
  imports: [
    CommonModule,
    TranslatePipe,
    MatDialogActions,
    MatFormFieldModule,
    MatDialogContent,
    MatInput,
    MatButtonModule,
    ReactiveFormsModule,
  ],
  template: ` <div class="flex flex-col items-center gap-1 pt-4">
      <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
      <p class="text-sm uppercase text-gray-400">
        {{ 'ResetPassword' | translate }}
      </p>
    </div>
    <mat-dialog-content>
      <form [formGroup]="form">
        <mat-form-field>
          <mat-label>{{ 'Email' | translate }}</mat-label>
          <input
            type="text"
            autocomplete="off"
            formControlName="email"
            matInput
          />
        </mat-form-field>
      </form>
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-flat-button (click)="close()">
        {{ 'Close' | translate }}
      </button>
      <button
        [class.spinner]="isLoading"
        [disabled]="isLoading"
        mat-flat-button
        (click)="sendRequest()"
      >
        {{ 'Send' | translate }}
      </button>
    </mat-dialog-actions>`,
})
export class IdentityResetPasswordRequestComponent implements OnInit {
  private readonly dialogRef = inject(
    MatDialogRef<IdentityResetPasswordRequestComponent>
  );
  private readonly identityService = inject(IdentityService);
  private readonly fb = inject(FormBuilder);

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  public close(): void {
    this.dialogRef.close();
  }

  public sendRequest(): void {
    if (!this.form.valid) {
      return;
    }
    const body: IdentityResetPasswordRequestAction = {
      ...this.form.value,
    };

    this.isLoading = true;

    this.identityService.identityResetPasswordRequest(body).subscribe({
      next: ({ isSuccess }: BasicHttpResponse) => {
        this.isLoading = false;
        this.dialogRef.close();
      },
      error: () => (this.isLoading = false),
    });
  }
}
