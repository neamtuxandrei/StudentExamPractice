import { Task } from "./task.model";

export interface Student{
    id: string;
    matriculationNo: number;
    name: string;
    mail: string;
    grade: number;
    taskList: Array<Task>;
}