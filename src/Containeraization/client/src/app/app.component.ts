import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgFor, CommonModule } from '@angular/common';
import { CompanyserviceService } from './companyservice.service';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';
import { EmployeeInformation } from './employee-file-upload/employee-information';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EmployeeFileUploadComponent, NgFor, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[CompanyserviceService]
})
export class AppComponent {
  title = 'client';
}
