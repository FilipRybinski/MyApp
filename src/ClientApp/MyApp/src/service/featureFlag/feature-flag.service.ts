import { Injectable, signal, WritableSignal } from '@angular/core';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';

type FeatureFlagsType = FeatureFlags | null;

@Injectable()
export class FeatureFlagService {
  private featureFlags: WritableSignal<FeatureFlagsType> =
    signal<FeatureFlagsType>(null);

  public set setFeatureFlags(flags: FeatureFlagsType) {
    this.featureFlags.set(flags);
  }

  public isFeatureFlagEnabled(featureFlag: keyof FeatureFlags): boolean {
    const featureFlags = this.featureFlags();
    if (featureFlags) {
      return featureFlags[featureFlag];
    }
    return false;
  }
}
