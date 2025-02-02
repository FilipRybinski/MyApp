const DEFAULT_URL = 'https://api.myappzone.pl';
export const environment = {
  production: true,
  URL: {
    USERS: {
      SIGN_IN: `${DEFAULT_URL}/Users/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Users/SignUp`,
      IS_AUTHORIZED: `${DEFAULT_URL}/Users/IsAuthorized`,
      LOGOUT: `${DEFAULT_URL}/Users/Logout`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
