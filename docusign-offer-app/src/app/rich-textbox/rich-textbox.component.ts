import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';



@Component({
  selector: 'app-rich-textbox',
  templateUrl: './rich-textbox.component.html',
  styleUrls:['./rich-textbox.component.css'],
  standalone: false,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => RichTextboxComponent),
      multi: true,
    },
  ],
})
export class RichTextboxComponent implements ControlValueAccessor {
  public Editor = ClassicEditor;
   public editorConfig = {
    // toolbar: [
    //   'heading', '|',
    //   'bold', 'italic', 'underline', 'strikethrough',
    //   'link', 'bulletedList', 'numberedList', '|',
    //   'blockQuote', 'insertTable', 'undo', 'redo'
    // ],
    placeholder: 'Type your content here...',
    language: {
      ui: 'en',
      content: 'en'
    }
  };
  public value: string = '';
  public isDisabled = false;

  public onChange: (value: any) => void = () => {};
  public onTouched: () => void = () => {};

  // Called by Angular to write value to component
  writeValue(value: any): void {
    this.value = value || '';
  }

  // Called by Angular to register change callback
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  // Called by Angular to register touched callback
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  onReady(editor: any) {
    if (this.value) {
    editor.setData(this.value);
  }
  // Subscribe to CKEditor's native data change event
  editor.model.document.on('change:data', () => {
    const data = editor.getData();
    this.value = data;
    this.onChange(data); // Updates Angular form control
  });
}
}
