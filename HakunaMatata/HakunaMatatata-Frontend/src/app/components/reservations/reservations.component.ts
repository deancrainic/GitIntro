import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IReservation } from 'src/app/models/reservation';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  reservations!: Observable<IReservation[]>;
  currentDate = new Date();
  showEditForm = false;
  displayedColumns = ['checkin', 'checkout', 'property', 'totalPrice', 'guests', 'buttons']

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.reservations = this.api.getReservations();
  }

  formatDate(d: Date): Date {
    let dateString = d.toString();
    let dateFormatted = new Date(dateString + 'Z');

    return dateFormatted;
  }

  checkDate(d: Date): boolean {
    return (this.formatDate(d) < this.formatDate(this.currentDate))
  }

  delete(reservationId: number): void {
    this.api.deleteReservation(reservationId).subscribe(res => this.reservations = this.api.getReservations());
  }

  edit(reservationId: number): void {
    this.router.navigate(['/profile/reservations', reservationId]);
  }
}
