const DEFAULT_URL = 'http://localhost:5095';
export const environment = {
  production: false,
  URL: {
    TEAM: {
      CREATE_TEAM: `${DEFAULT_URL}/Team/CreateTeam`,
      DELETE_TEAM: `${DEFAULT_URL}/Team/CloseMyTeam`,
      UPDATE_TEAM: `${DEFAULT_URL}/Team/UpdateMyTeam`,
      GET_MY_TEAM: `${DEFAULT_URL}/Team/GetMyTeam`,
      UPDATE_MY_TEAM: `${DEFAULT_URL}/Team/UpdateMyTeam`,
    },
    ACCOUNT: {
      SIGN_IN: `${DEFAULT_URL}/Users/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Users/SignUp`,
      LOG_OUT: `${DEFAULT_URL}/Users/LogOut`,
      GET_MY_TEAM: `${DEFAULT_URL}/Team/GetMyTem`,
      GET_MY_ACCOUNT: `${DEFAULT_URL}/Users/GetMyAccount`,
    },
    MEMBERS: {
      GET_AVAILABLE_MEMBERS: `${DEFAULT_URL}/Member/GetAvailableMembers`,
      GET_MY_TEAM_MEMBERS: `${DEFAULT_URL}/Member/GetMyTeamMembers`,
      INVITE_MEMBERS: `${DEFAULT_URL}/Member/InviteMembers`,
      FIND_AVAILABLE_MEMBERS: `${DEFAULT_URL}/Member/FindAvailableMember`,
    },
    PRINT: {
      PRINT_MEMBERS_PDF_DOCUMENT: `${DEFAULT_URL}/Print/PrintMembersPdfDocument`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
  },
};
