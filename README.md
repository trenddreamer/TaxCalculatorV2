# TaxCalculator
Welcome to my Tax Calculator App

This project consists of a simple user interface and a Web Api as backend.

I use a UnitOfWork/Repository pattern on both the web api using ApplicationDbContext and the web project using IHttpClientFactory. 
The initial data required to run the application is seeded via the DataSeeder class in the web api project.

You can test the API via swagger on the backend with integrated Bearer Token Authentication.

Run update-database after you have cloned the repository and set the api and web projects to run on start.

A default user is created for you with username: admin and password: admin
and a test user is also added who does not have the admin role required to calculate tax.
If you register a user they will get the admin role automatically.

I have a BaseUrl class in TaxCalculator.Web which stores the APIBaseURL

