import { Component, Inject, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogContent,
} from '@angular/material/dialog';
import { TranslatePipe } from '@ngx-translate/core';
import { Participant } from '../../../../common/interfaces/participants/participants';
import { MatTableModule } from '@angular/material/table';
import { ParticipantService } from '../../services/participant/participant.service';

@Component({
  selector: 'app-details-fee-purpose',
  imports: [
    CommonModule,
    MatDialogActions,
    MatDialogContent,
    TranslatePipe,
    MatTableModule,
  ],
  template: ` <div class="flex flex-col items-center gap-1 pt-4">
      <div class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain"></div>
      <p class="text-sm uppercase">
        {{ 'ResetPassword' | translate }}
      </p>
    </div>

    <mat-dialog-content>
      <p>Collect: {{ amount * takeAmountPaid() }}</p>
      <table mat-table [dataSource]="participants()" class="w-full">
        <ng-container matColumnDef="name">
          <th mat-header-cell *matHeaderCellDef>name</th>
          <td mat-cell *matCellDef="let participant">
            {{ participant.name }}
          </td>
        </ng-container>

        <ng-container matColumnDef="surname">
          <th mat-header-cell *matHeaderCellDef>surname</th>
          <td mat-cell *matCellDef="let participant">
            {{ participant.surname }}
          </td>
        </ng-container>

        <ng-container matColumnDef="email">
          <th mat-header-cell *matHeaderCellDef>email</th>
          <td mat-cell *matCellDef="let participant">
            {{ participant.email }}
          </td>
        </ng-container>

        <ng-container matColumnDef="hasPaid">
          <th mat-header-cell *matHeaderCellDef>paid</th>
          <td mat-cell *matCellDef="let participant">
            <button
              mat-button
              (click)="togglePayment(participant.id, participant.hasPaid)"
            >
              {{ participant.hasPaid ? '✅' : '❌' }}
            </button>
          </td>
        </ng-container>

        <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
        <tr mat-row *matRowDef="let row; columns: displayedColumns"></tr></table
    ></mat-dialog-content>

    <mat-dialog-actions> </mat-dialog-actions>`,
})
export class DetailsFeePurposeComponent implements OnInit {
  private readonly participantService = inject(ParticipantService);
  participants = signal<Participant[]>([]);
  displayedColumns: string[] = ['name', 'surname', 'email', 'hasPaid'];
  public purposeId: string;
  public amount: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { id: string; amount: number }
  ) {
    this.purposeId = data.id;
    this.amount = data.amount;
  }

  public ngOnInit(): void {
    this.participantService.fetchParticipants(this.purposeId).subscribe({
      next: ({ data }) => {
        if (data) {
          this.participants.set(data);
        }
      },
    });
  }

  takeAmountPaid() {
    return this.participants().filter((e) => e.hasPaid).length;
  }

  togglePayment(id: string, hasPaid: boolean): void {
    if (hasPaid) {
      return;
    }
    this.participantService.markAsPaid(id).subscribe({
      next: () => {
        this.participantService.fetchParticipants(this.purposeId).subscribe({
          next: ({ data }) => {
            if (data) {
              this.participants.set(data);
            }
          },
        });
      },
    });
  }
}
