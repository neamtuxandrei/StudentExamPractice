import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  // url = environment.baseUrl;
  url =''
  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.url = url + 'api';
  }

  getStudents() {
    return this.http.get<any>(this.url + "/student");
  }

  getStudent(id: string) {
    return this.http.get<Student>(this.url + "/student/" + id);
  }

  deleteStudent(id: string) {
    return this.http.delete(this.url + "/student/" + id);
  }

  editStudent(id: any, values: any){
    return this.http.put(this.url + "/student/" + id, values);
  }

  addStudent(values: any){
    return this.http.post(this.url + "/student/", values);
  }
}
