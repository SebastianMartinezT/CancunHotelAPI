# Cancun Hotel API

_API for a cancun hotel with post covid problems due to low room availability._

### Pre-requirements 📋

_Visual Studio Code or Visual Studio 2019_
_SQL Server Management_

### Debugging 🔧

_Follow these steps to have a development environment to debug or modify the API:_

_Clone the repository_

```
git clone https://github.com/SebastianMartinezT/CancunHotelAPI.git
```

_Create Database_

```
Use the database structure file to create the database
```

_Open the solution_

```
From here you can debug or modify the project
```

_Run Project_
```
when the project is executed locally put swagger so that it loads correctly:
https://localhost:port/swagger
```

## Tests ⚙️

_Methods available in the API_

```
POST /api/ReservationDetail/MakeReservation
Make a reservation

GET /api/ReservationDetail/GetReservationDetail
Get Reservation Detail

PUT /api/ReservationDetail/UpdateReservationDetail
Method in charge to update the reservation

PUT /api/ReservationDetail/CancelReservationDetail
Method in charge to Cancel the reservation


GET /api/Rooms/GetRooms
Get Rooms

GET /api/Rooms/GetAvailabilityRooms
Get Availability Rooms
```



## Made With 🛠️

* [SQL](https://docs.microsoft.com/en-us/sql/?view=sql-server-ver15) - Database used
* .Net Framework 4.5 - Framework used for the API
* Entity Framework - Framework used to map the database and access it
* [Swagger](https://swagger.io/docs/) - It generates an interactive API for the users so that they can understand about the API more quickly


## Author ✒️

* **Juan Sebastian Martinez** 
