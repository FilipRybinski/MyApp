import { Startup } from '../interfaces/state/startup';
import { StartupReducer } from './startup/startup.reducer';

export const AppState = {
  reducers: {
    startup: StartupReducer,
  },
};

export interface AppState {
  startup: Startup;
}
