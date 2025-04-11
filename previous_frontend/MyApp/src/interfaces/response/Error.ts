export interface ErrorResponse {
  statusCode: number;
  code: string;
  description: string;
  errorDetails: ErrorDetails[] | null;
}

export interface ErrorDetails {
  propertyName: string;
  errorMessage: string;
}
