const DEFAULT_IDENTITY_URL = 'https://identity.myappzone.pl';
const DEFAULT_FEATURE_FLAGS_URL = 'https://featureflags.myappzone.pl'
export const environment = {
  production: true,
  URL: {
    USERS: {
      SIGN_IN: `${DEFAULT_IDENTITY_URL}/Users/SignIn`,
      SIGN_UP: `${DEFAULT_IDENTITY_URL}/Users/SignUp`,
      IS_AUTHORIZED: `${DEFAULT_IDENTITY_URL}/Users/IsAuthorized`,
      LOGOUT: `${DEFAULT_IDENTITY_URL}/Users/Logout`,
    },
    FEATURE_FLAGS: `${DEFAULT_FEATURE_FLAGS_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
