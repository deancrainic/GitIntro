import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProperty } from '../models/property';
import { IPropertyCreate } from '../models/propertyCreate';
import { IReservation } from '../models/reservation';
import { IReservationCreate } from '../models/reservationCreate';
import { IReservationUpdate } from '../models/reservationUpdate';
import { IUser } from '../models/user';
import { IUserCreate } from '../models/userCreate';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = "https://localhost:7154";
  constructor(private http: HttpClient) { }

  getCurrentUser(): Observable<IUser> {
    return this.http.get<IUser>(this.baseUrl + '/api/Users/current');
  }

  updateUser(user: IUserCreate): Observable<IUser> {
    return this.http.put<IUser>(this.baseUrl + '/api/Users/current', user);
  }

  getAllProperties(): Observable<IProperty[]> {
    return this.http.get<IProperty[]>(this.baseUrl + '/api/Properties');
  }

  getPropertyById(id: number): Observable<IProperty> {
    return this.http.get<IProperty>(`${this.baseUrl}/api/Properties/${id}`);
  }

  addProperty(property: IPropertyCreate): Observable<IProperty> {
    return this.http.post<IProperty>(this.baseUrl + '/api/Properties/current', property);
  }

  deleteProperty(): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/api/Properties/current`);
  }

  updateProperty(property: IPropertyCreate): Observable<IProperty> {
    return this.http.put<IProperty>(`${this.baseUrl}/api/Properties/current`, property);
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
