import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { CarModuleComponent } from './car/car-module/car-module.component';
import { CarMainComponent } from './car/car-main/car-main.component';
import { AuthGuard } from './auth/common/guards/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'car', component: CarModuleComponent, children: [
    { path: '', component: CarMainComponent, canActivate: [AuthGuard] }
  ]},
  { path: '**', redirectTo: 'car' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
