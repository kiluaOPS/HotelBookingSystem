# HotelBookingSystem
Symple API for booking hotel rooms

To create migration run:

dotnet ef migrations add InitialMigration -s .\HotelBookingSystem -p .\HotelBookingSystem.Data

To apply migrations run:

dotnet ef database update -s .\HotelBookingSystem -p .\HotelBookingSystem.Data

