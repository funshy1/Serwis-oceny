import { AuthService } from './auth.service';
import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class AdminAuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  canActivate() {
    
    if (!this.authService.currentUser) return false;
    if (this.authService.currentUser.admin) return true;

    this.router.navigate(['']);
    return false;
  }
}
