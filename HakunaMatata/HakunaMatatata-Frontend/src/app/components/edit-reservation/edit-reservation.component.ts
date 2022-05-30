import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IReservation } from 'src/app/models/reservation';
import { IReservationCreate } from 'src/app/models/reservationCreate';
import { IReservationProperty } from 'src/app/models/reservationProperty';
import { IReservationUpdate } from 'src/app/models/reservationUpdate';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-reservation',
  templateUrl: './edit-reservation.component.html',
  styleUrls: ['./edit-reservation.component.css']
})
export class EditReservationComponent implements OnInit {

  message!: string;
  reservation!: IReservation;
  property!: IReservationProperty;

  range = new FormGroup({
    start: new FormControl('', [Validators.required]),
    end: new FormControl('', [Validators.required]),
  });

  reservationForm = new FormGroup({
    range: this.range,
    guests: new FormControl('', [Validators.required])
  });

  constructor(private api: ApiService, private activeRoute: ActivatedRoute, private router: Router, private date: DatePipe) { }

  ngOnInit(): void {
    this.activeRoute.params.subscribe(params => {
      let reservationId = params['id'];
      this.api.getReservationById(reservationId).subscribe(res => {
        this.reservation = res,
        this.range.controls['start'].setValue(new Date(res.checkinDate));
        this.range.controls['end'].setValue(new Date(res.checkoutDate));
        this.reservationForm.controls['guests'].setValue(res.guestsNumber);
        this.property = res.property;
      }, err => this.message = err.error)
    });
  }

  goToProperty(propertyId: number) {
    this.router.navigate(['property', propertyId]);
  }

  getTotalPrice(price: number): number {
    const milisecondsPerDay = 1000 * 60 * 60 * 24;     
    
    return price * Math.floor((this.reservationForm.get('range.end')?.value - this.reservationForm.get('range.start')?.value) / milisecondsPerDay)
  }

  updateReservation() {
    let res: IReservationUpdate = {
      checkinDate: this.date.transform(this.reservationForm.get('range.start')?.value, 'yyyy-MM-dd'),
      checkoutDate: this.date.transform(this.reservationForm.get('range.end')?.value, 'yyyy-MM-dd'),
      guestsNumber: this.reservationForm.get('guests')?.value,
      totalPrice: this.getTotalPrice(this.reservation.property.price),
    }

    this.api.updateReservation(this.reservation.reservationId, res).subscribe(res => console.log("yes"), err => console.log("no"));
  }
}
