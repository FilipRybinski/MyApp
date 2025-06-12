const DEFAULT_URL = 'http://localhost:5170';
export const environment = {
  production: true,
  URL: {
    IDENTITY: {
      SIGN_IN: `${DEFAULT_URL}/Identity/SignIn`,
      SIGN_UP: `${DEFAULT_URL}/Identity/SignUp`,
      IS_AUTHORIZED: `${DEFAULT_URL}/Identity/IsAuthorized`,
      RESET_PASSWORD_REQUEST: `${DEFAULT_URL}/Identity/ResetPasswordRequest`,
      RESET_PASSWORD_SUBMISSION: `${DEFAULT_URL}/Identity/ResetPasswordSubmission`,
      Activation: `${DEFAULT_URL}/Identity/Activation`,
      LOGOUT: `${DEFAULT_URL}/Identity/Logout`,
    },
    FEATURE_FLAGS: `${DEFAULT_URL}/FeatureFlags/GetFeatureFlags`,
    FEE_TRACKER: {
      ADD_FEE_PURPOSE: `${DEFAULT_URL}/FeeTracker/AddFeePurpose`,
      DELETE_FEE_PURPOSE: `${DEFAULT_URL}/FeeTracker/DeleteFeePurpose`,
      GET_FEE_PURPOSE: `${DEFAULT_URL}/FeeTracker/GetFeePurposes`,
      ADD_FEE_CONTRIBUTOR: `${DEFAULT_URL}/FeeTracker/AddContributor`,
      GET_FEE_CONTRIBUTOR: `${DEFAULT_URL}/FeeTracker/GetContributors`,
      ATTACH_CONTRIBUTOR: `${DEFAULT_URL}/FeeTracker/AttachParticipant`,
      DETACH_CONTRIBUTOR: `${DEFAULT_URL}/FeeTracker/DetachParticipant`,
      GET_FEE_PARTICIPANTS: `${DEFAULT_URL}/FeeTracker/GetParticipantDetails`,
      MARK_AS_COMPLETED: `${DEFAULT_URL}/FeeTracker/MarkAsCompletedFeePurpose`,
      MARK_AS_PAID: `${DEFAULT_URL}/FeeTracker/MarkAsPaid`,
    },
  },
};
