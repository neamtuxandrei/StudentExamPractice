import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { StudentService } from '../../student.service';
import { Student } from 'src/app/shared/models/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent {

  student?: Student;

  studentForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    emailAddress: new FormControl('')
  });

  constructor(
    private studentService: StudentService,
    private router: Router,
  ){}

  addStudent(){
    this.studentService.addStudent(this.studentForm.value).subscribe(
      () => {
        this.router.navigate(["admin"]);
      }
    );
  }
}
