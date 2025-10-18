export interface Response<T> {
  data: T | null;
  isSuccess: boolean;
  isFailure: boolean;
  error: Error | null;
}
