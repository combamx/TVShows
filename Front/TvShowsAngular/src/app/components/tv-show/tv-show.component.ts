import { Component, OnInit } from '@angular/core';
import { TvShowsService } from '../../services/tv-shows.service';
import { TVShowData } from '../../models/tvshow-data';
import { ApiResponse } from '../../models/api-response';

@Component({
  selector: 'app-tv-show',
  templateUrl: './tv-show.component.html',
  styleUrls: ['./tv-show.component.css']
})
export class TvShowComponent implements OnInit {

  tvShows: ApiResponse<TVShowData[]> = { data: [], page: 0, rows: 0, counts: 0, status: 0, errorMessage: '' }; // Array para almacenar los shows
  errorMessage: string = ''; // Variable para almacenar mensajes de error

  constructor(private tvShowsService: TvShowsService) { }

  ngOnInit(): void {
    // Llamar al servicio para obtener los shows
    this.tvShowsService.getTvShows(1, 10).subscribe({
      next: (data) => this.tvShows = data,
      error: (error) => this.errorMessage = 'Error fetching TV shows: ' + error.message
    });
  }
}
