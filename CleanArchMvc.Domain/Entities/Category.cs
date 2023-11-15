﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string? Name { get; private set; }

        public Category(string name)
        {
            //Name = name ?? throw new ArgumentException("name is invalid");
            
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name);

        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product>? Products { get; set; }


        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short. Minimun 3 characters");

            Name = name;
        }
    }
}
