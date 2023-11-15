using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.50m, 77, "product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product With Negative Id Value")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.50m, 77, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Pn", "Product Description", 9.50m, 77, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters");
        }


        [Fact(DisplayName = "Create Product With Long Image Name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.50m, 77, "product image xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long. Maximum 250 characters");
        }


        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.50m, 77, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product With Empty Image Name")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.50m, 77, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Theory (DisplayName = "Create Product With Invalid Stock Value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeStockValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.50m, value, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value. It must be >= 0");
        }

    }
}
