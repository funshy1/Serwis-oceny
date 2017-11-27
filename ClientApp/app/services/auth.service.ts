import { Injectable } from '@angular/core';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthService {

  constructor() {
  }

  //Mock login for frontend testing
  login(credentials: any) {
    let tokenAdmin = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFkbWluIiwiYWRtaW4iOnRydWV9.hExZk4rwAnlSXfDylO1H726fNB1NJvENAC5u-6kYcC0';
    let tokenUser = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlVzZXIiLCJhZG1pbiI6ZmFsc2V9.rvG2YkisUFNTpLPCIO4qNjBFgqCZ4VkWK2Ok57VSUHg';

    let login = credentials.login;
    let password = credentials.password;

    if (login == "Admin" && password == "123") {
      localStorage.setItem('token', tokenAdmin);
      return true;
    }

    if (login == "User" && password == "123") {
      localStorage.setItem('token', tokenUser);
      console.log(this.currentUser);
      return true;
    }

    return false;
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn() {
    if (typeof window !== 'undefined') {
      return tokenNotExpired();
    }
  }

  get currentUser() {
    let token = localStorage.getItem('token');
    if (token) return new JwtHelper().decodeToken(token);
    return null;
  }

}
