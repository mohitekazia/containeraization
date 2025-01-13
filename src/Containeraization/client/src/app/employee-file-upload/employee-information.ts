export class EmployeeInformation {
  EmpName: string;
  EmpId: number;
  EmpCompanyId: number;

  constructor(empName: string, empId: number, empCompanyId: number) {
    this.EmpName = empName;
    this.EmpId = empId;
    this.EmpCompanyId = empCompanyId;
  }
}
