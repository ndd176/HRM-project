import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowDepComponent } from './department/show-dep/show-dep.component';
import { DepartmentComponent } from './department/department.component';
import { AddEditDepComponent } from './department/add-edit/add-edit.component';
import { EmployeeComponent } from './employee/employee.component';
import { ShowEmpComponent } from './employee/show-emp/show-emp.component';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AddEditEmpComponent } from './employee/add-edit/add-edit.component';
@NgModule({
  declarations: [
    AppComponent,
    ShowDepComponent,
    DepartmentComponent,
    AddEditEmpComponent,
    EmployeeComponent,
    ShowEmpComponent,
    AddEditDepComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
