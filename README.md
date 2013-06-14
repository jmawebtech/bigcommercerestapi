BigCommerce Rest Api
==================

This project uses the Microsoft Web API to parse BigCommerce's REST API. BigCommerce's data is returned in Json. 

To install this software, follow these steps:

1. Right click your solution and go to manage packages
2. In the search box, type web api
3. Install the first listing
4. Enable the API: https://support.bigcommerce.com/questions/1560/How+do+I+enable+the+API+for+my+store%3F

To use this project, run the console app. There are 5 methods:

GetOrdersByDateRange - Gets order by a beginning creation date and an end creation date.

GetOrderById - Gets an order by its Id

GetOrdersByIdRange - Get a list of orders between a lowest and highest order number.

GetProducts - Gets a list of order items for an order.

GetAddresses - Gets shipping addresses for an order.

This project is maintained by JMA Web Technologies. If you would like to contribute or would like to contact us for consulting, please <a href="http://www.jmawebtechnologies.com/contact">contact us</a>.
