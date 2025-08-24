// spinner.service.ts
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SpinnerService {
  private count = 0;
  private spinner$ = new BehaviorSubject<boolean>(false);

  get spinnerObservable() {
    return this.spinner$.asObservable();
  }
  show() {
    this.count++;
    if (this.count === 1) {
      this.spinner$.next(true);
    }
  }
  hide() {
    if (this.count > 0) {
      this.count--;
      if (this.count === 0) {
        this.spinner$.next(false);
      }
    }
  }
}
