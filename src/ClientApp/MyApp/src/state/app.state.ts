import { Startup } from '../interfaces/state/startup';
import { StartupReducer } from './startup/startup.reducer';
import { StartupEffects } from './startup/startup.effects';

export const AppState = {
  reducers: {
    startup: StartupReducer,
  },
  effects: [StartupEffects],
};

export interface AppState {
  startup: Startup;
}
