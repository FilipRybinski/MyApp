import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../../../../interfaces/account/user';
import { MembersService } from '../../service/members.service';
import { MatSelectionList } from '@angular/material/list';
import { TeamService } from '../../service/team.service';
import { Team } from '../../../../interfaces/team/team';
import { MatDialog } from '@angular/material/dialog';
import { CreateTeamComponent } from '../../dialogs';
import { MatDialogSize } from '../../../../constants/MatDialogSize';
import { StoreService } from '../../../shared/service/store.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrl: './management.component.scss',
})
export class ManagementComponent implements OnInit {
  public availableMembers!: User[];
  public myTeam!: Team;
  public myMembers!: User[];
  public listView: boolean = true;
  @ViewChild(MatSelectionList) selectedMember!: MatSelectionList;

  constructor(
    private readonly _membersService: MembersService,
    private readonly _teamService: TeamService,
    private readonly _dialogService: MatDialog,
    private readonly _storeService: StoreService
  ) {}

  ngOnInit(): void {
    this.getAvailableMembers();
    this.getMyTeamResources();
  }

  public inviteMembers() {
    const body = {
      members: this.selectedMember.selectedOptions.selected.map(
        option => option.value
      ),
    };
    console.log(body);
    this._membersService.inviteMembers(body).subscribe(() => {
      this.getAvailableMembers();
      this.getMyTeamResources();
    });
  }

  public createTeam() {
    this._dialogService
      .open(CreateTeamComponent, {
        width: MatDialogSize.SMALL,
      })
      .afterOpened()
      .subscribe({
        next: () => {
          this.getMyTeamResources();
        },
      });
  }

  private getAvailableMembers(): void {
    this._membersService
      .getAvailableMembers()
      .subscribe({ next: res => (this.availableMembers = res) });
  }

  private getMyTeamResources(): void {
    this._teamService.getMyTeam().subscribe({
      next: team => {
        this.myTeam = team;
        if (this._storeService.user) {
          this._membersService
            .getMyTeamMembers(this._storeService?.user.id)
            .subscribe({ next: members => (this.myMembers = members) });
        }
      },
    });
  }
}
