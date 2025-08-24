import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

@NgModule({
  imports: [
      CKEditorModule   // import CKEditor here
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
})
export class AppModule { }
