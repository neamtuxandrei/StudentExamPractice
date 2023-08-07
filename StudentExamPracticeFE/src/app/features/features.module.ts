import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './pages/admin/admin.component';
import { TableModule } from 'primeng/table';



@NgModule({
  declarations: [
    AdminComponent
  ],
  imports: [
    CommonModule,
    TableModule
  ]
})
export class FeaturesModule { }
