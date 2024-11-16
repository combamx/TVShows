import { Component } from '@angular/core';
import { ApiResponse } from 'src/app/models/api-response';
import { TVShowData } from 'src/app/models/tvshow-data';
import { TvShowsService } from 'src/app/services/tv-shows.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  isLoading: boolean = true;
  tvShows: TVShowData[] = []; // Array para almacenar los shows
  errorMessage: string = ''; // Variable para almacenar mensajes de error

  constructor(private tvShowsService: TvShowsService) { }

  ngOnInit(): void {
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

}
