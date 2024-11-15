﻿using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Lista en memoria para almacenar usuarios
        private readonly List<User> _users;
        private int _nextId = 1; // Contador para los Ids de los usuarios

        public UserRepository ( )
        {
            // Inicializando la lista con algunos datos de ejemplo
            _users = new List<User>
            {
                new User { Id = _nextId++, Name = "John Doe", Email = "john.doe@example.com", Password = "hashed_password_123" },
                new User { Id = _nextId++, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "hashed_password_456" }
            };
        }

        public Task<IEnumerable<User>> GetAllAsync ( )
        {
            return Task.FromResult ( _users.AsEnumerable ( ) );
        }

        public Task<User> GetByIdAsync ( int id )
        {
            var user = _users.FirstOrDefault ( u => u.Id == id );
            return Task.FromResult ( user );
        }

        public Task<User> AddAsync ( User user )
        {
            user.Id = _nextId++; // Asignar un Id único al nuevo usuario
            _users.Add ( user );
            return Task.FromResult ( user );
        }

        public Task<User> UpdateAsync ( User user )
        {
            var existingUser = _users.FirstOrDefault ( u => u.Id == user.Id );
            if (existingUser == null)
                return Task.FromResult<User> ( null );

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            return Task.FromResult ( existingUser );
        }

        public Task<bool> DeleteAsync ( int id )
        {
            var user = _users.FirstOrDefault ( u => u.Id == id );
            if (user == null)
                return Task.FromResult ( false );

            _users.Remove ( user );
            return Task.FromResult ( true );
        }
    }
}