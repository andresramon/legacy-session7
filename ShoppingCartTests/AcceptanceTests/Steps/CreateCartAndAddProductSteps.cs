using FakeItEasy;
using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.AppServices.UseCases;
using ShoppingCartApi.Domain.Entities;
using ShoppingCartApi.Domain.Entities.Base;
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
        
            ShoppingCart shoppingCart = new ShoppingCart(new Id(),new Customer(customer));
            CreateEmptyCartUseCase useCase = new CreateEmptyCartUseCase(cartRepository,customerRepository);
        
            useCase.CreateFor(customer);
        
            A.CallTo(() =>  cartRepository.Create(shoppingCart)).MustHaveHappened();
            A.CallTo(() =>  customerRepository.GetUserByName(customer)).MustHaveHappened();

        }

        [When(@"we add a Voucher")]
        public void WhenWeAddAVoucher()
        {
            IShoppingCartRepository cartRepository = A.Fake<IShoppingCartRepository>();
            IProductRepository productRepository = A.Fake<IProductRepository>();
        
            ShoppingCart shoppingCart = new ShoppingCart(new Id(),new Customer(customer));
            AddProductToCartUseCase useCase = new AddProductToCartUseCase(cartRepository, productRepository);

            A.CallTo(() =>  cartRepository.Save(shoppingCart)).MustHaveHappened();
        }

        [Then(@"the shopping cart price should be (.*)")]
        public void ThenTheShoppingCartPriceShouldBe(int price)
        {
            ScenarioContext.StepIsPending();
        }
    }
}