import { LOCALE_ID, NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';

import { SharedModule } from '../modules/shared.module';
import { OfferComponent } from './features/job-offer/job-offer.component';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { SpinnerInterceptor } from './core/interceptors/spinner.interceptor';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    App,
    OfferComponent   // only feature-specific components
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    { provide: LOCALE_ID, useValue: 'en' },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptor, multi: true },
    provideHttpClient(),
    provideAnimations(),
  ],
  bootstrap: [App]
})
export class AppModule {}
