import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Result } from 'src/app/shared/common/helpers/result';
import { environment } from 'src/environments/environment';

export const AUTH_TOKEN_KEY = 'auth_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl: string = `${environment.authApi}/api`;
  private loginUrl: string = '/user/login';
  private registerUrl: string = '/user/register';

  constructor(private http: HttpClient) { }

  login(loginForm: NgForm): Observable<string> {
    return this.http.post<Result<string>>(this.apiUrl + this.loginUrl, loginForm)
      .pipe(
        map((response: Result<string>) => {
          localStorage.setItem(AUTH_TOKEN_KEY, response.data);
          return response.data;
        }),
      );
  }

  register(registerForm: NgForm): Observable<string> {
    return this.http.post<Result<string>>(this.apiUrl + this.registerUrl, registerForm)
      .pipe(
        map((response: Result<string>) => {
          localStorage.setItem(AUTH_TOKEN_KEY, response.data);
          return response.data;
        })
      );
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  getToken(): string {
    return localStorage.getItem(AUTH_TOKEN_KEY);
  }

  logout(): void {
    localStorage.removeItem(AUTH_TOKEN_KEY);
  }
}