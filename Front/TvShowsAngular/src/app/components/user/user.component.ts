import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  users: User[] = [];
  user: User = { name: '', email: '', password: '' };
  isNew: boolean = false;
  isEditing: boolean = false;
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(private userService: UsersService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  // Método para convertir el nombre a mayúsculas
  convertToUppercase(): void {
    this.user.name = this.user.name.toUpperCase();
  }

  loadUsers(): void {
    this.isLoading = true;
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.users = data.data;
        this.isLoading = false;
      },
      error: (err:any) => {
        this.errorMessage = 'Error loading users: ' + err.message;
        this.isLoading = false;
      }
    });
  }

  createNewUser(): void {
    this.user = { name: '', email: '', password: '' };
    this.isNew = true;
    this.isEditing = false;
  }

  editUser(user: User): void {
    this.user = { ...user }; // Crea una copia del usuario para edición
    this.isNew = true;
    this.isEditing = true;
  }

  saveUser(): void {
    if (this.isEditing) {
      // Llamar al servicio de actualización
      this.userService.updateUser(this.user.id!, this.user).subscribe({
        next: () => {
          this.errorMessage = 'Usuario actualizado exitosamente';
          this.resetForm();
        },
        error: (err:any) => {
          this.errorMessage = 'Error actualizando el usuario: ' + err.message;
        }
      });
    } else {
      // Llamar al servicio de alta de usuario
      this.userService.addUser(this.user).subscribe({
        next: () => {
          this.errorMessage = 'Usuario registrado exitosamente';
          this.resetForm();
        },
        error: (err:any) => {
          this.errorMessage = 'Error registrando el usuario: ' + err.message;
        }
      });
    }
  }

  cancel(): void {
    this.isNew = false;
    this.isEditing = false;
    this.loadUsers();
    this.errorMessage = '';
  }

  // Método para restablecer el formulario
  resetForm(): void {
    this.user = { name: '', email: '', password: '' };
  }

  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe({
      next: () => {
        this.errorMessage = 'Usuario eliminado exitosamente';
        this.loadUsers();
      },
      error: (err: any) => {
        this.errorMessage = 'Error eliminando el usuario: ' + err.message;
      }
    });
  }
}
