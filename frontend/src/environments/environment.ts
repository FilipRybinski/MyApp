const DEFAULT_URL = 'http://localhost:5095';
export const environment = {
  production: true,
  URL: {
    IDENTITY: {
      SIGN_IN: `${DEFAULT_URL}/Identity/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Identity/SignUp`,
      IS_AUTHORIZED: `${DEFAULT_URL}/Identity/IsAuthorized`,
      RESET_PASSWORD_REQUEST: `${DEFAULT_URL}/Identity/ResetPasswordRequest`,
      Activation: `${DEFAULT_URL}/Identity/Activation`,
      LOGOUT: `${DEFAULT_URL}/Identity/Logout`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
