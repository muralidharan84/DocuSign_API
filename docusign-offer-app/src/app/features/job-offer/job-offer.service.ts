import { Injectable } from '@angular/core';
import { ApiService } from '../../core/services/offer.service';
import { JobOfferRequest } from '../../core/models/job-offer.model';  
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobOfferService {
  constructor(private api: ApiService) {}

  sendJobOffer(request: JobOfferRequest,url:string): Observable<any> {
    return this.api.sendJobOffer(request,url);
  }

  generateJobOffer(request: JobOfferRequest,url:string): Observable<any> {
    return this.api.generateJobOffer(request,url);
  }
}
