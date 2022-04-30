--create database cancunhotel
go
use cancunhotel
go
--rooms
create table rooms(
	IdRoom int primary key identity(1,1),
	RoomNumber int,
	[State] int,
	FOREIGN KEY ([State]) REFERENCES states(IdState)
)
go
--states //available, busy, reserved,cancel,

create table states(
	IdState int primary key identity(1,1),
	StateName nvarchar(40)
)
go
--room detail
create table reservationdetail(
	IdDetail  int primary key identity(1,1),
	RoomId int,
	ArrivalDay datetime,
	DepartureDay datetime,
	StateReservation int,
	Name varchar(70),
	LastName varchar(70),
	Mail varchar(70),
	FOREIGN KEY (StateReservation) REFERENCES states(IdState),
	FOREIGN KEY (RoomId) REFERENCES rooms(IdRoom)
)

