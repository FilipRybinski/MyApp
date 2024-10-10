import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../service/account/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignUp } from '../../../../interfaces/account/signUp';
import { Router } from '@angular/router';
import { PATH } from '../../../../constants/routing/path';
import { AlertService } from '../../../../service/alert/alert.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
})
export class SignupComponent implements OnInit {
  public form!: FormGroup;
  public isLoading: boolean = false;

  constructor(
    private readonly accountService: AccountService,
    private readonly fb: FormBuilder,
    private readonly router: Router,
    private readonly alertService: AlertService
  ) {}

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
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
    this.isLoading = true;
    const body: SignUp = {
      email: this.form.value.email,
      username: this.form.value.username,
      name: this.form.value.name,
      surname: this.form.value.surname,
      password: this.form.value.password,
    };
    this.accountService.signUp(body).subscribe({
      next: () => {
        this.isLoading = false;
        this.alertService.handleSuccess('Sign up successfully');
        this.router.navigate([PATH.ACCOUNT, PATH.SIGN_IN]);
      },
      error: err => {
        this.alertService.handleSuccess(err);
        this.isLoading = false;
      },
    });
  }
}
