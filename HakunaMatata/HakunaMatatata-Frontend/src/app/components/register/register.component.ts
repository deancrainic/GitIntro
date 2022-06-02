import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUserCreate } from '../../models/userCreate';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerViewModel = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8), forbiddenPassword]),
    confirmedPassword: new FormControl('', [Validators.required, Validators.minLength(8), forbiddenPassword]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
  }, {
    validators: passwordMatch('password', 'confirmedPassword')
  });

  errorMessage!:string;
  passwordMessage = "Password must be at least 8 characters long and must contain at least one digit";

  constructor(private acc: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  goToLogin(): void {
    this.router.navigate(['/login']);
  }

  register(): void {
    if (this.registerViewModel.valid) {
      let user: IUserCreate = {
        email: this.registerViewModel.get('email')?.value,
        password: this.registerViewModel.get('password')?.value,
        confirmedPassword: this.registerViewModel.get('confirmedPassword')?.value,
        firstName: this.registerViewModel.get('firstName')?.value,
        lastName: this.registerViewModel.get('lastName')?.value,
      };
    
      this.acc.register(user).subscribe(() => this.goToLogin(), err => this.errorMessage = err.error);
    } 
  }
}

export function forbiddenPassword(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null;
    }

    const hasLetter = /[a-z]+/.test(value);
    const hasUpperLetter = /[A-Z]+/.test(value);
    const hasDigit = /[0-9]+/.test(value);

    const passwordValid = hasLetter && hasDigit && hasUpperLetter;

    return !passwordValid ? { invalidPassword: true }: null;
  }
}

export function passwordMatch(password: string, confirmPassword: string):ValidatorFn {
  return (formGroup: AbstractControl):{ [key: string]: any } | null => {
    const passwordControl = formGroup.get(password);
    const confirmPasswordControl = formGroup.get(confirmPassword);
    
    if (!passwordControl || !confirmPasswordControl) {
      return null;
    }

    if (
      confirmPasswordControl.errors &&
      !confirmPasswordControl.errors['passwordMismatch']
    ) {
      return null;
    }

    if (passwordControl.value !== confirmPasswordControl.value) {
      confirmPasswordControl.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true }
    } else {
      confirmPasswordControl.setErrors(null);
      return null;
    }
  };
}

