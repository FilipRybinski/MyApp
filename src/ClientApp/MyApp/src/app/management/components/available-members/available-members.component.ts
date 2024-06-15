import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { MatSelectionList } from '@angular/material/list';
import { FormControl } from '@angular/forms';
import { User } from '../../../../interfaces/account/user';
import { MembersService } from '../../service/members.service';
import { debounce, timer } from 'rxjs';
import { Team } from '../../../../interfaces/team/team';

@Component({
  selector: 'app-available-members',
  templateUrl: './available-members.component.html',
  styleUrl: './available-members.component.scss',
})
export class AvailableMembersComponent implements OnInit {
  @Input() myTeam!: Team;
  @Input() availableMembers!: User[];
  @Output() updateResources = new EventEmitter<void>();

  public listView: boolean = true;
  public searchForUser = new FormControl('');
  public availableMembersOptions!: User[];
  @ViewChild(MatSelectionList) selectedMember!: MatSelectionList;

  constructor(private readonly _membersService: MembersService) {}

  ngOnInit(): void {
    this.subscribeForSearchUser();
  }

  public inviteMembers() {
    console.log(this.searchForUser.value);
    const body = {
      members: this.selectedMember.selectedOptions.selected.map(
        option => option.value
      ),
    };
    this._membersService.inviteMembers(body).subscribe(() => {
      this.updateResources.emit();
    });
  }

  public displayUser(user: User): string {
    return user ? `${user.name} ${user.surname}` : '';
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
