import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent implements OnInit {

  searchViewModel = new FormGroup({
    location: new FormControl('', [Validators.required]),
    checkin: new FormControl('', [Validators.required]),
    checkout: new FormControl('', [Validators.required]),
    guests: new FormControl('', [Validators.required])
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    console.log();
    
  }

}
