
# Store Management CLI Application

This is a CLI application for store resource management. It serves as a demonstration of product management within a store environment.

## Tech Stack
This application is built using the following technologies:

- **Programming Language:** C#

- **Framework:** .NET

- **Data Serialization:** JSON


## Functionalities

- Adding new products


The staff can manually input product details or leverage RFID technology for a more efficient addition method. With RFID technology, all relevant data is effortlessly collected from the chip and can be seamlessly integrated into the program interface.

- Deleting and modifying products based on unique IDs


Each product is assigned a unique identification (ID), enabling staff to easily delete or modify products when necessary. Modification process is designed to update filled fields while retaining empty fields in their current state.

- Finding a product by id


Efficiently locate products within the store by utilizing the search functionality based on the unique product ID. This feature is essential for checking product availability and obtaining detailed product descriptions.

- Listing products not in stock


Identify and manage products that are currently out of stock. The staff can generate a comprehensive list of these products and take necessary actions, such as removing them from the list or initiating a new order to replenish stock levels.

## Improvements

While the design of this application exceeded the implementation, primarily due to time constraints, there are several potential improvements:

- Order and History Modules

Introducing dedicated modules for order management and transaction history would significantly enhance the application's functionality. This addition would enable tracking of product orders, including details on the customer, timestamps, and order status. A comprehensive history module is crucial for customer retention, allowing businesses to analyze past interactions and cater to customer preferences upon return.

- Database

Currently, the application employs a JSON file for data storage. A notable improvement would involve transitioning to a more robust and scalable solution, such as a relational database with the integration of a .NET Object-Relational Mapping (ORM) framework. This upgrade would not only enhance data integrity but also provide improved querying capabilities, making the application more efficient and suitable for larger datasets.
