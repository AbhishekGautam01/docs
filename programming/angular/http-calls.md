# Calling HTTP Rest Endpoints
0. **Creating an API Response Model**
```ts
// user-detail.model.ts

export interface UserDetail {
  id: number;
  name: string;
  email: string;
  // Add more properties as needed
}
```
<br/>

1. **Creating an HTTP Service**
```ts
// api.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDetail } from './user-detail.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://jsonplaceholder.typicode.com'; // Assuming a placeholder API

  constructor(private http: HttpClient) {}

  getUserDetails(userId: number): Observable<UserDetail> {
    return this.http.get(`${this.apiUrl}/users/${userId}`);
  }
}
```
<br/>

2. **Creating the component**
```ts
// user.component.ts

import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { UserDetail } from './user-detail.model';

@Component({
  selector: 'app-user',
  template: `
    <h2>User Details</h2>
    <div *ngIf="userDetails; else loading">
      <p>Name: {{ userDetails.name }}</p>
      <p>Email: {{ userDetails.email }}</p>
      <!-- Add more details as needed -->
    </div>
    <ng-template #loading>Loading...</ng-template>
  `
})
export class UserComponent implements OnInit {
  userDetails: UserDetail;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    const userId = 1; // Replace with the desired user ID
    this.apiService.getUserDetails(userId).subscribe(
      data => this.userDetails = data,
      error => console.error('Error:', error)
    );
  }
}
```
<br/>

4. **Updating Module Configuration**
```ts
// app.module.ts

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ApiService } from './api.service';
import { UserDetail } from './user-detail.model';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
```
<br/>

## Interceptors
* Used to intercept and modify HTTP requests and response globally. 
* They are useful for adding headers, logging, error handling, and authentication.
* For this we need to implement `HttpInterceptor` interface.
