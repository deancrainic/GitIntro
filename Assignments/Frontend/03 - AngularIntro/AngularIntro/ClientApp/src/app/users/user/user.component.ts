import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  user = new User();
  submitted = false;

  constructor() { }

  ngOnInit(): void {
  }

  submitForm(): void {
    this.submitted = true;
    console.log(this.user);
  }
}
