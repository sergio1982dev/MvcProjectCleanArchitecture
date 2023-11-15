using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact (DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Create Category With Short Name Value")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ab");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimun 3 characters");
        }


        [Fact(DisplayName = "Create Category Without Name Value")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }


        [Fact(DisplayName = "Create Category With Null Name Value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

    }
}
