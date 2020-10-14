import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { LoginSignupComponent } from './login-signup.component';
import { LoginComponent } from './login.component';

@NgModule(
    {
        imports: [ RouterModule.forChild([
            { path: '', component: LoginSignupComponent},
            { path: 'login', component: LoginComponent }
        ])],
        declarations: [ LoginSignupComponent, LoginComponent ]
    }
)
export class AuthModule {}