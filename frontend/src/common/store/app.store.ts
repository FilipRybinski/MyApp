import { FeatureFlags } from '../interfaces/featureFlags/featureFlags';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { Identity } from '../interfaces/identity/identity';

interface AppStore {
  featureFlags: FeatureFlags;
  identity: Identity | null;
}

const initialState: AppStore = {
  featureFlags: {
    feeTracker: false,
  },
  identity: null,
};

export const AppStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => ({
    attachInitialData(
      identity: Identity | null,
      featureFlags: FeatureFlags | null
    ): void {
      patchState(store, {
        featureFlags: featureFlags ?? initialState.featureFlags,
        identity,
      });
    },
    attachIdentity(identity: Identity | null): void {
      patchState(store, {
        identity,
      });
    },
    detachIdentity(): void {
      patchState(store, {
        identity: null,
      });
    },
  }))
);
