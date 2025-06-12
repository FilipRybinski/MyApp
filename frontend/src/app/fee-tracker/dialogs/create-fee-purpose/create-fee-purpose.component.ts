import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { AlertService } from '../../../../common/services/alert/alert.service';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { TranslatePipe } from '@ngx-translate/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MatDatepicker,
  MatDatepickerInput,
  MatDatepickerToggle,
} from '@angular/material/datepicker';
import { PurposeService } from '../../services/purpose/purpose.service';
import { CreatePurposeAction } from '../../../../common/interfaces/purpose/createPurposeAction';

@Component({
  selector: 'app-create-fee-purpose',
  imports: [
    CommonModule,
    MatButton,
    MatDialogActions,
    MatDialogContent,
    MatFormFieldModule,
    MatInput,
    TranslatePipe,
    ReactiveFormsModule,
    MatDatepickerToggle,
    MatDatepicker,
    MatDatepickerInput,
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
          <mat-label>{{ 'Title' | translate }}</mat-label>
          <input
            type="text"
            autocomplete="off"
            formControlName="title"
            matInput
          />
        </mat-form-field>

        <mat-form-field>
          <mat-label>{{ 'StartDate' | translate }}</mat-label>
          <input
            matInput
            [matDatepicker]="startPicker"
            formControlName="startDate"
            autocomplete="off"
          />
          <mat-datepicker-toggle
            matSuffix
            [for]="startPicker"
          ></mat-datepicker-toggle>
          <mat-datepicker #startPicker></mat-datepicker>
        </mat-form-field>

        <mat-form-field>
          <mat-label>{{ 'EndDate' | translate }}</mat-label>
          <input
            matInput
            [matDatepicker]="endPicker"
            formControlName="endDate"
            autocomplete="off"
          />
          <mat-datepicker-toggle
            matSuffix
            [for]="endPicker"
          ></mat-datepicker-toggle>
          <mat-datepicker #endPicker></mat-datepicker>
        </mat-form-field>
        <mat-form-field>
          <mat-label>{{ 'Amount' | translate }}</mat-label>
          <input
            matInput
            type="number"
            formControlName="amount"
            autocomplete="off"
            min="0"
            step="0.01"
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
export class CreateFeePurposeComponent {
  private readonly dialogRef = inject(MatDialogRef<CreateFeePurposeComponent>);
  private readonly purposeService = inject(PurposeService);
  private readonly alertService = inject(AlertService);

  private readonly fb = inject(FormBuilder);

  public form!: FormGroup;
  public isLoading = false;

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      title: ['', [Validators.required]],
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      amount: ['', [Validators.required]],
    });
  }

  public close(): void {
    this.dialogRef.close();
  }

  public sendRequest(): void {
    if (!this.form.valid) {
      return;
    }
    const body: CreatePurposeAction = {
      ...this.form.value,
    };

    this.isLoading = true;

    this.purposeService.createPurpose(body).subscribe({
      next: () => {
        this.isLoading = false;
        this.alertService.handleSuccess('Created successfully');
        this.dialogRef.close();
      },
      error: () => (this.isLoading = false),
    });
  }
}
