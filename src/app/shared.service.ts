import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'http://localhost:50523/api';
  readonly PhotoUrl = 'http://localhost:50523/Photos';

  constructor(private http: HttpClient) {}

  getDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Department');
  }
  //post api to add
  addDepartment(val: any) {
    return this.http.post(this.APIUrl + '/Department', val);
  }
  //put method api
  updateDepartment(val: any) {
    return this.http.put(this.APIUrl + '/Department', val);
  }
  //delete method api
  deleteDepartment(val: any) {
    return this.http.delete(this.APIUrl + '/Department/' + val);
  }

  //---------------------------------for Employee 
  getEmpList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Employee');
  }
  //post api to add
  addEmployee(val: any) {
    return this.http.post(this.APIUrl + '/Employee', val);
  }
  //put method api
  updateEmployee(val: any) {
    return this.http.put(this.APIUrl + '/Employee', val);
  }
  //delete method api
  deleteEmployee(val: any) {
    return this.http.delete(this.APIUrl + '/Employee/' + val);
  }

  //save picture 
  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+"/Employee/SaveFile",val);
  }

  //method get all name of department 
  getAllDepartmentNames():Observable<any[]>{
    return this.http.get<any []>(this.APIUrl+"/Employee/GetAllDepartmentNames");
  }
}
