import { Participant } from '../participants/participants';

export interface Purpose {
  id: string;
  title: string;
  startDate: string;
  endDate: string;
  amount: number;
  isCompleted: boolean;
  participants: string[];
}
