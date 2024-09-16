import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,EmployeeFileUploadComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'client';
}
