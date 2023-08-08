import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit{
  students: Student[] = []
  constructor(private studentService: StudentService) { }
  ngOnInit(): void {
    this.getStudents();
  }

  getStudents(){
    this.studentService.getStudents().subscribe({
      next: (response) => {
        this.students = response;
        console.log(response);
      }
    });
  }
}
