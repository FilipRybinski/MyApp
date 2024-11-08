import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../service/account/account.service';
import { SignUp } from '../../../../interfaces/account/signUp';
import { Router } from '@angular/router';
import { getHomeUrl } from '../../../../constants/routing/path';
import { AlertService } from '../../../../service/alert/alert.service';
import { AppStore } from '../../../../store/app.store';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
})
export class SigninComponent implements OnInit {
  private readonly appStore = inject(AppStore);
  private readonly fb = inject(FormBuilder);
  private readonly accountService = inject(AccountService);
  private readonly router = inject(Router);
  private readonly alertService = inject(AlertService);

  public form!: FormGroup;
  public isLoading: boolean = false;

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
          .then(() => this.appStore.authorizeUser(user));
      },
      error: err => {
        this.alertService.handleError(err);
        this.isLoading = false;
      },
    });
  }
}
