import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login(): void {
    if (this.authService.login(this.email, this.password)) {
      this.router.navigate(['/home']); // Redirige al usuario a la página de inicio si el inicio de sesión es exitoso
    } else {
      this.errorMessage = 'Credenciales incorrectas. Inténtalo de nuevo.';
    }
  }
}
