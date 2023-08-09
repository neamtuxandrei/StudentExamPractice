import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../student.service';
import { Student } from 'src/app/shared/models/student';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  student?: Student;

  studentForm = new FormGroup({
    id: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    emailAddress: new FormControl('')
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private studentService: StudentService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.loadStudent();
  }

  loadStudent() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.studentService.getStudent(id).subscribe({
        next: (response) => {
          this.studentForm.patchValue(response);
          this.student = response;
        }
      })
    }
  }

  saveStudent(){
    this.studentService.editStudent(this.student?.id, this.studentForm.value).subscribe(
      () => {
        this.router.navigate(["admin"]);
      }
    );
  }
}
