import { FeatureFlags } from '../featureFlags/featureFlags';
import { LoggedInUser } from '../account/loggedInUser';

export interface Startup {
  featureFlags: FeatureFlags;
  loggedInUser: LoggedInUser;
  isLoading: boolean;
}
