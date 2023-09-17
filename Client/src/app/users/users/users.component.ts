import { Component, OnInit, Optional, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { student } from 'src/app/shared/student.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StudentService } from 'src/app/shared/student.service';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';







@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})


export class UsersComponent implements OnInit {
  selected = '';
  selectedValue: string;
  form: FormGroup;
  Addressform: FormGroup;

  regiForm: FormGroup;  
 // album: Product;
  FirstName: null;
  LastName : null;
  EmailAddress : null;
  ContactNumber : null;
  Address : string ;
  IdNumber : string ;
  PreferedMethod : string ;
  ProfileImage : string ;
  
  StudentID: number;
  
  id: number;
  IsAccepted:number=0;  
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  isEditable = false;

  StudentEnrolementID : number;
  Institution : string;
  Qualification : string;
  QualificationType : string;
  DateRegistered : string;
  GraduationDate : string;
  AverageToDate : string;
 



  
  constructor( private fb: FormBuilder, public dialogRef: MatDialogRef<UsersComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: student,public MatDialog: MatDialog,public service: StudentService) { 
     console.log(data);
     // this.local_data = {...data};
    //  this.action = this.data.AlbumId;
   

    this.regiForm = fb.group({  
      'FirstName': [null, Validators.required],  
      'LastName': [null, Validators.required],     
      'IdNumber' : [null, Validators.required],
      'EmailAddress':[null, Validators.compose([Validators.required,Validators.email])],  
      'IsAccepted':[null]  
    });  
    

    this.form = fb.group({
      StudentID: [this.data.StudentID],
      FirstName: [this.data.FirstName, Validators.required],
      LastName: [this.data.LastName, Validators.required],
      EmailAddress : [this.data.EmailAddress, Validators.required],
      IdNumber : [this.data.IdNumber, Validators.required],
  
      


  });
    }
  

    
  ngOnInit(): void {
    
   // this.data.Gender = this.selected;
    
   // this.checkGender();
    this.checkQualificationType();

  }

 

  checkQualificationType()
  {
    if (this.data.QualificationType== '1')
    {
      this.selected = "1";
    }
    if (this.data.QualificationType== '2')
    {
      this.selected = "2";
    }
    if (this.data.QualificationType== '3')
    {
      this.selected = "3";
    }
   
    
  }

  onChange(event:any)  
  {  
    if (event.checked == true) {  
      this.IsAccepted = 1;  
    } else {  
      this.IsAccepted = 0;  
    }  
  } 

  onFormSubmit(form:NgForm)  
  {  

   
    
   // console.log(form);  
    //this.service.registerUser(this.regiForm.value).subscribe(res => {
      // this.resetForm(this.form.value)
     // alert('reaches here');
     // this.dialogRef.close();
    // this.openSnackBar("User registration successfull","close")
    // this.toastr.success('User registration successful');
     // });
    ///this.service.registerUser(form.value)
      // .subscribe((data: any) => {
      //   if (data.Succeeded == true) {
     //this.resetForm(this.regiForm);
    // this.IsAccepted = 0;
    
      //   }
      //  // else
     // this.toastr.error(data.Errors[0]);
      // });

  }  
 
  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
   // this.service.filter('Register click');
  }

  openDialog(){
    this.MatDialog.open(UsersComponent, {
     height: '400px',
     width: '600px',

   });
 }
 save() {
 // console.log(this.form.value)
  //this.AlbumId = this.data.AlbumId;
  console.log(this.form.value)
  if (this.data.StudentID == 0 || this.data.StudentID == null || this.data.StudentID == undefined)
  {
      
   // this.data.AlbumId == 0;
    this.service.postStudent(this.form.value).subscribe(res => {
    // this.resetForm(this.form.value)
   // alert('reaches here');
     this.dialogRef.close();
    });
  }
  else
  {

    this.service.updateClient(this.form.value).subscribe(res => {
     // this.resetForm(this.form.value)
     this.dialogRef.close();
    });

  console.log(this.form.value)

  }
 // save addresses with clients
  this.saveAddress();
 }

saveAddress() {
  // console.log(this.form.value)
   //this.AlbumId = this.data.AlbumId;
   console.log(this.form.value)
   if (this.data.StudentID == 0 || this.data.StudentID == null || this.data.StudentID == undefined)
   {
       
    // this.data.AlbumId == 0;
     this.service.postStudentEnrolement(this.form.value).subscribe(res => {
     // this.resetForm(this.form.value)
    // alert('reaches here');
      this.dialogRef.close();
     });
   }
   else
   {
 
     this.service.updateClientAddress(this.form.value).subscribe(res => {
      // this.resetForm(this.form.value)
      this.dialogRef.close();
     });
 
   console.log(this.form.value)
 
   }
  // this.dialogRef.close(this.form.value);
  // this.closeDialog();
 }





close() {
  this.dialogRef.close();
}



}
