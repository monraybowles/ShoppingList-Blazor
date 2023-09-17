import { UsersComponent } from './../../users/users/users.component';

import { Component, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { StudentService } from 'src/app/shared/student.service';
import { NgForm } from '@angular/forms';
import { DataSource } from '@angular/cdk/collections';
import { student } from 'src/app/shared/student.model'
import { Observable } from 'rxjs';

class NavLink {
  constructor(public path: string, public label: string) {}
}
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})



export class StudentsComponent implements OnInit {
prod = null;

  constructor(public dialog: MatDialog, public service : StudentService) { }
  
  displayedColumns: string[] = ['ClientID','NAME','Surname','Email','Phone','Gender'];
  listData = null;


  ngOnInit(): void {
    this.resetForm();
    
    this.service.getClient().subscribe(

      (data: student[]) => this.listData = data,
      (err: any) => console.log(err),
      () => console.log('All done getting products')
    )
   

  }

 

  openDialog(): void{
    let dialogRef = this.dialog.open(UsersComponent, {
       data: {
         
         height: '400px',
         width: '600px',
       }
      // height: '400px',
      //

    });
  }

  resetForm(form? : NgForm){
    if (form!=null)
    form.reset();
    // this.service.formData = {
    //  StudentID : null,
    //  FirstName : '',
    //  LastName : '',
    //  EmailAddress : '',
    //  IdNumber : '',
     
     
    // }
  }
  onSubmit(form : NgForm)
  {
    
  this.insertRecord(form);
 
  } 

  insertRecord(form : NgForm){
    this.service.postStudent(form.value).subscribe(res => {
      this.resetForm(form)
    });
  }
 
  

}
export class ProductDataSource extends DataSource<any> {
constructor(public service : StudentService) {
  super();
}

connect(): Observable<student[]> {
  return this.service.getClient();
}

disconnect() {}
  
}