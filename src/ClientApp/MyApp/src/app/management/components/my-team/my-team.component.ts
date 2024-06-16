import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { Team } from '../../../../interfaces/team/team';
import { User } from '../../../../interfaces/account/user';
import { CreateTeamComponent } from '../../dialogs';
import { MatDialogSize } from '../../../../constants/MatDialogSize';
import { MatDialog } from '@angular/material/dialog';
import { MembersService } from '../../service/members.service';
import { PATH } from '../../../../constants/routing/path';
import { TeamService } from '../../service/team.service';
import { MatSelectionList } from '@angular/material/list';

@Component({
  selector: 'app-my-team',
  templateUrl: './my-team.component.html',
  styleUrl: './my-team.component.scss',
})
export class MyTeamComponent {
  @Input() public myTeam!: Team;
  @Input() public myMembers!: User[];
  @Output() updateResources = new EventEmitter<void>();

  @ViewChild(MatSelectionList) selectedMember!: MatSelectionList;

  constructor(
    private readonly _dialogService: MatDialog,
    private readonly _membersService: MembersService,
    private readonly _teamsService: TeamService
  ) {}

  public removeMembers() {
    const body = {
      members: this.selectedMember.selectedOptions.selected.map(
        option => option.value
      ),
    };
    this._membersService.removeMembers(body).subscribe(() => {
      this.updateResources.emit();
    });
  }

  public createAndEditTeam() {
    this._dialogService
      .open(CreateTeamComponent, {
        width: MatDialogSize.SMALL,
        data: this.myTeam,
      })
      .afterClosed()
      .subscribe({
        next: (result: boolean) => {
          if (result) {
            this.updateResources.emit();
          }
        },
      });
  }

  public closeTeam() {
    const body = this.myTeam;
    this._teamsService.closeTeam(body).subscribe({
      next: () => {
        this.updateResources.emit();
      },
    });
  }

  public downloadList() {
    const body = {
      members: this.myMembers.map(u => u.id),
    };
    this._membersService.downloadMembersPdfDocument(body).subscribe({
      next: res => {
        const url = window.URL.createObjectURL(res);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'members.pdf'; // set the desired file name
        a.click();
        window.URL.revokeObjectURL(url); // free memory
      },
    });
  }

  protected readonly PATH = PATH;
}
