export interface ApiResponse<T> {
  data: T;              // Datos genéricos de la respuesta
  page: number;         // Página actual de la paginación
  rows: number;         // Número de filas devueltas por página
  counts: number;       // Total de registros
  status: number;       // Código de estado HTTP de la respuesta
  errorMessage?: string; // Mensaje de error si ocurre alguno
}
