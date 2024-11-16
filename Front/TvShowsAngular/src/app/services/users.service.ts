import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response';
import { User } from '../models/user';
import { TVShowData } from '../models/tvshow-data';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private apiUrl = 'https://localhost:7220/api/UsersData'; // URL de la API

  constructor(private http: HttpClient) { }

  // Método para obtener todos los usuarios
  getAllUsers(): Observable<ApiResponse<User[]>> {
    return this.http.get<ApiResponse<User[]>>(`${this.apiUrl}/GetAllUsers`);
  }

}
