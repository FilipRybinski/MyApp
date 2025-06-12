import {
  Component,
  inject,
  signal,
  WritableSignal,
  OnInit,
  Inject,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { TranslatePipe } from '@ngx-translate/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AlertService } from '../../../../common/services/alert/alert.service';
import { Contributor } from '../../../../common/interfaces/contributor/contributor';
import { ContributorService } from '../../services/contributor/contributor.service';
import { MatListModule } from '@angular/material/list';
import { ParticipantService } from '../../services/participant/participant.service';

@Component({
  selector: 'app-attach-fee-participant',
  standalone: true,
  imports: [
    CommonModule,
    MatButton,
    MatDialogActions,
    MatDialogContent,
    MatFormFieldModule,
    TranslatePipe,
    ReactiveFormsModule,
    FormsModule,
    MatListModule,
  ],
  template: `
    <div class="flex flex-col items-center gap-1 pt-4">
      <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
      <p class="text-sm uppercase">
        {{ 'ResetPassword' | translate }}
      </p>
    </div>

    <mat-dialog-content>
      <mat-selection-list
        [multiple]="true"
        [(ngModel)]="selectedUsers"
        class="w-full"
      >
        <mat-list-option
          *ngFor="let user of availableUsers(); trackBy: trackByUserId"
          [value]="user"
        >
          {{ user.name }} {{ user.surname }} ({{ user.email }})
        </mat-list-option>
      </mat-selection-list>
    </mat-dialog-content>

    <mat-dialog-actions>
      <button mat-flat-button (click)="closeDialog()">
        {{ 'Close' | translate }}
      </button>
      <button
        [class.spinner]="isLoading"
        [disabled]="isLoading"
        mat-flat-button
        (click)="assignSelectedUsers()"
      >
        {{ 'Confirm' | translate }}
      </button>
    </mat-dialog-actions>
  `,
})
export class AttachFeeParticipantComponent implements OnInit {
  public availableUsers: WritableSignal<Contributor[]> = signal<Contributor[]>(
    []
  );
  public selectedUsers: Contributor[] = [];
  public attachedUsers: string[] = [];

  public isLoading = false;
  public purposeId: string;

  private readonly contributorService = inject(ContributorService);
  private readonly participantService = inject(ParticipantService);
  private readonly alertService = inject(AlertService);
  private readonly dialogRef = inject(
    MatDialogRef<AttachFeeParticipantComponent>
  );

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { id: string; participants: string[] }
  ) {
    this.purposeId = data.id;
    this.attachedUsers = data.participants;
  }

  public ngOnInit(): void {
    this.contributorService.fetchContributors().subscribe({
      next: ({ data }) => {
        if (data) {
          this.availableUsers.set(
            data.filter((e) => !this.attachedUsers.includes(e.id))
          );
        }
      },
      error: () => this.alertService.handleError('Failed to load resources'),
    });
  }

  public assignSelectedUsers(): void {
    const selectedIds = this.selectedUsers.map((user) => user.id);
    this.participantService
      .createPurpose({
        id: this.purposeId,
        participants: this.selectedUsers.map((user) => user.id),
      })
      .subscribe({});
    this.dialogRef.close(selectedIds);
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

  public trackByUserId(_: number, item: Contributor): string {
    return item.id;
  }
}
