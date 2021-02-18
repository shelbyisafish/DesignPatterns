
This is an example of a real-world situation. We will use the Builder pattern to assess its pros and cons.

The situation is that you are the back-end api receiving online orders. Imagine the last screen of the checkout page 
for an online retailer. Those orders need to be validated before being saved.

These orders are for a pet (dog/cat) business that offers different products/services.
Products:
	- pet food, beds, toys, etc.
Services:
	- grooming
	- boarding
		- day only (dropoff/pickup time is same everyday)
		- overnight (need to schedule custom dropoff/pickup)

Every order will have the same basic info:
- Pet info
	- Name
	- Breed
	- Sex
- User info
	- Name
	- Email (username - matches account)
	- Phone
- Payment
	- Payment info	(CC, bank)
	- Billing address

Products will include product info:
	(per product)
	- Product Name
	- Product Id
	- Price
(There can be multiple products in one order.)

Services will include service info:
	- Service Name
	- Service Id
	- Price
	- Start Date
	- End Date
(There can be multiple services in one order.)

Assume that an order will be either a product OR a service. (not both)

In this situation, we'll assume the front-end does almost no validation/calculations and it just passes the user input
straight into the api as a string. Meaning, phone, email, numbers, etc. still need to be validated. Also, all non-string 
data should be parsed into the correct type.

Also assume that we do not need to validate price. The front-end already has the correct price because they 
would have needed to display the products to the user beforehand. We just need to clean that price data - 
remove any dollar signs and parse the price as a decimal.