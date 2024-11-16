import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TVShowData } from 'src/app/models/tvshow-data';
import { TvShowsService } from 'src/app/services/tv-shows.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tv-show-detail',
  templateUrl: './tv-show-detail.component.html',
  styleUrls: ['./tv-show-detail.component.css']
})
export class TvShowDetailComponent implements OnInit {

  errorMessage: string = '';
  idTvShow: number = 0;
  tvShow: TVShowData = { id: 0, name: '', favorite: false, content: '', format: '', episodes: '', duration: '', scenarios: '', classification: '', image: '' };

  constructor(private router: Router, private _router: ActivatedRoute, private tvShowsService: TvShowsService, private route: ActivatedRoute) {
    this.idTvShow = +this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this._router.params.subscribe(params => {
      console.log(params['id']);
      this.idTvShow = params['id'];
      this.getTvShow();
    })
  }

  getTvShow(): void {
    this.tvShowsService.getTvShowById(this.idTvShow).subscribe({
      next: (response) => {
        this.tvShow = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error fetching TV Show: ' + error.message;
      }
    });
  }

  updateTvShow(): void {
    this.tvShowsService.updateTvShow(this.idTvShow, this.tvShow).subscribe({
      next: (response) => {
        console.log('TV Show updated successfully', response);
        this.redirectToPage();
      },
      error: (error) => {
        console.error('Error updating TV Show:', error);
      }
    });
  }

  // Método para redirigir a otra página
  redirectToPage(): void {
    this.router.navigate(['/tv-show']);
  }
}
