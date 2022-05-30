import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProperty } from '../models/property';
import { IReservation } from '../models/reservation';
import { IReservationCreate } from '../models/reservationCreate';
import { IReservationUpdate } from '../models/reservationUpdate';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = "https://localhost:7154";
  constructor(private http: HttpClient) { }

  getCurrentUser(): Observable<IUser> {
    return this.http.get<IUser>(this.baseUrl + '/api/Users/current');
  }

  getAllProperties(): Observable<IProperty[]> {
    return this.http.get<IProperty[]>(this.baseUrl + '/api/Properties');
  }

  getPropertyById(id: number): Observable<IProperty> {
    return this.http.get<IProperty>(`${this.baseUrl}/api/Properties/${id}`);
  }

  makeReservation(reservation: IReservationCreate): Observable<IReservation> {
    return this.http.post<IReservation>(`${this.baseUrl}/api/Reservations/current`, reservation);
  }

  deleteReservation(reservationId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/api/Reservations/current/${reservationId}`);
  }

  getReservations(): Observable<IReservation[]> {
    return this.http.get<IReservation[]>(this.baseUrl + '/api/Reservations/current');
  }

  getReservationById(reservationId: number): Observable<IReservation> {
    return this.http.get<IReservation>(`${this.baseUrl}/api/Reservations/current/${reservationId}`)
  }

  updateReservation(reservationId: number, reservation: IReservationUpdate): Observable<IReservation> {
    return this.http.put<IReservation>(`${this.baseUrl}/api/Reservations/current/${reservationId}`, reservation);
  }
}
