import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { StudentService } from './student.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit {
  students: Student[] = []
  constructor(private studentService: StudentService) { }
  ngOnInit(): void {
    this.studentService.getStudents().subscribe({
      next: (response) => {
        this.students = response;
        console.log(response);
      }
    });
  }

}
