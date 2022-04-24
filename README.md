# Local Business Lookup
##### By Chris DePastene
#
------------------------------

### <u>Table of Contents</u>
* <a href="#-about-the-project">About the Project</a>
    * <a href="#-description">Description</a>
    * <a href="#-known-bugs">Known Bugs</a>
    * <a href="#-built-with">Built With</a>
* <a href="#-getting-started">Getting Started</a>
    * <a href="#-prerequisites">Prerequisites</a>
    * <a href="#-setup-and-use">Setup and Use</a>
* <a href="#-api-documentation">API Documentation</a>
* <a href="#-license">License</a>
    
------------------------------
## About the Project

### Description
An API that allows a user to view, post, edit, and delete local business entries. Users can also filter data using search parameters

### Known Bugs

* There are no known bugs at this time.

### Built With
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL](https://dev.mysql.com/)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [Visual Studio Code](https://code.visualstudio.com/)
* [Postman](postman.com)

------------------------------

## Getting Started

### Prerequisites

##### Install .NET Core
* Select version and OS [here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer)

##### Install dotnet script
 * Enter command ``dotnet tool install -g dotnet-script`` in your terminal.

##### Install MySQL Workbench
 * Select version and OS [here](https://dev.mysql.com/downloads/workbench/).

##### Install Postman
* Select from OS options [here](https://www.postman.com/downloads/).

##### Code Editor

  * To view or edit the code, you will need an code editor or text editor. I use [Visual Studio Code](https://code.visualstudio.com/Download)

### Setup and Use

  #### Cloning

  1) Clone [this repository](https://github.com/chrisdfghjkl/LocalBusiness.Solution) to your desktop.
  2) Using your terminal, navigate to the root folder of the project directory
  3) Run `code .` to launch the project in VS Code


  #### AppSettings

  1) Create a new file in the LocalBusiness directory named `appsettings.json`
  2) Add in the following code snippet to the new file:
  
  ```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[database_name];uid=root;pwd=[your_password];"
  }
}
  ```
  3) Replace [database_name] and [your_password] with the correct name and password (be sure to remove the brackets)

#### Database
  1) From the LocalBusiness directory, run `dotnet ef database update` to generate the database through Entity Framework Core.
  2) (Optional) To update the database with any changes to the code, run the command `dotnet ef migrations add [Migration_Name]` which will generate a database update. Then run `dotnet ef database update` again to update the database.

  #### Launch the API
  * From the LocalBusiness directory, run `dotnet run` to have access to the API in Postman or browser.
  ___________________________
  ## API Documentation
  Explore the API endpoints in Postman or a browser.
  
  ### Endpoints
  Base URL: `https://localhost:5000`
 
  
   #### HTTP Request Structure
  ```
  GET /api/{component}
  POST /api/{component}
  GET /api/{component}/{id}
  PUT /api/{component}/{id}
  DELETE /api/{component}/{id}
  
  ```
