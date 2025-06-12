import {
  Component,
  inject,
  OnInit,
  signal,
  WritableSignal,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContributorService } from '../../../services/contributor/contributor.service';
import { Contributor } from '../../../../../common/interfaces/contributor/contributor';
import { AlertService } from '../../../../../common/services/alert/alert.service';

@Component({
  selector: 'app-contributors-list',
  imports: [CommonModule],
  template: `
    @for ( contributor of contributorService.contributors(); track
    contributor.id){
    <div class="flex justify-center items-center gap-2 w-full">
      <div class="w-6 h-6 bg-identity bg-center bg-no-repeat bg-contain "></div>
      <div>
        <p>{{ contributor.name }} {{ contributor.surname }}</p>
        <p>{{ contributor.email }}</p>
      </div>
    </div>
    }
  `,
})
export class ContributorsListComponent implements OnInit {
  public readonly contributorService = inject(ContributorService);
  private readonly alertService = inject(AlertService);

  public ngOnInit(): void {
    this.contributorService.fetchContributors().subscribe({
      next: ({ data }) => {
        if (data) {
          this.contributorService.contributors.set(data);
        }
      },
      error: () => this.alertService.handleError('Failed to load resources'),
    });
  }
}
