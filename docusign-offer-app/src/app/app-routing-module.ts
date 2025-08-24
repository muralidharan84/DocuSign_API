import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfferComponent } from './features/job-offer/job-offer.component';

const routes: Routes = [
  // { path: 'jobs', component: OfferComponent },
  // { path: 'applicants', component: OfferComponent },
  // { path: 'dashboard', component: OfferComponent },
  // { path: '', redirectTo: '/jobs', pathMatch: 'full' }, // default route
  // { path: '**', redirectTo: '/jobs' } // wildcard/fallback
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
