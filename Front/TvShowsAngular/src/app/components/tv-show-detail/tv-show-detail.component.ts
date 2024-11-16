import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tv-show-detail',
  templateUrl: './tv-show-detail.component.html',
  styleUrls: ['./tv-show-detail.component.css']
})
export class TvShowDetailComponent implements OnInit {

  idTvShow: number = 0;

  constructor(private _router: ActivatedRoute) {
  }

  ngOnInit(): void {
    this._router.params.subscribe(params => {
      console.log(params['id']);
      this.idTvShow = params['id'];
    })
  }
}
