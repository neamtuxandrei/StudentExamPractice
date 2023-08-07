import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Router, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/pages/home/home.component';
import { CounterComponent } from './features/pages/counter/counter.component';
import { FetchDataComponent } from './features/pages/fetch-data/fetch-data.component';
import { AuthorizeGuard } from 'src/app/core/guard/authorize.guard';
import { AdminComponent } from './features/pages/admin/admin.component';
import { AdminGuard } from './core/guard/admin.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AdminGuard] },  
]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
