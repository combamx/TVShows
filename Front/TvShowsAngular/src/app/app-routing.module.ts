import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TvShowComponent } from './components/tv-show/tv-show.component';
import { UserComponent } from './components/user/user.component';
import { TvShowDetailComponent } from './components/tv-show-detail/tv-show-detail.component';
import { LoginComponent } from './components/login/login.component';
import { authGuard } from './services/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home',
    canActivate: [authGuard]
  },
  {
    path: 'tv-show',
    component: TvShowComponent,
    title: 'TV Show',
    canActivate: [authGuard]
  },
  {
    path: 'user',
    component: UserComponent,
    title: 'Usuarios',

  },
  {
    path: 'tv-show-detail/:id',
    component: TvShowDetailComponent,
    title: 'Detalle TV Show',
    canActivate: [authGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
    title: 'Autentificarse',
  },

  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
