import { ExamTask } from "./examTask";

export interface Student{
    id: string;
    tasks: ExamTask[];
    firstName: string;
    lastName: string;
    emailAddress: string;
}
 
