import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  url = environment.baseUrl;
  constructor(private http: HttpClient) {

  }

  getStudents() {
    return this.http.get<Student[]>(this.url + "/student");
  }

  getStudent(id: string) {
    return this.http.get<Student>(this.url + "/student/" + id);
  }
}
