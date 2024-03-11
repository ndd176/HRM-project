import { DepartmentComponent } from './../department.component';
import { Component, OnInit,Input} from '@angular/core';
import { SharedService } from '../../shared.service';
@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrl: './show-dep.component.css',
})
export class ShowDepComponent implements OnInit {
  constructor(private service: SharedService) {}

  DepartmentList: any = [];

  ModalTitle: string;
  ActivateAddEditDepComp: boolean = false;
  dep: any;

  //custom sorting function
  DepartmentIdFilter:string="";
  DepartmentNameFilter:string="";
  DepartmentListWithoutFilter:any="";
  ngOnInit(): void {
    this.refreshDepList();
  }
  addClick() {
    this.dep={
      DepartmentId:0,
      DepartmentName:""
    }
    this.ModalTitle="Add Department";
    this.ActivateAddEditDepComp = true;
  }
  editClick(item:any){
    this.dep=item;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepComp=true;
  }
  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshDepList();
  }
  refreshDepList() {
    this.service.getDepList().subscribe((data) => {
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
    });
  }
  deleteClick(item:any){
    if(confirm('Are you sure you want to delete this?')){
      this.service.deleteDepartment(item.DepartmentId).subscribe(data=>{
        alert(data.toString());
        this.refreshDepList();
      })
    }
  }
  FilterFn(){
    var DepartmentIdFilter = this.DepartmentIdFilter;
    var DepartmentNameFilter = this.DepartmentNameFilter;

    this.DepartmentList = this.DepartmentListWithoutFilter.filter(function(el:any){
      return el.DepartmentId.toString().toLowerCase().includes(
        DepartmentIdFilter.toString().trim().toLowerCase()
      )&& el.DepartmentName.toString().toLowerCase().includes(
      DepartmentNameFilter.toString().trim().toLowerCase()
    )

    })
  }
  sortResult(prop :any,asc:any){
    this.DepartmentList = this.DepartmentListWithoutFilter.sort(function(a:any,b:any){
      if(asc){
        return (a[prop]>b[prop])?1 :((a[prop]<b[prop])?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 :((b[prop]<a[prop])?-1 :0);

      }
    })

  }
}
