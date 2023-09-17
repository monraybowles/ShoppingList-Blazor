import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { student } from './student.model'
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
 // list : Product[];
  formData : student;
  //readonly rootURL = "https://localhost:44368";
  readonly rootURL = "https://localhost:44311"; 
  
  constructor(private http: HttpClient) { }


 
  postStudent(StudentformData : student): Observable<student>{
    // if you use a new guid set here... 
    // currenly this is set for auto generated ID in SQL...
    StudentformData.StudentID = 0;
    return this.http.post<student>(this.rootURL+'/api/student', StudentformData,{
      headers: new HttpHeaders({
       'Content-Type':'application/json'
        })
      });
  }

  postStudentEnrolement(StudentAddressformData : student): Observable<student>{
    // if you use a new guid set here... 
    // currenly this is set for auto generated ID in SQL...
    StudentAddressformData.StudentEnrolementID = 0;
    return this.http.post<student>(this.rootURL+'/api/StudentEnrolement', StudentAddressformData,{
      headers: new HttpHeaders({
       'Content-Type':'application/json'
        })
      });
  }

  updateClient(StudentAddressformData : student): Observable<void>{

   // alert(this.rootURL+'/api/album/' + formData.AlbumId)
    return this.http.put<void>(this.rootURL+'/api/Student/' + StudentAddressformData.StudentID, StudentAddressformData,{
     headers: new HttpHeaders({
      'Content-Type':'application/json'
       })
     });
  }

  updateClientAddress(StudentAddressformData : student): Observable<void>{

    // alert(this.rootURL+'/api/album/' + formData.AlbumId)
     return this.http.put<void>(this.rootURL+'/api/ClientAddress/' + StudentAddressformData.StudentEnrolementID, StudentAddressformData,{
      headers: new HttpHeaders({
       'Content-Type':'application/json'
        })
      });
   }

  deleteClient(studentID : number): Observable<void>{
    return this.http.delete<void>(this.rootURL+'/api/Student/' + studentID);
   
  }
  // getAlbum(){

  //   return this.http.get(this.rootURL+'/album')
  //   .toPromise().then(res => this.list = res as Product[])




  // }
getClient(): Observable<student[]>{

    return this.http.get<student[]>(this.rootURL+'/api/Student');
   // headers: new HttpHeaders({
    //  'Accept': 'application/json'
   // })
   // })
    //.toPromise().then(res => this.list = res as Product[])
  }

 

  // private _listners = new Subject<any>();
  // listen(): Observable<any>{
  //   return this._listners.asObservable();
  // }
  // filter(filterBy: string){
  //   this._listners.next(filterBy);
  // }
}
