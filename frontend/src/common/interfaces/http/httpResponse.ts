export interface HttpResponse<T> {
  data: T | null;
  isSuccess: boolean;
  isFailure: boolean;
  error: Error | null;
}
