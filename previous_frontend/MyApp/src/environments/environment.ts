const DEFAULT_URL = 'http://localhost:5095';
export const environment = {
  production: false,
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
