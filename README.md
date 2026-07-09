# Union Financiar Tiranë Management System





A web application inspired by the Union Financiar Tiranë platform, developed using \*\*ASP.NET Core MVC\*\*, \*\*C#\*\*, \*\*Entity Framework Core\*\*, and \*\*SQL Server\*\*.



The application allows users to register, log in, send payments, view transaction history, and manage their transactions through a secure web interface.



### Features



\- User Registration and Login

\- Authentication and Authorization

\- Send Payments

\- View Transaction History

\- Generate Unique Transaction Codes

\- Edit Existing Transactions

\- Delete Transactions

\- Company Information Homepage

\- Search Bar

\- Navigation Between Pages



### Technologies Used



\- ASP.NET Core MVC

\- C#

\- Entity Framework Core

\- SQL Server

\- HTML5

\- CSS3

\- Razor Views

\- Bootstrap (if used)



### Project Structure



```

Finance/

│── Controllers/

│   ├── DergonsController.cs

│   ├── LoginController.cs

│   ├── RegisterController.cs

│   └── ...

│

│── Models/

│── Views/

│── Data/

│── wwwroot/

│── Program.cs

│── appsettings.json

└── README.md

```



### Main Functionality



#### User Authentication



\- User registration

\- Secure login

\- Authorization using ASP.NET Core Identity



#### Payment Management



Authenticated users can:



\- Create a new payment

\- Generate a unique payment code automatically

\- View only their own payment history

\- Edit payment information

\- Delete transactions



#### Transaction History



Each logged-in user can access a personal list of previous transactions.



#### Database



The project uses \*\*Entity Framework Core\*\* with \*\*SQL Server\*\* to store:



\- User accounts

\- Payment information

\- Transaction records



### Screenshots

![UFT_Image_1.png](./images/UFT_Image_1.png)
![UFT_Image_2.png](./images/UFT_Image_2.png)
![UFT_Image_3.png](./images/UFT_Image_3.png)
![UFT_Image_4.png](./images/UFT_Image_4.png)

### 

### How to Run



1\. Clone the repository.



```

git clone https://github.com/yourusername/yourrepository.git

```



2\. Open the solution in Visual Studio.



3\. Restore NuGet packages.



4\. Update the database connection string inside:



```

appsettings.json

```



5\. Apply migrations:



```

Update-Database

```



6\. Run the project.

### 

### Future Improvements



\- Email verification

\- Online payment gateway integration

\- Admin dashboard

\- Transaction filtering

\- Mobile responsive design

\- Password recovery

\- Transaction export (PDF/Excel)



### Author



Created by \*\*Jugera Lameborshi\*\*.

