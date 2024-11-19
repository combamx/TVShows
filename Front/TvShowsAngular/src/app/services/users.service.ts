import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response';
import { User } from '../models/user';

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

  // Obtener un usuario por ID
  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/GetByIdUser/${id}`);
  }

  // Agregar un nuevo usuario
  addUser(user: User): Observable<any> {
    const formData = new FormData();
    formData.append('name', user.name);
    formData.append('email', user.email);
    formData.append('password', user.password);

    return this.http.post(`${this.apiUrl}/AddUser`, formData);
  }

  // Obtener un usuario por correo y contraseña
  getUserByEmailPassword(email: string, password: string): Observable<User> {
    const formData = new FormData();
    formData.append('email', email);
    formData.append('password', password);

    return this.http.post<User>(`${this.apiUrl}/GetUserByEmailPassword`, formData);
  }

  // Actualizar un usuario
  updateUser(id: number, user: User): Observable<any> {
    const formData = new FormData();
    formData.append('id', id.toString());
    formData.append('name', user.name);
    formData.append('email', user.email);
    formData.append('password', user.password);

    console.log(user);

    return this.http.put(`${this.apiUrl}/UpdateUser?id=${id}`, formData);
  }

  // Eliminar un usuario por ID
  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/DeleteUser/${id}`);
  }

}
