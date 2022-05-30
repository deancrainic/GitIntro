import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { IReservationCreate } from 'src/app/models/reservationCreate';
import { AccountService } from 'src/app/services/account.service';
import { IProperty } from '../../models/property';
import { ApiService } from '../../services/api.service';
import { ReservationDetailsTrasporterService } from '../../services/reservation-details-trasporter.service';
import { DatePipe } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {

  loginStatus!: boolean;
  propertyId!: number;
  property!: Observable<IProperty>;

  startDate!: Date;
  endDate!: Date;
  guests!: number;
  range = new FormGroup({
    start: new FormControl(this.startDate, [Validators.required]),
    end: new FormControl(this.endDate, [Validators.required]),
  });

  reservationForm = new FormGroup({
    range: this.range,
    guests: new FormControl(this.guests, [Validators.required])
  });

  subscription1!: Subscription;
  subscription2!: Subscription;
  subscription3!: Subscription;
  subscription4!: Subscription;

  errorMessage!: string;

  constructor(
    private api: ApiService, 
    private activeRoute: ActivatedRoute, 
    private router: Router, 
    private transporter: ReservationDetailsTrasporterService, 
    private acc: AccountService,
    private date: DatePipe) { }

  ngOnInit(): void {
    this.activeRoute.params.subscribe(params => this.propertyId = params['id']);
    this.property = this.api.getPropertyById(this.propertyId);

    this.subscription1 = this.transporter.currentEndDate.subscribe(d => this.endDate = d);
    this.subscription2 = this.transporter.currentStartDate.subscribe(d => this.startDate = d);
    this.subscription3 = this.transporter.currentGuests.subscribe(g => this.guests = g);

    this.transporter.changeStartDate(this.startDate);
    this.transporter.changeEndDate(this.endDate);
    this.transporter.changeGuests(this.guests);

    this.range.get('start')?.setValue(this.startDate);
    this.range.get('end')?.setValue(this.endDate);
    this.reservationForm.get('guests')?.setValue(this.guests);

    this.acc.isLoggedIn.subscribe(x => this.loginStatus = x);
  }

  ngOnDestroy(): void {
    this.subscription1.unsubscribe();
    this.subscription2.unsubscribe();
    this.subscription3.unsubscribe();
  }
  
  getTotalPrice(price: number): number {
    const milisecondsPerDay = 1000 * 60 * 60 * 24;
    
    return price * Math.floor((this.reservationForm.get('range.end')?.value - this.reservationForm.get('range.start')?.value) / milisecondsPerDay)
  }

  makeReservation(price: number): void {
    const reservation: IReservationCreate = {
      propertyId: this.propertyId,
      checkinDate: this.date.transform(this.reservationForm.get('range.start')?.value, 'yyyy-MM-dd'),
      checkoutDate: this.date.transform(this.reservationForm.get('range.end')?.value, 'yyyy-MM-dd'),
      guestsNumber: this.reservationForm.get('guests')?.value,
      totalPrice: this.getTotalPrice(price)
    };

    if (this.loginStatus == true) {
      
      this.api.makeReservation(reservation).subscribe(
        res => {
          this.router.navigate(['profile', 'reservations']);
        },
        err => this.errorMessage = err.error);
    } else {
      this.router.navigate(['login']);
    }
  }
}
