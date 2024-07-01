# Contact Manager MVC Web Application
This project is a Contact Manager MVC Web Application built with .NET 8, using Entity Framework Core for database interactions. This application allows users to manage their contacts with features like creating, viewing, editing, and deleting contact records. 
Additionally, users can add addresses to contacts and view them on a map.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites
- .NET 8.x SDK 
- Microsoft SQL Server
- Git

### Application Features
- **Display Contacts**: Show a list or grid of all contacts in the database on the main page.
- **Create Contact**: Provide a "Create Contact" button that opens a new window to create a new contact.
- **View/Edit Contact**: Double-clicking a contact or clicking a "View" button opens a popup with editable contact info.
- **Delete Contact**: Include a "Delete Contact" button with validation in the editing view.
- **Add Address**: Allow users to optionally add an address to a contact. If present, display the address on a map with a pin.
- **Basic Search:** Implement a basic search functionality to find contacts. 

### Installing
1. Clone the repository
2. Restore the dependencies: _**dotnet restore**_
3. Add the database connection string to the appsettings.json file. 
4. Run the application: **_dotnet run_**


### Contact
If you have any questions or feedback, please contact [v.artyukh@devsx.net](v.artyukh@devsx.net)