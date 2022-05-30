import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router'
import { IReservation } from 'src/app/models/reservation';
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
  reserveErrorMessage!: string;
  reservation!: IReservation;
  @Input()
  reservationId!: number;
  property!: IReservationProperty;

  range = new FormGroup({
    start: new FormControl('', [Validators.required]),
    end: new FormControl('', [Validators.required]),
  });

  reservationForm = new FormGroup({
    range: this.range,
    guests: new FormControl('', [Validators.required])
  });

  constructor(
    private api: ApiService, 
    private router: Router, 
    private date: DatePipe,
    public dialogRef: MatDialogRef<EditReservationComponent>
  ) { }

  formatDate(d: Date): Date {
    let dateString = d.toString();
    let dateFormatted = new Date(dateString + 'Z');

    console.log(d);
    console.log(dateFormatted);
    
    return dateFormatted;
  }

  ngOnInit(): void {
    this.api.getReservationById(this.reservationId).subscribe(res => {
      this.reservation = res,
      this.range.controls['start'].setValue(this.formatDate(new Date(res.checkinDate)));
      this.range.controls['end'].setValue(this.formatDate(new Date(res.checkoutDate)));
      this.reservationForm.controls['guests'].setValue(res.guestsNumber);
      this.property = res.property;
    }, err => this.message = err.error);
  }

  goToProperty(propertyId: number) {
    this.router.navigate(['property', propertyId]);
    this.closeModal();
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

    this.api.updateReservation(this.reservation.reservationId, res).subscribe(res => this.closeModal(), err => this.reserveErrorMessage = err.error);
  }

  closeModal() {
    this.dialogRef.close();
  }
}
