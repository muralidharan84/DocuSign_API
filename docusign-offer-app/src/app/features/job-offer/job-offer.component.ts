import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { JobOfferService } from './job-offer.service';
import { RichTextboxComponent } from '../../rich-textbox/rich-textbox.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { PdfService } from '../../core/services/pdfNotify.service';
import { SpinnerService } from '../../core/services/spinner.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-job-offer',
  standalone: false,
  templateUrl: './job-offer.component.html',
  styleUrl: './job-offer.component.css'
})
export class OfferComponent {


  offerForm: FormGroup;
  submitted = false;
  btnSubmitText: string = "Generate Offer Letter";

  constructor(private fb: FormBuilder,
    private jobOfferService: JobOfferService,
    private pdfService: PdfService,
    private spinnerService: SpinnerService,
    private toastr: ToastrService) {
    this.offerForm = this.fb.group({
      candidateName: ['', Validators.required],
      candidateEmail: ['', [Validators.required, Validators.email]],
      content: ['', Validators.required]
    });
  }
  commandName: string = "Generate";
  onSubmit() {
    this.submitted = true;
    if (this.offerForm.invalid) {
      return;
    }
    switch (this.commandName) {
      case "Generate":
        this.spinnerService.show();
        this.jobOfferService.generateJobOffer(this.offerForm.value, "Reports/generate").subscribe({
          next: (res) => {
            this.spinnerService.hide();
            this.toastr.success('Job offer submitted successfully!', 'Success');
            this.pdfService.setPdfUrl(res.url);
            sessionStorage.setItem("offer1", res.url);
            if (res.url) {
              this.btnSubmitText = "Send for Signature";
              this.commandName = "sendForSignature";
            }

          },

          error: (err) => { this.spinnerService.hide(); this.toastr.error(err.message,'Error');  }
        });
        break;
      case "sendForSignature":
        this.spinnerService.show();
        this.jobOfferService.sendJobOffer(this.offerForm.value, "Envelopes/send").subscribe({
          next: (response) => {
            this.spinnerService.hide();
            this.toastr.success("Document sent to the receipient for signature - EnvelopId: " + response.envelopeLog.envelopeId, 'Success');
            sessionStorage.setItem("envolopeDetails", response.envelopeLog);
          },
          error: (err) => { this.spinnerService.hide(); this.toastr.error(err.message,'Error'); }
        });
        break;
      default:
        this.toastr.error("Others", 'Error');
    }
  }
}
