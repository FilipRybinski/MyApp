const DEFAULT_URL = 'https://api.myappzone.pl';
export const environment = {
  production: true,
  URL: {
    USERS: {
      SIGN_IN: `${DEFAULT_URL}/Identity/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Identity/SignUp`,
      IS_AUTHORIZED: `${DEFAULT_URL}/Identity/IsAuthorized`,
      LOGOUT: `${DEFAULT_URL}/Identity/Logout`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