### GET /businesses
 #### Example Query
  ```
  http://localhost:5000/api/businesses
  ```
  
  #### Sample JSON Response
  ```
    {
        "businessId": 1,
        "name": "Cubo",
        "category": "Food & Drink",
        "description": "Cuban joint serves up homestyle fare plus cocktails in casual, vibrant surrounds with a patio.",
        "phone": "(971) 544-7801",
        "address": "3106 SE Hawthorne Blvd",
        "city": "Portland",
        "state": "OR",
        "zip": "97214"
    },
    {
        "businessId": 2,
        "name": "Gado Gado",
        "category": "Food & Drink",
        "description": "Asian fusion dishes in quaint surrounds",
        "phone": "(503) 206-8778",
        "address": "1801 NE Cesar E Chavez Blvd",
        "city": "Portland",
        "state": "OR",
        "zip": "97212"
    },
    {
        "businessId": 3,
        "name": "Powell's City of Books",
        "category": "Retail",
        "description": "Iconic bookstore occupying a city block",
        "phone": "(971) 544-7801",
        "address": "1005 W Burnside St",
        "city": "Portland",
        "state": "OR",
        "zip": "97214"
    }
  ```

  #### Path Parameters

  | Parameter | Type | Default | Required | Description |
  | :---: | :---: | :---: | :---: | --- |
  | category | string | none | false | The business type (eg. Food & Drink, Retail, Service, Entertainment, etc.)
  | state | string | none | false | the state where the business is located 
  | city | string | none | false | the city where the business is located  
  | zip | string | none | false| the zip code where the business is located 


  This route allows you to filter businesses by parameter 
  
  #### Example Query
  ```
  http://localhost:5000/api/businesses/?category=food+%26+drink&city=utica
  ```
  #### Sample JSON Response
  ```
    {
        "businessId": 7,
        "name": "O'Scugnizzo Pizzeria",
        "category": "Food & Drink",
        "description": "Stalwart, pizza-centric Italian eatery",
        "phone": "(315) 732-6149",
        "address": "614 Bleecker St",
        "city": "Utica",
        "state": "NY",
        "zip": "13501"
    }
  ```
  
  ### GET /businesses/{id}
  

  | Parameter | Type | Default | Required | Description |
  | :---: | :---: | :---: | :---: | --- |
  | businessId | int | none | true | the id number of the business you are looking for


  This route allows you to view a business by the id 
  
  #### Example Query
  ```
  http://localhost:5000/api/businesses/4
  ```
  #### Sample JSON Response
  ```
{
    "businessId": 4,
    "name": "Hollywood Theatre",
    "category": "Entertainment",
    "description": "Historic movie house showing indie films.",
    "phone": "(503) 493-1128",
    "address": "4122 NE Sandy Blvd",
    "city": "Portland",
    "state": "OR",
    "zip": "97212"
}
  ```

  ### POST /businesses

  This route allows you to add a new business by putting code like this into the request body:
  ```
{
    "name": "Gladys Bikes",
    "category": "Retail",
    "description": "Cycle shop selling customized bikes, clothing & gear, plus a repair & fitting service.",
    "phone": "(971) 373-8388",
    "address": "2905 NE Alberta St",
    "city": "Portland",
    "state": "OR",
    "zip": "97211"
}
  ```

  #### Example Query
  ```
  https://localhost:5000/api/businesses
  ```
  #### Sample JSON Response
  ```
{
    "businessId": 8,
    "name": "Gladys Bikes",
    "category": "Retail",
    "description": "Cycle shop selling customized bikes, clothing & gear, plus a repair & fitting service.",
    "phone": "(971) 373-8388",
    "address": "2905 NE Alberta St",
    "city": "Portland",
    "state": "OR",
    "zip": "97211"
}
  ```

  ### DELETE /businesses/{id}

  This route allows you to delete a business by the id

  #### Example Query
  ```
  https://localhost:5000/api/businesses/8
  ```

  ### PUT /businesses/{id}

  This route allows you to update a business entry by putting code like this (note the updated description) into the body of the request of an existing business:
  ```
{
    "businessId": 8,
    "name": "Gladys Bikes",
    "category": "Retail",
    "description": "Bicycle shop for cycles and gear.",
    "phone": "(971) 373-8388",
    "address": "2905 NE Alberta St",
    "city": "Portland",
    "state": "OR",
    "zip": "97211"
}
  ```
  
  #### Example Query
  ```
  https://localhost:5000/api/parks/8
  ```
  #### Sample JSON Response
  ```
{
    "businessId": 8,
    "name": "Gladys Bikes",
    "category": "Retail",
    "description": "Bicycle shop for cycles and gear.",
    "phone": "(971) 373-8388",
    "address": "2905 NE Alberta St",
    "city": "Portland",
    "state": "OR",
    "zip": "97211"
}
  ```
------------------------------


### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2022 Christopher DePastene. All Rights Reserved.

```
MIT License

Copyright (c) 2022 Christopher DePastene.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

------------------------------
