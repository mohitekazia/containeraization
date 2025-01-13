import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { throwError } from 'rxjs'
import { CommonModule } from '@angular/common';
import { EmployeeInformation } from './employee-information';
import { FormsModule } from '@angular/forms';
import { Input } from '@angular/core';

@Component({
  selector: 'app-employee-file-upload',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './employee-file-upload.component.html',
  styleUrl: './employee-file-upload.component.css'
})
export class EmployeeFileUploadComponent {
  constructor( private http:HttpClient) {
    
  }

  submitForm(data:any) {
    console.log(data.EmpName)
  }




  //status: "initial" | "uploading" | "success" | "fail" = "initial";
  //file: File | null = null;
  

  //constructor(private http: HttpClient
  //            ) {
  //}

  //onChange(event: any) {
  //  const file: File = event.target.files[0];

  //  if (file) {
  //    this.status = "initial";
  //    this.file = file;
  //  }
    
  //}

  //onUpload() {
  //  if (this.file) {

  //    const formData = new FormData();

  //    formData.append('file', this.file, this.file.name);

  //    const body = JSON.stringify({ value: "asasas" })

  //    const httpOptions = {
  //      headers: new HttpHeaders({
  //        'Content-Type': 'application/json'
  //      })
  //    };
  //    //const upload$ = this.http.post("http://localhost:8080/api/employee/save", formData);

  //   const upload$ = this.http.post("http://localhost:8080/api/employee/save", body,httpOptions)

  //    //const upload$ = this.http.get("api//companies//getallcompanies")

  //    this.status = 'uploading';

  //    upload$.subscribe({
  //      next: () => {
  //        this.status = 'success';
  //      },
  //      error: (error: any) => {
  //        this.status = 'fail';
  //        return throwError(() => error);
  //      },
  //    });
  //  }

  //}
}
