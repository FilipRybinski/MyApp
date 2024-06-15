import { Component, OnInit } from '@angular/core';
import { User } from '../../../../interfaces/account/user';
import { MembersService } from '../../service/members.service';
import { TeamService } from '../../service/team.service';
import { Team } from '../../../../interfaces/team/team';
import { StoreService } from '../../../shared/service/store.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrl: './management.component.scss',
})
export class ManagementComponent implements OnInit {
  public availableMembers!: User[];
  public myTeam!: Team;
  public myMembers!: User[];
  public isLoading: boolean = true;

  constructor(
    private readonly _membersService: MembersService,
    private readonly _teamService: TeamService,
    private readonly _storeService: StoreService
  ) {}

  ngOnInit(): void {
    this.initialize();
  }

  public handleUpdateResources() {
    this.initialize();
  }

  public initialize() {
    this.isLoading = true;
    forkJoin({
      availableMembers: this._membersService.getAvailableMembers(),
      myTeam: this._teamService.getMyTeam(),
    }).subscribe({
      next: (data: { myTeam: Team; availableMembers: User[] }) => {
        this.availableMembers = data.availableMembers;
        this.myTeam = data.myTeam;
        this._membersService
          .getMyTeamMembers(this._storeService?.user?.id ?? '')
          .subscribe({
            next: res => {
              this.myMembers = res;
              this.isLoading = false;
            },
            error: () => (this.isLoading = false),
          });
      },
    });
  }
}
