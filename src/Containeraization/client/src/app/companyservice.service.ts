import { Injectable } from '@angular/core';
import { EmployeeInformation } from './employee-file-upload/employee-information';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { throwError, map, Observable,pipe } from 'rxjs'



@Injectable({
  providedIn: 'root'
})
export class CompanyserviceService {


  constructor(private http: HttpClient) { }


  addEmployee(employee: any) {
    const upload$ = this.http.post("http://localhost:8080/api/employee/save", employee);
    upload$.subscribe(
      (res: any) => {
        console.log("Response arrived")

      },
      (error: any) => {
        return throwError(() => error);
      },
    );
  }

  getEmployees(): Observable<any[]> {
    var ss = this.http.get<any[]>("http://localhost:8080/api/employee/getemployees").pipe(map(res => res));
    return ss;
  }
}
