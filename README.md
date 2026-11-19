# Stadium Management System

A desktop application built with C# (.NET WinForms) and a MySQL/MariaDB database. Customers can sign up, browse events and book tickets. Admins can manage events.

## Features
- Sign up and login (passwords are hashed)
- Customers: view and search events, buy a ticket, view their tickets
- Admins: add, update, delete and search events, and see a stats dashboard

## Architecture (MVC)
- **Models**: User, Event, EventSeat, Ticket
- **Views**: WinForms screens (Login, SignUp, dashboards, events, tickets)
- **Controllers**: User, Event, Seat and Ticket controllers (database logic)

## Setup
1. Start MySQL in XAMPP.
2. Import `Database/stadium_db.sql` in phpMyAdmin.
3. Open `StadiumMS.slnx` in Visual Studio and press F5.

Default admin: `admin@stadium.com` / `admin123`

## Tech
C#, .NET WinForms, MySQL/MariaDB (XAMPP), MySqlConnector
