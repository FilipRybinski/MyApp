import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../service/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignUp } from '../../../../interfaces/signUp';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
})
export class SignupComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private readonly _accountService: AccountService,
    private readonly _fb: FormBuilder
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
    console.log(body);
    this._accountService.signUp(body).subscribe({
      next: res => console.log(res),
      error: err => console.log(err),
    });
  }
}
