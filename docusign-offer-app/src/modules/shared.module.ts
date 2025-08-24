// import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { ReactiveFormsModule } from '@angular/forms';
// import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
// import { SpinnerComponent } from '../common/spinner/spinner.component';
// import { RichTextboxComponent } from '../app/rich-textbox/rich-textbox.component';

// @NgModule({
//   declarations: [
//     RichTextboxComponent,   
//     SpinnerComponent
//   ],
//   imports: [
//     CommonModule,
//     ReactiveFormsModule,
//     CKEditorModule         
//   ],
//   exports: [
//     RichTextboxComponent,
//     SpinnerComponent    
//   ]
// })
// export class SharedModule {}


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { SpinnerComponent } from '../common/spinner/spinner.component';
import { RichTextboxComponent } from '../app/rich-textbox/rich-textbox.component';
import { PdfViewerComponent } from '../common/pdf-viewer/pdf-viewer.component';
import { HeaderComponent } from '../common/header/header.component';

@NgModule({
  declarations: [
    SpinnerComponent,
    RichTextboxComponent,
    PdfViewerComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CKEditorModule
  ],
  exports: [
    // export so they can be used anywhere
    SpinnerComponent,
    RichTextboxComponent,
    PdfViewerComponent,
    HeaderComponent,

    // export Angular modules too
    CommonModule,
    ReactiveFormsModule,
    CKEditorModule
  ]
})
export class SharedModule {}
