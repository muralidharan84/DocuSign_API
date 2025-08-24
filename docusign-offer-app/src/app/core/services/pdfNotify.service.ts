import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PdfService {
  private pdfUrlSource = new BehaviorSubject<string | null>(null);
  pdfUrl$ = this.pdfUrlSource.asObservable();

  setPdfUrl(url: string) {
    this.pdfUrlSource.next(url);
  }
}