import { Injectable, signal, WritableSignal } from '@angular/core';
import { User } from '../../interfaces/account/user';

type AuthUserType = User | null;

@Injectable()
export class AuthService {
  public authUser: WritableSignal<AuthUserType> = signal<AuthUserType>(null);
  public isAuth: WritableSignal<boolean> = signal<boolean>(false);

  public set setAuthUser(user: AuthUserType) {
    this.authUser.set(user);
    user ? this.isAuth.set(true) : this.isAuth.set(false);
  }
}
