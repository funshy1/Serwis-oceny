import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthGuard } from './auth-guard.service';

@Injectable()
export class AdminAuthGuard extends AuthGuard {

    constructor(protected authService: AuthService)  { super(authService); }

    public canActivate() {
        var isAuthenticated = super.canActivate();

        return isAuthenticated ? this.authService.isAdmin : false
    }
}