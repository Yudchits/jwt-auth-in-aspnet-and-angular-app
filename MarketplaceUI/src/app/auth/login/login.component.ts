import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../common/services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm: FormGroup;
  error: string = null;
  isSubmitted: boolean = false;

  private returnUrl: string;

  private onDestroy$ = new Subject<void>();
  private requestCancel$ = new Subject<void>();

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email, Validators.maxLength(32)]],
      password: ['', [Validators.required, Validators.maxLength(32)]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSignInClick(): void {
    this.isSubmitted = true;
    this.requestCancel$.next();
    
    if (!this.loginForm.valid) {
      return;
    } 

    this.authService.login(this.loginForm.value)
      .pipe(takeUntil(this.requestCancel$), takeUntil(this.onDestroy$))
        .subscribe(
          (result) => {
            this.router.navigate([this.returnUrl]);
          },
          (error) => {
            this.error = error;
          }
        );
  }

  ngOnDestroy(): void {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}

