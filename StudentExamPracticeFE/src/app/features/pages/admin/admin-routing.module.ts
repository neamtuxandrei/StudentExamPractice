import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { StudentDetailsComponent } from './student-list/student-details/student-details.component';
import { StudentAddComponent } from './student-list/student-add/student-add.component';
import { StudentListComponent } from './student-list/student-list.component';

const routes: Routes = [
  {
    path: '', component: AdminComponent,
    children: [
      { path: '', redirectTo: 'student', pathMatch: 'full' },
      {
        path: 'student',
        children: [
          {path: '', component: StudentListComponent, pathMatch: 'full'},
          {path: 'add', component: StudentAddComponent},
          {path: ':id', component: StudentDetailsComponent}
        ]
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
