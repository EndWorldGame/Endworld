import { Component } from "@angular/core";
import { Router } from '@angular/router';

@Component({
    templateUrl: './login-signup.component.html',
    styleUrls: ['./login-signup.component.scss']
})
export class LoginSignupComponent {
    constructor(private router: Router){}

    goToLogin() {
        this.router.navigate(['/auth/login'])
    }
}