import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { ApiAuthorizationModule } from 'src/app/features/api-authorization/api-authorization.module';

@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ApiAuthorizationModule,
  ], 
  exports: [
    NavBarComponent
  ]
})
export class CoreModule { }
