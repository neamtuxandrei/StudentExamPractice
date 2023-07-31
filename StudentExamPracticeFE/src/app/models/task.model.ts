import { Student } from "./student.model";

export interface Task{
    id: string;
    name: string;
    description: string;
    deadline: Date;
    upload: Date;
    lastUpdate:Date;
    students: Array<Student>;

}