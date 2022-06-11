import { Component, Input, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
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
    let dateString = d.toString();
    let dateFormatted = new Date(dateString + 'Z');
    
    return dateFormatted;
  }

  checkDate(d: Date): boolean {
    return (this.formatDate(d) < this.formatDate(new Date()));
  }

  delete(reservationId: number): void {
    this.api.deleteReservationByOwner(reservationId).subscribe(res => {
      this.api.getReservationsByPropertyId(this.propertyId).subscribe(x => this.reservations = x);
    });
  }
}
