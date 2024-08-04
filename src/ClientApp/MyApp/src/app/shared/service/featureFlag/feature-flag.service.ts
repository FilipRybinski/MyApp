import { Injectable, signal, WritableSignal } from '@angular/core';
import { FeatureFlags } from '../../../../interfaces/featureFlags/featureFlags';

type FeatureFlagsType = FeatureFlags | null;

@Injectable()
export class FeatureFlagService {
  private featureFlags: WritableSignal<FeatureFlagsType> =
    signal<FeatureFlagsType>(null);

  public get getFeatureFlags(): FeatureFlagsType {
    return this.featureFlags();
  }

  public set setFeatureFlags(flags: FeatureFlagsType) {
    this.featureFlags.set(flags);
  }
}
