using FakeItEasy;
using FluentAssertions;
using ShoppingCartApi.AppServices.Data;
using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.AppServices.UseCases;
using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Domain.Entities.Base;
using ShoppingCartApi.Domain.Entities.Data;
using ShoppingCartApi.Domain.Services;
using Xunit;

namespace ShoppingCartTests
{
    [Binding]
    public class CreateCartAndAddProductSteps
    {
        private string customer;

        [Given(@"a empty shopping cart belonging to ""(.*)""")]
        public void GivenAEmptyShoppingCartBelongingTo(string customer)
        {
            this.customer = customer;
            IShoppingCartRepository cartRepository = A.Fake<IShoppingCartRepository>();
            ICustomerRepository customerRepository = A.Fake<ICustomerRepository>();
            Customer customerOne = new Customer(customer);

            CreateEmptyCartUseCase useCase = new CreateEmptyCartUseCase(cartRepository, customerRepository);
            A.CallTo(() => customerRepository.GetUserByName(customer)).Returns(customerOne);
            useCase.CreateFor(customer);

            A.CallTo(() =>
                cartRepository.Create(A<ShoppingCart>.That.Matches(cart =>
                    cart.ToData().Customer.Name.Equals(customerOne.ToData().Name)
                    && !cart.ToData().Products.Any()))).MustHaveHappened();
            A.CallTo(() => customerRepository.GetUserByName(customer)).MustHaveHappened();

        }

        [When(@"we add a Voucher")]
        public void WhenWeAddAVoucher()
        {
            string productCode = "VOUCHER-DEMO";
            decimal price = 9.99M;
            Product product = new Product(new Id());
            product.Restore(new ProductData(new Id(), productCode, price));
            IShoppingCartRepository cartRepository = A.Fake<IShoppingCartRepository>();
            IProductRepository productRepository = A.Fake<IProductRepository>();

            ShoppingCart shoppingCart = new ShoppingCart(new Id(), new Customer(customer));
            AddProductToCartUseCase useCase = new AddProductToCartUseCase(cartRepository, productRepository);
            A.CallTo(() => cartRepository.Get(shoppingCart.Id)).Returns(shoppingCart);
            A.CallTo(() => productRepository.GetByCode(productCode)).Returns(product);
            useCase.AddProduct(shoppingCart.Id, productCode);

            A.CallTo(() => cartRepository.Save(shoppingCart)).MustHaveHappened();
        }

        [Then(@"the shopping cart price should be (.*)")]
        public void ThenTheShoppingCartPriceShouldBe(int price)
        {
            ICartQueries cartQueries = A.Fake<ICartQueries>();
            ICartPriceService cartPriceService = new CartPriceService();
            Id id = new Id();
            A.CallTo(() => cartQueries.getProductsFromCart(id)).Returns(new List<CartProduct>()
                { new CartProduct("VOUCHER-DEMO", 5M) });
            CalculateCartPriceUseCase useCase = new CalculateCartPriceUseCase(cartPriceService, cartQueries);
            useCase.CalculateCartTotal(id).Should().Be(price);
        }
    }
}