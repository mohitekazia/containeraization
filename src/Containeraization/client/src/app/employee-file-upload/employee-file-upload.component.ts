import { Component,OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { throwError } from 'rxjs'
import { CommonModule,NgFor } from '@angular/common';
import { EmployeeInformation } from './employee-information';
import { FormsModule } from '@angular/forms';
import { Input } from '@angular/core';
import { CompanyserviceService } from '../companyservice.service';


@Component({
  selector: 'app-employee-file-upload',
  standalone: true,
  imports: [CommonModule, FormsModule,NgFor],
  templateUrl: './employee-file-upload.component.html',
  styleUrl: './employee-file-upload.component.css'
})
export class EmployeeFileUploadComponent implements OnInit{
  public employees: EmployeeInformation[] = [];

  constructor(private companyService: CompanyserviceService) {

  }


  ngOnInit(): void {
    this.companyService.getEmployees().subscribe(items => {
      console.log(items);
      items.map(obj => {
        var employee = new EmployeeInformation(obj.name, obj.id, obj.companyId);
        this.employees.push(employee);
      })
    });
  }

  status: "initial" | "uploading" | "success" | "fail" = "initial";
  submitForm(data: any) {
    console.log(data.EmpName);
    this.companyService.addEmployee(data);
    this.companyService.getEmployees().subscribe(items => {
      console.log(items);
      items.map(obj => {
        var employee = new EmployeeInformation(obj.name, obj.id, obj.companyId);
        this.employees.push(employee);
      })
    });
  }

  





}
