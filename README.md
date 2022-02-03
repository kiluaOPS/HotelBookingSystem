# HotelBookingSystem
Symple API for booking hotel rooms

To create migration run:

dotnet ef migrations add InitialMigration -s .\HotelBookingSystem -p .\HotelBookingSystem.Data

To apply migrations run:

dotnet ef database update -s .\HotelBookingSystem -p .\HotelBookingSystem.Data


IMPROVEMENTS:
Add a repository Layer 
	-Benefits: Easier to moq, decouples data layer from service
Add AutoMapper to transform Entities into Dtos anbd Back
Add Pagination in Return All type of Endpoints
Add Exception Handling
Uniform Response -> Required binding return an error object and not array.
Add Logging to external service (i.e. sentry)
Add Authentication with JWT probably

Depending on scope and requirements might drop Monolith and split into microservices



