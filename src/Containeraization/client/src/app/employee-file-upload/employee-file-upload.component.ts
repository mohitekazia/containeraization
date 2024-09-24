import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { throwError } from 'rxjs'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-file-upload',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-file-upload.component.html',
  styleUrl: './employee-file-upload.component.css'
})
export class EmployeeFileUploadComponent {
  status: "initial" | "uploading" | "success" | "fail" = "initial";
  file: File | null = null;
  

  constructor(private http: HttpClient
              ) {
  }

  onChange(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      this.status = "initial";
      this.file = file;
    }
    
  }

  onUpload() {
    if (this.file) {
      const headers = new HttpHeaders()
        .set('content-type', 'application/json')
        /*.set('Access-Control-Allow-Origin', 'http://localhost:4200')*/
        .set('Access-Control-Allow-Methods', 'GET,HEAD,OPTIONS,POST,PUT')
        .set('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept, Authorization,Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers');
      

      const formData = new FormData();

      formData.append('file', this.file, this.file.name);

      const upload$ = this.http.post("http://localhost:4200//api//employees//save", formData);

      this.status = 'uploading';

      upload$.subscribe({
        next: () => {
          this.status = 'success';
        },
        error: (error: any) => {
          this.status = 'fail';
          return throwError(() => error);
        },
      });
    }

  }
}
