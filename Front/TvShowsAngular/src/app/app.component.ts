import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'TvShowsAngular';

  constructor(private authService: AuthService,
    private router: Router) { }

    isLogin = false;

  ngOnInit(): void {
    this.isLogin = localStorage.getItem('isAuthenticated') === 'true' ? true : false;
    console.log(this.isLogin);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isAuthenticated') === 'true' ? true : false;
  }

  logout(): void {
    this.isLogin = false;
    this.authService.logout();
  }
}
