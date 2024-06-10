import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../service/account.service';
import { SignUp } from '../../../../interfaces/signUp';
import { Router } from '@angular/router';
import { PATH } from '../../../../constants/routing/path';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss',
})
export class SigninComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private readonly _fb: FormBuilder,
    private readonly _accountService: AccountService,
    private readonly _router: Router,
    private readonly _snackBar: MatSnackBar
  ) {}

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this._fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    const body: SignUp = {
      ...this.form.value,
    };
    this._accountService.signIn(body).subscribe({
      next: () => {
        this._snackBar.open('Login successfully!');
        this._router.navigate([PATH.DASHBOARD]);
      },
      error: err => console.log(err),
    });
  }
}
