import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService) {} 

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let message = 'An unexpected error occurred';
        
        if (error.status === 400 && error.error?.errors) {
          // ✅ Validation errors from backend
          message = Object.values(error.error.errors).join(', ');
        } else if (error.status === 0) {
          message = 'Network error - please check your connection';
        } else if (error.status >= 500) {
          message = 'Server error - please try again later';
        } else if (error.error?.message) {
          message = error.error.message;
        }
         this.toastr.error(message, 'Error');
        console.error('API Error:', message);
        return throwError(() => new Error(message));
      })
    );
  }
}
