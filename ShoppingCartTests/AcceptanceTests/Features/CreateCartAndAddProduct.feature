Feature: CreateCartAndAddProduct

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

@AcceptanceTest
Scenario: Create cart and add product
	Given a empty shopping cart belonging to "John"
	When we add a Voucher
	Then the shopping cart price should be 5