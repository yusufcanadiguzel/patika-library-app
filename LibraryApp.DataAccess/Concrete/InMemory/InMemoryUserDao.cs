﻿using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.InMemoryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataAccess.Concrete.InMemory
{
    public class InMemoryUserDao : IUserDao
    {
        public void Add(User entity)
        {
            InMemoryDbContext.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            InMemoryDbContext.Users.Remove(entity);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            var user = InMemoryDbContext.Users.SingleOrDefault(expression.Compile());

            return user;
        }

        public List<User> GetAll(Expression<Func<User, bool>>? expression = null)
        {
            var products = expression is null
                ? InMemoryDbContext.Users.ToList()
                : InMemoryDbContext.Users.Where(expression.Compile()).ToList();

            return products;
        }

        public void Update(User entity)
        {
            var updatedEntity = Get(u => u.Id.Equals(entity.Id));

            updatedEntity.FullName = entity.FullName;
            updatedEntity.Email = entity.Email;
            updatedEntity.PhoneNumber = entity.PhoneNumber;
        }

    }
}
