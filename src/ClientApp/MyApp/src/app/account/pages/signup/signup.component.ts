import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../service/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignUp } from '../../../../interfaces/account/signUp';
import { Router } from '@angular/router';
import { PATH } from '../../../../constants/routing/path';
import { SnackBarService } from '../../../shared/service/snack-bar.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
})
export class SignupComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private readonly _accountService: AccountService,
    private readonly _fb: FormBuilder,
    private readonly _router: Router,
    private readonly _snackBarService: SnackBarService
  ) {}

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this._fb.group({
      email: ['', [Validators.required, Validators.email]],
      username: ['', [Validators.required]],
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  public submit(): void {
    if (!this.form.valid) {
      return;
    }
    const body: SignUp = {
      email: this.form.value.email,
      username: this.form.value.username,
      name: this.form.value.name,
      surname: this.form.value.surname,
      password: this.form.value.password,
    };
    this._accountService.signUp(body).subscribe({
      next: () => {
        this._snackBarService.open('Account created successfully!');
        this._router.navigate([PATH.ACCOUNT, PATH.SIGN_IN]);
      },
      error: err => console.log(err),
    });
  }
}
