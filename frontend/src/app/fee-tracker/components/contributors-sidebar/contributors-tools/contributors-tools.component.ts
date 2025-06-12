import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { TranslatePipe } from '@ngx-translate/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateContributorComponent } from '../../../dialogs/create-contributor/create-contributor.component';
import { ContributorService } from '../../../services/contributor/contributor.service';
import { AlertService } from '../../../../../common/services/alert/alert.service';

@Component({
  selector: 'app-contributors-tools',
  imports: [CommonModule, MatIconModule, MatTooltip, TranslatePipe],
  template: `<button
    mat-icon-button
    matTooltip="{{ 'Add Contributor' | translate }}"
    (click)="openCreateContributorDialog()"
  >
    <mat-icon>person_add</mat-icon>
  </button> `,
})
export class ContributorsToolsComponent {
  private readonly dialog = inject(MatDialog);
  private readonly contributorService = inject(ContributorService);
  private readonly alertService = inject(AlertService);

  public openCreateContributorDialog(): void {
    this.dialog
      .open(CreateContributorComponent)
      .afterClosed()
      .subscribe({
        next: () => {
          this.contributorService.fetchContributors().subscribe({
            next: ({ data }) => {
              if (data) {
                this.contributorService.contributors.set(data);
              }
            },
            error: () =>
              this.alertService.handleError('Failed to load resources'),
          });
        },
      });
  }
}
