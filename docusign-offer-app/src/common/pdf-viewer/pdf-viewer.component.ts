
import { Component, ElementRef, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import WebViewer from '@pdftron/pdfjs-express';
import { PdfService } from '../../app/core/services/pdfNotify.service';  

@Component({
  selector: 'app-pdf-viewer',
  templateUrl: './pdf-viewer.component.html',
  styleUrls: ['./pdf-viewer.component.css'],
  standalone: false,
})

export class PdfViewerComponent implements OnInit {

constructor(private pdfService: PdfService) {}

  ngOnInit(): void {
    debugger;
    this.pdfService.pdfUrl$.subscribe((url:any) => {
      this.file = url;
    });
  }
  @ViewChild('viewer') viewerRef!: ElementRef;

   // Allow passing in a file path dynamically
  @Input() file: string = '/assets/Sample.pdf';
  
   private instance: any; // store WebViewer instance

  async ngAfterViewInit(): Promise<void> {
    this.instance = await WebViewer(
      {
        path: '/assets/webviewer', // path to copied public folder
        initialDoc: this.file,
      },
      this.viewerRef.nativeElement
    );

    const { documentViewer } = this.instance.Core;

    documentViewer.addEventListener('documentLoaded', () => {
      console.log('Document loaded:', this.file);
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['file'] && this.instance) {
      console.log('Loading new file:', this.file);
      this.instance.loadDocument(this.file);
    }
  }
}