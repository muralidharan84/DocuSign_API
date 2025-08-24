import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JobOfferRequest } from '../models/job-offer.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly baseUrl = 'https://localhost:44345/api'; 
  
  constructor(private http: HttpClient) {}

  sendJobOffer(request: JobOfferRequest,url:string): Observable<any> {
    let document = {"RecipientEmail": request.candidateEmail, "RecipientName": request.candidateName, "Content": request.content, "FileName": "JobOffer_"+ request.candidateName}
    return this.http.post(`${this.baseUrl}/${url}`, document,{
            headers: { 'Content-Type': 'application/json' } 
    });
  }

  generateJobOffer(request: JobOfferRequest,url:string): Observable<any> {
    return this.http.post(`${this.baseUrl}/${url}`, request,{
      headers: { 'Content-Type': 'application/json' } 
    });
  }
}
