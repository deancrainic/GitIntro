import { Component, OnInit } from '@angular/core';
import { AbstractControl, ControlContainer, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-reactive-form',
  templateUrl: './user-reactive-form.component.html',
  styleUrls: ['./user-reactive-form.component.css']
})
export class UserReactiveFormComponent implements OnInit {

  userViewModel = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl('', [
      Validators.minLength(8),
      Validators.required,
      forbiddenPassword(/12345678/i)
    ]),
    firstName: new FormControl('', [
      Validators.required
    ]),
    lastName: new FormControl('', [
      Validators.required
    ])
  });
  submitted = false;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.submitted = true;
    console.log(this.userViewModel);
  }

  get email() {
    return this.userViewModel.get('email');
  }

  get password() {
    return this.userViewModel.get('password');
  }

  get firstName() {
    return this.userViewModel.get('firstName');
  }

  get lastName() {
    return this.userViewModel.get('lastName');
  }
}

export function forbiddenPassword(passwordRe: RegExp): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const forbidden = passwordRe.test(control.value);
    return forbidden ? { forbiddenPassword: { value: control.value} } : null;
  };
}