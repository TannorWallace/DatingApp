import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  validationErrors: string[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  //1-404 not found
  get404Error() {
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error);
    })
  }
  //2- 400 bad request
   get400Error() {
    this.http.get(this.baseUrl + 'buggy/bad-request').subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error);
    })
   }
  //3- 500 server-error
   get500Error() {
    this.http.get(this.baseUrl + 'buggy/server-error').subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error);
    })
   }
  //4- 401 not authorized error
   get401Error() {
    this.http.get(this.baseUrl + 'buggy/auth').subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error);
    })
   }
  //5-
    get400ValidationError() {
      this.http.post(this.baseUrl + 'account/register', {}).subscribe(response => {
      console.log(response)
    }, error => {
        console.log(error);
        this.validationErrors = error;
    })
  }

}
