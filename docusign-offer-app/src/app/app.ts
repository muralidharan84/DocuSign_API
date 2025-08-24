import { Component, signal } from '@angular/core';
import { RichTextboxComponent } from './rich-textbox/rich-textbox.component';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { PdfService } from './core/services/pdfNotify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  constructor(private pdfService: PdfService){}

  file:string = "";
  ngOnInit(): void {
    debugger;
    this.pdfService.pdfUrl$.subscribe((url:any) => {
      this.file = url;
    });
  }


}
