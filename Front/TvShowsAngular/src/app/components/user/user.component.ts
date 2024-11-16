import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../services/users.service';
import { User } from '../../models/user';
import { ApiResponse } from 'src/app/models/api-response';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  users: ApiResponse<User[]> = { data: [], page: 0, rows: 0, counts: 0, status: 0, errorMessage: '' };          // Array para almacenar los usuarios
  errorMessage: string = '';   // Variable para almacenar mensajes de error

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    // Llamar al servicio para obtener los usuarios
    this.usersService.getAllUsers().subscribe({
      next: (response) => {
        if (response.status === 200) {
          this.users = response;
        } else {
          this.errorMessage = response.errorMessage || 'Error fetching users';
        }
      },
      error: (error) => {
        this.errorMessage = 'Error fetching users: ' + error.message;
      }
    });
  }

}
