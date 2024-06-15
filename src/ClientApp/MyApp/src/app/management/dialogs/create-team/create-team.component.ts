import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TeamService } from '../../service/team.service';
import { Team } from '../../../../interfaces/team/team';
import { SnackBarService } from '../../../shared/service/snack-bar.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrl: './create-team.component.scss',
})
export class CreateTeamComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Team,
    private readonly _fb: FormBuilder,
    private readonly _teamService: TeamService,
    private readonly _snackBarService: SnackBarService,
    private readonly _dialogRef: MatDialogRef<CreateTeamComponent>
  ) {}

  ngOnInit(): void {
    this.form = this._fb.group({
      name: [this.data?.name ?? '', Validators.required],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    const body: Team = {
      name: this.form.value.name,
    };
    if (this.data) {
      this._teamService.updateMyTeam(body).subscribe({
        next: () => {
          this._snackBarService.open('Team updated successfully');
          this._dialogRef.close(true);
        },
        error: () => {
          this._snackBarService.open('Team already exists');
          this._dialogRef.close(false);
        },
      });
    } else {
      this._teamService.createTeam(body).subscribe({
        next: () => {
          this._snackBarService.open('Team created successfully');
          this._dialogRef.close(true);
        },
        error: () => {
          this._snackBarService.open('Team already exists');
          this._dialogRef.close(false);
        },
      });
    }
  }
}
