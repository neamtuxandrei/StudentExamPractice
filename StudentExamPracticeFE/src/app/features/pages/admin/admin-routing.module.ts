import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { StudentDetailsComponent } from './student-list/student-details/student-details.component';

const routes: Routes = [
  { path: '', component: AdminComponent },
  { path: 'student/:id', component: StudentDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
