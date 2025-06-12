import {
  Component,
  inject,
  OnInit,
  signal,
  WritableSignal,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ContributorsToolsComponent } from './contributors-tools/contributors-tools.component';
import { ContributorsListComponent } from './contributors-list/contributors-list.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { TranslatePipe } from '@ngx-translate/core';
import {
  MatCell,
  MatHeaderCell,
  MatHeaderRow,
  MatRow,
  MatTable,
  MatTableModule,
} from '@angular/material/table';
import {
  MatCard,
  MatCardContent,
  MatCardModule,
  MatCardTitle,
} from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { CreateFeePurposeComponent } from '../../dialogs/create-fee-purpose/create-fee-purpose.component';
import { PurposeService } from '../../services/purpose/purpose.service';
import { AlertService } from '../../../../common/services/alert/alert.service';
import { Contributor } from '../../../../common/interfaces/contributor/contributor';
import { Purpose } from '../../../../common/interfaces/purpose/purpose';
import { AttachFeeParticipantComponent } from '../../dialogs/attach-fee-participant/attach-fee-participant.component';
import { DetailsFeePurposeComponent } from '../../dialogs/details-fee-purpose/details-fee-purpose.component';

@Component({
  selector: 'app-contributors-sidebar',
  imports: [
    CommonModule,
    MatSidenavModule,
    ContributorsToolsComponent,
    ContributorsListComponent,
    MatIconModule,
    MatButton,
    TranslatePipe,
    MatTableModule,
    MatCardModule,
    MatCardContent,
    MatCardTitle,
    MatCard,
  ],
  template: ` <mat-sidenav-container class="h-[calc(100vh-64px)]">
    <mat-sidenav
      class="!rounded-md !shadow-md !w-64"
      position="end"
      [mode]="'side'"
      [opened]="true"
    >
      <div class="flex justify-center items-center w-full gap-2">
        <p>Contributors</p>
        <app-contributors-tools class="flex items-center" />
      </div>
      <app-contributors-list class="w-full" />
    </mat-sidenav>
    <mat-sidenav-content class="p-4">
      <div class="w-full flex flex-col justify-center pt-4 gap-4">
        <button mat-flat-button (click)="openCreatePurposeDialog()">
          {{ 'Add Purpose' | translate }}
        </button>
        <div class="w-full ">
          @for (purpose of purposes(); track $index) {
          <mat-card class="mb-4 w-full">
            <mat-card-title
              ><p class="ps-4">{{ purpose.title }}</p></mat-card-title
            >
            <mat-card-content>
              <p>
                <strong>Participants:</strong>
                {{ purpose.participants.length }}
              </p>
              <p>
                <strong>Start Date:</strong>
                {{ purpose.startDate | date : 'short' }}
              </p>
              <p>
                <strong>End Date:</strong>
                {{ purpose.endDate | date : 'short' }}
              </p>
              <p>
                <strong> Forecast amount:</strong>
                {{ purpose.amount }}
              </p>
              <p>
                <strong>Amount:</strong>
                {{ purpose.amount * purpose.participants.length }}
              </p>
              <div class="flex items-center gap-2">
                <p>In Progress:</p>
                @if (!purpose.isCompleted){
                <mat-icon>check_circle</mat-icon>
                }@else{
                <mat-icon>cancel</mat-icon>
                }
              </div>

              <div class="flex justify-end gap-2">
                @if (!purpose.isCompleted){
                <button mat-flat-button (click)="markAsCompleted(purpose.id)">
                  {{ 'Mark as completed' | translate }}</button
                >} @else {
                <button mat-flat-button (click)="deletePurpose(purpose.id)">
                  {{ 'Delete Purpose' | translate }}
                </button>
                }
                <button
                  mat-flat-button
                  (click)="openDetailsPurpose(purpose.id, purpose.amount)"
                >
                  {{ 'View Detials' | translate }}
                </button>
                <button
                  mat-flat-button
                  (click)="
                    openAttachFeeParticipant(purpose.id, purpose.participants)
                  "
                >
                  {{ 'Add Participant' | translate }}
                </button>
              </div>
            </mat-card-content>
          </mat-card>
          }
        </div>
        <div></div>
      </div>
    </mat-sidenav-content>
  </mat-sidenav-container>`,
})
export class ContributorsSidebarComponent implements OnInit {
  purposes: WritableSignal<Purpose[]> = signal<Purpose[]>([]);
  private readonly dialog = inject(MatDialog);
  private readonly purposeService = inject(PurposeService);
  private readonly alertService = inject(AlertService);

  public ngOnInit(): void {
    this.purposeService.fetchPurposes().subscribe({
      next: ({ data }) => {
        if (data) {
          this.purposes.set(data);
        }
      },
      error: () => this.alertService.handleError('Someting goes wrong'),
    });
  }

  public openCreatePurposeDialog(): void {
    this.dialog
      .open(CreateFeePurposeComponent)
      .afterClosed()
      .subscribe({
        next: () => {
          this.purposeService.fetchPurposes().subscribe({
            next: ({ data }) => {
              if (data) {
                this.purposes.set(data);
              }
            },
            error: () => this.alertService.handleError('Someting goes wrong'),
          });
        },
      });
  }

  public openAttachFeeParticipant(
    purposeId: string,
    participants: string[]
  ): void {
    this.dialog
      .open(AttachFeeParticipantComponent, {
        data: { id: purposeId, participants: participants },
      })
      .afterClosed()
      .subscribe({
        next: () => {
          this.purposeService.fetchPurposes().subscribe({
            next: ({ data }) => {
              if (data) {
                this.purposes.set(data);
              }
            },
            error: () => this.alertService.handleError('Someting goes wrong'),
          });
        },
      });
  }

  public markAsCompleted(purposeId: string): void {
    this.purposeService.markAsCompleted(purposeId).subscribe({
      next: () => {
        this.purposeService.fetchPurposes().subscribe({
          next: ({ data }) => {
            if (data) {
              this.purposes.set(data);
            }
          },
          error: () => this.alertService.handleError('Someting goes wrong'),
        });
      },
    });
  }
  public deletePurpose(id: string) {
    this.purposeService.deletePurpose(id).subscribe({
      next: () => {
        this.purposeService.fetchPurposes().subscribe({
          next: ({ data }) => {
            if (data) {
              this.purposes.set(data);
            }
          },
          error: () => this.alertService.handleError('Someting goes wrong'),
        });
      },
    });
  }

  public openDetailsPurpose(purposeId: string, amount: number): void {
    this.dialog.open(DetailsFeePurposeComponent, {
      data: { id: purposeId, amount: amount },
    });
  }
}
