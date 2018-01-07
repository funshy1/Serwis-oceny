import { Injectable } from '@angular/core';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthService {

  constructor() {
  }

  //Mock login for frontend testing
  login(credentials: any) {
    let tokenAdmin = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFkbWluIiwiYWRtaW4iOnRydWUsImlkIjoxfQ.0S7SjpIVLrTdZVYP-gO8jLtNyj_QhLbppObzDMahxoU';
    let tokenUser = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlVzZXIiLCJhZG1pbiI6ZmFsc2UsImlkIjoyfQ.P2JWO1RGH7yChLV2SyyKovzpyU1a6Lzru19biX13uvA';

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
