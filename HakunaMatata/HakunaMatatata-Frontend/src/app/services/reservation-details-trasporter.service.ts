import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationDetailsTrasporterService {

  startDateSource = new BehaviorSubject(new Date());
  endDateSource = new BehaviorSubject(new Date());
  guestsSource = new BehaviorSubject(0);

  currentStartDate = this.startDateSource.asObservable();
  currentEndDate = this.endDateSource.asObservable();
  currentGuests = this.guestsSource.asObservable();

  constructor() { }

  changeStartDate(startDate: Date): void {
    this.startDateSource.next(startDate);
  }

  changeEndDate(endDate: Date): void {
    this.endDateSource.next(endDate);
  }

  changeGuests(guests: number): void {
    this.guestsSource.next(guests);
  }
}
