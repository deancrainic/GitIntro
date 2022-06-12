import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { IProperty } from '../../models/property';
import { ApiService } from '../../services/api.service';
import { ReservationDetailsTrasporterService } from '../../services/reservation-details-trasporter.service';

@Component({
  selector: 'app-search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent implements OnInit {

  range = new FormGroup({
    start: new FormControl(''),
    end: new FormControl(''),
  });

  searchViewModel = new FormGroup({
    location: new FormControl(''),
    range: this.range,
    guests: new FormControl('')
  });
 
  properties!: IProperty[];
  shownProperties!: IProperty[];

  constructor(private api: ApiService, private transporter: ReservationDetailsTrasporterService) { }

  ngOnInit(): void {
    this.api.getAllProperties().subscribe(x => this.properties = x);
  }

  onSubmit(): void {
    this.shownProperties = this.properties
      .filter(
        p => p.address.toLowerCase().includes(this.searchViewModel.get('location')?.value.toLowerCase()) 
            && p.maxGuests >= this.searchViewModel.get('guests')?.value)
      .sort((p1, p2) => (p1.price > p2.price) ? 1 : -1);
    
    if (this.searchViewModel.get('range.start')?.value === '') {
      this.transporter.changeStartDate(new Date());
    } else {
      this.transporter.changeStartDate(this.searchViewModel.get('range.start')?.value);
    }

    if (this.searchViewModel.get('range.end')?.value === '') {
      this.transporter.changeEndDate(new Date());
    } else {
      this.transporter.changeEndDate(this.searchViewModel.get('range.end')?.value);
    }

    if (this.searchViewModel.get('guests')?.value === '') {
      this.transporter.changeGuests(1);
    } else {
      this.transporter.changeGuests(this.searchViewModel.get('guests')?.value);
    }
  }
}