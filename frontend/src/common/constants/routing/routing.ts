import { IDENTITY_ROUTING_PATH } from '../../../app/identity/routes/identity.routes';
import { HOME_ROUTING_PATH } from '../../../app/home/routes/home.routes';
import { FEE_TRACKER_ROUTING_PATH } from '../../../app/fee-tracker/routes/fee-tracker.routes';

export const GLOBAL_ROUTING_PATH = {
  ...IDENTITY_ROUTING_PATH,
  ...HOME_ROUTING_PATH,
  ...FEE_TRACKER_ROUTING_PATH,
  WILDCARD: '**',
};

export const getGlobalHomeUrl = (): string[] => {
  return [GLOBAL_ROUTING_PATH.HOME];
};
