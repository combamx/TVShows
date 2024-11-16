import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response'; // Ajusta la ruta según tu proyecto
import { TVShowData } from '../models/tvshow-data'; // Ajusta la ruta según tu proyecto

@Injectable({
  providedIn: 'root'
})
export class TvShowsService {
  private apiUrl = 'https://localhost:7220/api/TvShowsData'; // URL base de la API

  constructor(private http: HttpClient) { }

  // Método para obtener los shows con paginación
  getTvShows(page: number, rows: number): Observable<ApiResponse<TVShowData[]>> {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('rows', rows.toString());

    return this.http.get<ApiResponse<TVShowData[]>>(this.apiUrl + '/GetAllContext', { params });
  }

}
