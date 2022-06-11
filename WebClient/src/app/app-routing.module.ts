import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImageClassificationComponent } from './components/image-classification/image-classification.component';

const routes: Routes = [{
  path: 'image-classification',
  component: ImageClassificationComponent
}, {
  path: '',
  redirectTo: 'image-classification',
  pathMatch: 'full'
},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
