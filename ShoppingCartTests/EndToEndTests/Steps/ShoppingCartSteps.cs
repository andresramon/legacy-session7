using FluentAssertions;
using ShoppingCartApi.Domain.Entities.Base;

namespace ShoppingCartTests.EndToEndTests.Steps;

[Binding]
public class RealShoppingCartSteps
{
    private Id _shoppingCartId = new Id();
    private decimal _cartPrice;
    private readonly HttpClient _client;
    public RealShoppingCartSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5000");
    }

    [Given(@"that a John has an empty shopping cart")]
    public async Task GivenThatAJohnHasAnEmptyShoppingCart()
    {
        var createCartUrl = $"/ShoppingCart/CreateEmptyCart?customerName=John";
        
        var response = await _client.PostAsync(createCartUrl, null);
     
        _shoppingCartId = await response.Content.ReadAsAsync<Id>();
    }
    

    [Given(@"John adds a ""(.*)""")]
    public async Task GivenJohnAddsA(string product)
    {
        var param = $"shoppingCartId={_shoppingCartId.id}&productCode={product}";
        
        var addProductUrl = $"/ShoppingCart/AddProduct?{param}";

        await _client.PutAsync(addProductUrl,null);
    }

    [When(@"John requests cart price")]
    public async Task WhenJohnRequestsCartPrice()
    {
        var param = $"shoppingCartId={_shoppingCartId.id}";
        var getPriceUrl = $"/CheckOut/GetCartTotal?{param}";
        
        var response = await _client.GetAsync(getPriceUrl);
     
        _cartPrice = await response.Content.ReadAsAsync<Decimal>();
    }

    [Then(@"John's shopping cart total should be (.*)")]
    public void ThenJohnsShoppingCartTotalShouldBe(decimal price)
    {
        _cartPrice.Should().Be(price);
    }
}