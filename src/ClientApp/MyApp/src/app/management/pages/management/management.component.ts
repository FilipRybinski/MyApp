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
import { FormControl } from '@angular/forms';
import { debounce, timer } from 'rxjs';

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

  public searchForUser = new FormControl('');
  public availableMembersOptions!: User[];
  @ViewChild(MatSelectionList) selectedMember!: MatSelectionList;

  constructor(
    private readonly _membersService: MembersService,
    private readonly _teamService: TeamService,
    private readonly _dialogService: MatDialog,
    private readonly _storeService: StoreService
  ) {}

  ngOnInit(): void {
    this.subscribeForSearchUser();
    this.getAvailableMembers();
    this.getMyTeamResources();
  }

  public inviteMembers() {
    console.log(this.searchForUser.value);
    const body = {
      members: this.selectedMember.selectedOptions.selected.map(
        option => option.value
      ),
    };
    this._membersService.inviteMembers(body).subscribe(() => {
      this.getAvailableMembers();
      this.getMyTeamResources();
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
            this.getMyTeamResources();
          }
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

  public reset() {
    this.searchForUser.patchValue('');
  }

  public displayFn(user: User): string {
    return user ? `${user.name} ${user.surname}` : '';
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

  private subscribeForSearchUser() {
    this.searchForUser.valueChanges.pipe(debounce(() => timer(500))).subscribe({
      next: value => {
        value &&
          this._membersService.findMembers(value).subscribe({
            next: users => {
              this.availableMembersOptions = users;
            },
          });
      },
    });
  }
}
