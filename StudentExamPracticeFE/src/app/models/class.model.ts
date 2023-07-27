import { CommissionMember } from "./commision-member.model";
import { Secretary } from "./secretary.model";
import { Student } from "./student.model";

export interface Class{
    id: string;
    students: Array<Student>;
    commissionMembers: Array<CommissionMember>
    secretary: Secretary;
}