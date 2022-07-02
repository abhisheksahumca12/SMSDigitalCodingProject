# SMSDigitalCodingProject - SCREENSHOTS AND STEPS FOR WEB API WITH CRUD OPERATIONS 

![image](https://user-images.githubusercontent.com/60474734/176987884-507ffce3-412a-49d3-a8ff-43421ede75af.png)
![image](https://user-images.githubusercontent.com/60474734/176987679-1ea7ab7f-1e25-4f35-8f92-16c1dabf929c.png)
![image](https://user-images.githubusercontent.com/60474734/176987704-8b6c7661-cbbe-418d-a0bf-09a49b032dd2.png)

We can use swagger for performing authentication and CRUD operations.
![image](https://user-images.githubusercontent.com/60474734/176987748-78d1631b-25fd-437b-aee6-3b9422a6cacf.png)
![image](https://user-images.githubusercontent.com/60474734/176987959-e7977a40-541a-4ec2-b959-9a663965d886.png)

Create a .NET 6 Web Api for Coding. 

Note: Username and Password is HardCoded for Authentication and Token generation usig JWT(JSON Web Token). 

First Install Required Nuget Packages 

=> Install-Package Microsoft.EntityFrameworkCore 

=> Install-Package Microsoft.EntityFrameworkCore.SqlServer 

=> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer 

Add the Model to the Application Class named 'CityDetail' 

Add Data Access Layer to the Application named DatabaseContext: DbContext (as base class). 

Create a Repository with Interface named 'ICityDetailRepo' and Class named 'CityDetailRepo' to handle database-related operations. 

Add Connection string in Appsetting.json and configure dbcontext service 'Program.cs' accordingly. 

Run migration command 'Add-Migration' in package manager console that will create a migration class with Up and Down Method. 

Then use 'Update-Database' command to create Database using last Migration file. 

Add the Web API Controller named 'CityController' to the Application with required http verbs, routes over CRUD Action Methods and Authorize attibutes over controller. 

Add TokenController for User Authentication, if username and password is correct then it will create a JWT bearer token from Post method.We will use this token with every request we send from client side to server to check authenticated user access resources of api. 

Add jwt keys in appsetting.json and Configure middleware in program.cs by adding AddAuthentication service accordingly. 

Create unit test cases using xUnit Test Framework.Create a new project with name 'SMSDigitalTest'. 

Add project dependency in Test Framework to perform unit tests.  

Using nuget package manager, Add required packages Moq, FluentAssertion, Looging.Abstraction and check the other required dependecies and install. 

Create a class for Mock Data named 'MockData'. 

Create a controller with name 'UnitTestController' to perform unit test cases on CRUD operations of web api with different desired cases. 

Run the Application and Test APIs with Postman. 

Note :- LaunchSetting.json launchUrl is api/token. 

Steps for testing using Postman are below - 

Note: - Username and password provided in TokenController 'GetUser' Method. Select IISExpress. 

https://localhost:44320/api/token :- first provide username and password using post method and json format, you will get token then perform GET and CRUD operations using  URL https://localhost:44320/api/city/GetCities and https://localhost:44320/api/city/AddCity.
Screenshots above.
