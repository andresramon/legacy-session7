using FluentAssertions;
using ShoppingCartApp.AppServices.UseCases;
using ShoppingCartApp.Controllers;
using ShoppingCartApp.Domain.Entities.Base;
using ShoppingCartApp.Domain.Entities.Data;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Infrastructure.Database;
using ShoppingCartApp.Infrastructure.Queries;
using ShoppingCartApp.Infrastructure.Repositories;

namespace ShoppingCartTests.EndToEndTests.Steps;

[Binding]
public class RealShoppingCartSteps
{
    private readonly CheckOutController _checkOutController;
    private readonly ShoppingCartController _shoppingCartController;
    private InMemoryDatabase _database;
    private Id _shoppingCartId = new Id();
    private decimal _cartPrice;
    
    public RealShoppingCartSteps()
    {
        _database = InitializeDatabase();
        
        var emptyCartUseCase = new CreateEmptyCartUseCase(new ShoppingCartRepository(_database), new CustomerRepository(_database));
        var addProductToCart = new AddProductToCartUseCase(new ShoppingCartRepository(_database), new ProductRepository(_database));
        
        _shoppingCartController = new ShoppingCartController(emptyCartUseCase,addProductToCart);

        _checkOutController = new CheckOutController(new CalculateCartPriceUseCase(new CartPriceService(), new CartQueries(_database)));
    }

    private static InMemoryDatabase InitializeDatabase()
    {
        var inMemoryDatabase = new InMemoryDatabase();
        
        inMemoryDatabase.Customers.Add(new CustomerData(new Id(),"John"));
        inMemoryDatabase.Products.Add(new ProductData(new Id(),"VOUCHER",new decimal(5)));
        inMemoryDatabase.Products.Add(new ProductData(new Id(),"T-SHIRT",new decimal(20)));
        inMemoryDatabase.Products.Add(new ProductData(new Id(),"MUG",new decimal(7.5)));
        
        return inMemoryDatabase;
    }

    [Given(@"that a John has an empty shopping cart")]
    public void GivenThatAJohnHasAnEmptyShoppingCart()
    {
        _shoppingCartId = _shoppingCartController.CreateEmptyCart("John");
    }

    [Given(@"John adds a ""(.*)""")]
    public void GivenJohnAddsA(string product)
    {
       _shoppingCartController.AddProduct(_shoppingCartId,product);
    }

    [When(@"John requests cart price")]
    public void WhenJohnRequestsCartPrice()
    {
        _cartPrice = _checkOutController.GetCartTotal(_shoppingCartId);
    }

    [Then(@"John's shopping cart total should be (.*)")]
    public void ThenJohnsShoppingCartTotalShouldBe(decimal price)
    {
        _cartPrice.Should().Be(price);
    }
}