import { Component, OnInit } from '@angular/core';
import { TvShowsService } from '../../services/tv-shows.service';
import { TVShowData } from '../../models/tvshow-data';
import { ApiResponse } from '../../models/api-response';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tv-show',
  templateUrl: './tv-show.component.html',
  styleUrls: ['./tv-show.component.css']
})
export class TvShowComponent implements OnInit {

  isLoading: boolean = true;
  isNew: boolean = false;
  tvShows: TVShowData[] = []; // Array para almacenar los shows
  tvShow: TVShowData = { id: 0, name: '', favorite: false, content: '', format: '', episodes: '', duration: '', scenarios: '', classification: '', image: '' };
  errorMessage: string = ''; // Variable para almacenar mensajes de error

  constructor(private tvShowsService: TvShowsService, private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadTvShows();
  }

  submitTvShow(): void {
    this.tvShowsService.addTvShow(this.tvShow).subscribe({
      next: (response) => {
        console.log('TV Show added successfully', response);
        this.isNew = false; // Ocultar el formulario después de guardar
        this.refreshData();
      },
      error: (error) => {
        console.error('Error adding TV Show:', error);
      }
    });
  }

  // Método para cargar los TV Shows
  loadTvShows(): void {
    // Llamar al servicio para obtener los shows
    this.tvShowsService.getTvShows(1, 50).subscribe({
      next: (response: ApiResponse<TVShowData[]>) => {
        this.isLoading = false;
        if (response.status === 200) {
          this.tvShows = response.data;
        } else {
          this.errorMessage = response.errorMessage || 'Error fetching TV shows';
        }
      },
      error: (error) => {
        this.isLoading = false;
        this.errorMessage = 'Error fetching TV shows: ' + error.message;
      }
    });
  }

  // Método para eliminar un TVShow
  deleteTvShow(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar este TV Show?')) {
      this.tvShowsService.deleteTvShow(id).subscribe({
        next: (response) => {
          console.log('TV Show eliminado exitosamente', response);
          this.refreshData();
        },
        error: (error) => {
          console.error('Error al eliminar el TV Show:', error);
        }
      });
    }
  }

  // Método que puedes llamar manualmente para volver a cargar los datos
  refreshData(): void {
    this.loadTvShows();
  }

}
