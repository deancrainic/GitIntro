import { Component, Input, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Methods } from 'src/app/methods/methods';
import { IPropertyReservation } from 'src/app/models/propertyReservation';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-property-reservations',
  templateUrl: './property-reservations.component.html',
  styleUrls: ['./property-reservations.component.css']
})
export class PropertyReservationsComponent implements OnInit {

  @Input()
  reservations!: IPropertyReservation[];
  @Input()
  propertyId!: number;
  displayedColumns = ['email', 'checkin', 'checkout', 'buttons'];
  
  constructor(public dialogRef: MatDialogRef<PropertyReservationsComponent>, private api: ApiService) { }

  ngOnInit(): void {
  }

  closeModal() {
    this.dialogRef.close();
  }

  formatDate(d: Date): Date {
    return Methods.formatDate(d);
  }

  checkDate(d: Date): boolean {
    return (Methods.formatDate(d) < Methods.formatDate(new Date()));
  }

  delete(reservationId: number): void {
    this.api.deleteReservationByOwner(reservationId).subscribe(res => {
      this.api.getReservationsByPropertyId(this.propertyId).subscribe(x => this.reservations = x);
    });
  }
}
