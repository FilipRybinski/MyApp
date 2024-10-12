import {
  BODY_SELECTOR,
  LOADING_ANIMATION_CLASS,
  LOADING_ANIMATION_SELECTOR,
} from '../constants/selectors/selectors-variable';

export const handleLoadingAnimation = () => {
  const loadingScreen = document.getElementById(LOADING_ANIMATION_SELECTOR);
  const body = document.getElementById(BODY_SELECTOR);
  body && body.classList.remove(LOADING_ANIMATION_CLASS);
  loadingScreen && loadingScreen.remove();
};
