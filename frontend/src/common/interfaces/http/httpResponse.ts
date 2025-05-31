export interface HttpResponse<T> {
  data: T | null;
  isSuccess: boolean;
  isFailure: boolean;
  error: Error | null;
}

export interface BasicHttpResponse {
  isSuccess: boolean;
  isFailure: boolean;
  error: Error | null;
}
