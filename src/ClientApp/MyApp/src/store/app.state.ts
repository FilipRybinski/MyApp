import { Startup } from '../interfaces/state/startup';
import { StartupReducer } from './startup/startup.reducer';
import { StartupEffects } from './startup/startup.effects';

export const AppStore = {
  reducers: {
    startup: StartupReducer,
  },
  effects: [StartupEffects],
};

export interface AppState {
  startup: Startup;
}
