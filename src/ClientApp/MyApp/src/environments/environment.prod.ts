const DEFAULT_URL = 'https://myappzone.pl:8082';
export const environment = {
  production: true,
  URL: {
    TEAM: {
      CREATE_TEAM: `${DEFAULT_URL}/Team/CreateTeam`,
      DELETE_TEAM: `${DEFAULT_URL}/Team/CloseMyTeam`,
      INVITE_MEMBERS: `${DEFAULT_URL}/Team/InviteMembers`,
      UPDATE_TEAM: `${DEFAULT_URL}/Team/UpdateMyTeam`,
    },
    ACCOUNT: {
      SIGN_IN: `${DEFAULT_URL}/Users/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Users/SignUp`,
      GET_MY_TEAM: `${DEFAULT_URL}/Team/GetMyTem`,
      GET_MY_ACCOUNT: `${DEFAULT_URL}/Users/GetMyAccount`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
