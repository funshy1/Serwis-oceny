import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {
  userProfile: any;
  isAdmin: boolean = false;

  auth0 = new auth0.WebAuth({
    clientID: '3hJC6FNdqA1oS4cLEpG1JYg0aOkb1tuF',
    domain: 'dtas.auth0.com',
    responseType: 'token id_token',
    audience: 'https://dtas.auth0.com/userinfo',
    redirectUri: 'http://localhost:5000/home',
    scope: 'openid profile app_metadata'
  });

  constructor(public router: Router) {}

  public login(): void {
    this.auth0.authorize();

  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        if (!this.userProfile && this.isAuthenticated()) {
          this.getProfile((err: any, profile: any) => {});
        }
        this.router.navigate(['/home']);
      } else if (err) {
        this.router.navigate(['/home']);
        console.log(err);
      }
    });
  }

  private setSession(authResult: any): void {
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);
  }

  public logout(): void {
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    this.userProfile = null;
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    const expiresAt = JSON.parse(localStorage.getItem('expires_at')|| '{}');
    return new Date().getTime() < expiresAt;
  }

  public getProfile(cb: any): void {
    const accessToken = localStorage.getItem('access_token');
    
    if (!accessToken) {
      throw new Error('Access token must exist to fetch profile');
    }
  
    this.auth0.client.userInfo(accessToken, (err, profile: any) => {
      if (profile) {
        this.userProfile = profile;
        if (profile['https://dtas:auth0:com/app_metadata'])
          this.isAdmin = profile['https://dtas:auth0:com/app_metadata'].isAdmin;
      }
      cb(err, profile);
    });
  }

}