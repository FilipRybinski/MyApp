import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../service/account/account.service';
import { SignUp } from '../../../../interfaces/account/signUp';
import { Router } from '@angular/router';
import { AuthService } from '../../../../service/auth/auth.service';
import { getHomeUrl } from '../../../../constants/routing/path';
import { AlertService } from '../../../../service/alert/alert.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss',
})
export class SigninComponent implements OnInit {
  public form!: FormGroup;
  public isLoading: boolean = false;

  constructor(
    private readonly fb: FormBuilder,
    private readonly accountService: AccountService,
    private readonly authService: AuthService,
    private readonly router: Router,
    private readonly alertService: AlertService
  ) {}

  public ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
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
    this.isLoading = true;
    this.accountService.signIn(body).subscribe({
      next: user => {
        this.alertService.handleSuccess('Sign in successfully');
        this.isLoading = false;
        this.router
          .navigate(getHomeUrl())
          .then(() => (this.authService.setAuthUser = user));
      },
      error: err => {
        this.alertService.handleError(err);
        this.isLoading = false;
      },
    });
  }
}
