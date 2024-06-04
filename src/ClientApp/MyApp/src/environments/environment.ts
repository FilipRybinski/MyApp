const DEFAULT_URL = 'http://localhost:5095';
export const environment = {
  production: false,
  URL: {
    SIGN_IN: `${DEFAULT_URL}/Users/SignIn`,
    SIGN_UP: `${DEFAULT_URL}/Users/SignUp`,
  },
};
