export interface HttpError {
  statusCode: number;
  code: string;
  description: string;
  errorDetails: HttpErrorDetails[] | null;
}

export interface HttpErrorDetails {
  propertyName: string;
  errorMessage: string;
}
