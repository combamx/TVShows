import { animate } from '@angular/animations';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticated = false; // Estado de autenticación

  constructor(private router: Router) {}

  // Método para manejar el inicio de sesión
  login(email: string, password: string): boolean {
    // Aquí llamas a tu API para verificar las credenciales del usuario
    // Esto es solo un ejemplo básico
    if (email === 'user@example.com' && password === 'password123') {
      console.log('Inicio de sesión exitoso');
      this.isAuthenticated = true;
      localStorage.setItem('isAuthenticated', 'true'); // Guarda el estado en localStorage
      return true;
    } else {
      this.isAuthenticated = false;
      return false;
    }
  }

  // Método para verificar si el usuario está autenticado
  isLoggedIn(): boolean {
    console.log(localStorage.getItem('isAuthenticated'));
    if (localStorage.getItem('isAuthenticated') !== 'true') {
      this.router.navigate(['/login']);

      return false;
    }
    return true;
  }

  // Método para manejar el cierre de sesión
  logout(): void {
    this.isAuthenticated = false;
    localStorage.removeItem('isAuthenticated');
    this.router.navigate(['/login']); // Redirige al usuario a la página de inicio de sesión
  }
}
