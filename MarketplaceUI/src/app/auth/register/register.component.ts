import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../common/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {

  registerForm: FormGroup;
  isSubmitted: boolean = false;
  error: string = null;

  private returnUrl: string = null;

  private onDestroy$: Subject<void> = new Subject<void>();
  private requestCancel$: Subject<void> = new Subject<void>();

  constructor(
    private authService: AuthService, 
    private formBuilder: FormBuilder, 
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email, Validators.maxLength(32)]],
      password: ['', [Validators.required, Validators.maxLength(32)]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSignUpClick(): void {
    this.isSubmitted = true;
    this.requestCancel$.next();

    if (!this.registerForm.valid) {
      return;
    }

    this.authService.register(this.registerForm.value)
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
