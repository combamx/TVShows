import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response'; // Ajusta la ruta según tu proyecto
import { TVShowData } from '../models/tvshow-data';    // Ajusta la ruta según tu proyecto

@Injectable({
  providedIn: 'root'
})
export class TvShowsService {
  private apiUrl = 'https://localhost:7220/api/TvShowsData'; // URL base de la API

  constructor(private http: HttpClient) {}

  // Método para obtener los shows con paginación
  getTvShows(page: number, rows: number): Observable<ApiResponse<TVShowData[]>> {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('rows', rows.toString());

    // URL ajustada para la llamada GET con parámetros
    return this.http.get<ApiResponse<TVShowData[]>>(`${this.apiUrl}/GetAllContext`, { params });
  }

  // Método para obtener un TVShow por Id
  getTvShowById(id: number): Observable<ApiResponse<TVShowData>> {
    return this.http.get<ApiResponse<TVShowData>>(`${this.apiUrl}/GetByIdContext/${id}`);
  }

  // Método para agregar un nuevo TVShow
  addTvShow(tvShow: TVShowData): Observable<any> {

    console.log('addTvShow', tvShow);

    const formData = new FormData();

    // Agregar los campos al FormData
    formData.append('name', tvShow.name);
    formData.append('content', tvShow.content);
    formData.append('format', tvShow.format);
    formData.append('episodes', tvShow.episodes);
    formData.append('duration', tvShow.duration);
    formData.append('scenarios', tvShow.scenarios);
    formData.append('classification', tvShow.classification);
    formData.append('image', tvShow.image);
    formData.append('favorite', tvShow.favorite ? 'true' : 'false');

    // Realizar la solicitud POST con FormData
    return this.http.post<any>(`${this.apiUrl}/AddContext`, formData);
  }

  // Método para actualizar un TVShow usando FormData
  updateTvShow(id: number, tvShow: TVShowData): Observable<any> {
    const formData = new FormData();

    // Agregar los campos al FormData
    formData.append('id', id.toString());
    formData.append('name', tvShow.name);
    formData.append('content', tvShow.content);
    formData.append('format', tvShow.format);
    formData.append('episodes', tvShow.episodes);
    formData.append('duration', tvShow.duration);
    formData.append('scenarios', tvShow.scenarios);
    formData.append('classification', tvShow.classification);
    formData.append('image', tvShow.image);
    formData.append('favorite', tvShow.favorite ? 'true' : 'false');

    // Realizar la solicitud PUT con FormData
    return this.http.put(`${this.apiUrl}/UpdateContext`, formData);
  }


   // Método para eliminar un TVShow por Id
   deleteTvShow(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/DeleteContext/${id}`);
  }
}
