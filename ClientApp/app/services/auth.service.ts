import { Injectable } from '@angular/core';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthService {
  currentUser: any;

  constructor() {
    if (typeof window !== 'undefined') {
      let token = localStorage.getItem('token');
      if (token) this.currentUser = new JwtHelper().decodeToken(token);
      console.log('in constructor');
    }
  }

  //Mock login for frontend testing
  login(credentials: any) {
    let tokenAdmin = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFkbWluIiwiYWRtaW4iOnRydWV9.hExZk4rwAnlSXfDylO1H726fNB1NJvENAC5u-6kYcC0';
    let tokenUser = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlVzZXIiLCJhZG1pbiI6ZmFsc2V9.rvG2YkisUFNTpLPCIO4qNjBFgqCZ4VkWK2Ok57VSUHg';

    let login = credentials.login;
    let password = credentials.password;

    if (login == "Admin" && password == "123") {
      localStorage.setItem('token', tokenAdmin);
      this.currentUser = new JwtHelper().decodeToken(tokenAdmin);
      console.log(this.currentUser);
      return true;
    }

    if (login == "User" && password == "123") {
      localStorage.setItem('token', tokenUser);
      this.currentUser = new JwtHelper().decodeToken(tokenUser);
      console.log(this.currentUser);
      return true;
    }

    return false;
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = null;
  }

  isLoggedIn() {
    if (typeof window !== 'undefined') {
      return tokenNotExpired();
    }
  }

}
