import { Injectable, signal, WritableSignal } from '@angular/core';
import { User } from '../../../../interfaces/account/user';

type AuthUserType = User | null;

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authUser: WritableSignal<AuthUserType> = signal<AuthUserType>(null);
  public isAuth: WritableSignal<boolean> = signal<boolean>(false);

  public get getAuthUser(): AuthUserType {
    return this.authUser();
  }

  public set setAuthUser(user: AuthUserType) {
    this.authUser.set(user);
  }
}
