import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './pages/admin/admin.component';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [
    AdminComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    ButtonModule
  ]
})
export class FeaturesModule { }
