import { Component, OnInit } from '@angular/core';
import { SpinnerService } from '../../app/core/services/spinner.service';  

@Component({
  selector: 'app-spinner',
  standalone: false,
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})

export class SpinnerComponent implements OnInit {
  isLoading = false;

  constructor(private spinnerService: SpinnerService) {}

  ngOnInit(): void {
    this.spinnerService.spinnerObservable.subscribe(state => {
      console.log('Spinner state:', state); 
      this.isLoading = state;
    });
  }
}