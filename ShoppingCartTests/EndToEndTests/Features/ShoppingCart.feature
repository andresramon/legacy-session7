Feature: ShoppingCart
The shopping cart should allow the typical scenarios including creating a cart,
adding products and calculating price. All scenarios will assume that the following items exist:

In the product repository
Code         | Name                     |  Price
--------------------------------------------------
VOUCHER      | AcME Voucher             |   5.00 €
T-SHIRT      | AcME T-Shirt             |  20.00 €
MUG          | AcME Coffee Mug          |   7.50 €

In the user repository

Name
--------------------------------------------------
John

@EndToEnd
Scenario: Create shopping cart with multiple products
    Given that a John has an empty shopping cart
    And John adds a "VOUCHER"
    And John adds a "T-SHIRT"
    And John adds a "MUG"
    When John requests cart price
    Then John's shopping cart total should be 32.5