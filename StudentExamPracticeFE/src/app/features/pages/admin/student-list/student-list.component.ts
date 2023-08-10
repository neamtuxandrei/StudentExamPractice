import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../student.service';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: Student[] = []
  constructor(
    private studentService: StudentService,
    private messageService: MessageService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents() {
    this.studentService.getStudents().subscribe({
      next: (response) => {
        this.students = response;
        console.log(response);
      }
    });
  }

  deleteStudent(id: string) {
    this.studentService.deleteStudent(id).subscribe({
      next: (response) => {
        const currentRoute = this.router.url;
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          this.router.navigateByUrl(currentRoute);
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'User deleted succesfully.' });
        });
      }
    });
  }
}
