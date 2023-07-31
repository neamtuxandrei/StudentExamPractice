import { CommissionMember } from "./commision-member.model";
import { Student } from "./student.model";

export interface Exam{
    id: string;
    startDate: Date;
    student: Student;
    commisionMembers: Array<CommissionMember>
    gradeList: Array<number>;
    commissionMembersNumber: number;
    
}