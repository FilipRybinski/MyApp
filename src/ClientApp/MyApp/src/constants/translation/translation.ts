import { Language } from '../../interfaces/translation/translation';
import { Languages } from '../../enums/languages';

export const translationConfig = {
  directory: './assets/i18n/',
  extension: '.json',
};

export const availableLanguages: Language[] = [
  {
    language: Languages.ENG,
    icon: 'bg-english_language',
    name: 'English',
  },
  {
    language: Languages.PL,
    icon: 'bg-polish_language',
    name: 'Polish',
  },
];
