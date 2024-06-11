import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TeamService } from '../../service/team.service';
import { Team } from '../../../../interfaces/team/team';
import { SnackBarService } from '../../../shared/service/snack-bar.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrl: './create-team.component.scss',
})
export class CreateTeamComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private readonly _fb: FormBuilder,
    private readonly _teamService: TeamService,
    private readonly _snackBarService: SnackBarService,
    private readonly _dialogRef: MatDialogRef<CreateTeamComponent>
  ) {}

  ngOnInit(): void {
    this.form = this._fb.group({
      name: ['', Validators.required],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    const body: Team = {
      name: this.form.value.name,
    };
    this._teamService.createTeam(body).subscribe({
      next: () => {
        this._snackBarService.open('Team created successfully');
      },
      error: () => {
        this._snackBarService.open('Team already exists');
      },
    });
    this._dialogRef.close(true);
  }
}
