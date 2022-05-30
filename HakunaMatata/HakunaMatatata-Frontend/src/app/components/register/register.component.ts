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
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
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
