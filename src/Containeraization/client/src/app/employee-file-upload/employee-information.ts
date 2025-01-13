export class EmployeeInformation {
  EmpName: string;
  EmpId: number;
  EmpCompanyId: number;

  constructor(empName?: any, empId?: any, empCompanyId?: any) {
    this.EmpName = empName;
    this.EmpId = empId;
    this.EmpCompanyId = empCompanyId;
  }
}
