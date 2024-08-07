import { Injectable, signal, WritableSignal } from '@angular/core';
import { User } from '../../interfaces/account/user';
import { Subject } from 'rxjs';

type AuthUserType = User | null;

@Injectable()
export class AuthService {
  public isAuthChanged$: Subject<boolean> = new Subject<boolean>();
  public authUser: WritableSignal<AuthUserType> = signal<AuthUserType>(null);
  public isAuth: WritableSignal<boolean> = signal<boolean>(false);

  public set setAuthUser(user: AuthUserType) {
    this.isAuth.set(!!user);
    this.isAuthChanged$.next(!!user);
    this.authUser.set(user);
  }
}
