import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import {
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { TranslatePipe } from '@ngx-translate/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ContributorService } from '../../services/contributor/contributor.service';
import { AlertService } from '../../../../common/services/alert/alert.service';
import { CreateContributorAction } from '../../../../common/interfaces/contributor/createContributorAction';

@Component({
  selector: 'app-create-contributor',
  imports: [
    CommonModule,
    MatButton,
    MatDialogActions,
    MatDialogContent,
    MatFormFieldModule,
    MatInput,
    TranslatePipe,
    ReactiveFormsModule,
  ],
  template: `
    <div class="flex flex-col items-center gap-1 pt-4">
      <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
      <p class="text-sm uppercase">
        {{ 'ResetPassword' | translate }}
      </p>
    </div>
    <mat-dialog-content>
      <form [formGroup]="form" class="flex flex-col w-full">
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
        {{ 'Confirm' | translate }}
      </button>
    </mat-dialog-actions>
  `,
})
export class CreateContributorComponent implements OnInit {
  private readonly dialogRef = inject(MatDialogRef<CreateContributorComponent>);
  private readonly contributorService = inject(ContributorService);
  private readonly alertService = inject(AlertService);

  private readonly fb = inject(FormBuilder);

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
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
    const body: CreateContributorAction = {
      ...this.form.value,
    };

    this.isLoading = true;

    this.contributorService.createContributor(body).subscribe({
      next: () => {
        this.isLoading = false;
        this.alertService.handleSuccess('Created successfully');
        this.dialogRef.close();
      },
      error: () => (this.isLoading = false),
    });
  }
}
