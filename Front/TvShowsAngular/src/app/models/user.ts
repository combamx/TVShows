export interface User {
  id?: number|null;          // Id único del usuario
  name: string;        // Nombre del usuario
  email: string;       // Correo electrónico del usuario
  password: string;    // Contraseña del usuario (en un entorno real, asegúrate de no manejar contraseñas en texto plano)
}
