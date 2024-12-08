import { User } from './user';

export interface LoggedInUser {
  user: User | null;
  isAuth: boolean;
}
