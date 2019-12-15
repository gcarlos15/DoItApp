USE DoItDB
GO

CREATE TABLE Cuenta (
	Usuario varchar(25) primary key not null,
	Contrasena varchar(25) not null
)

CREATE TABLE Persona (
	Usuario varchar(25) primary key not null,
	Nombre varchar(45) not null,
	Apellido varchar(75) not null,
	Genero bit not null,
	Edad int not null
)

ALTER TABLE Persona
ADD FOREIGN KEY (Usuario)
REFERENCES CUENTA(Usuario)
ON DELETE CASCADE
ON UPDATE CASCADE

CREATE TABLE Tarea (
	Id int IDENTITY(1,1000) primary key not null,
	Titulo varchar(45) not null,
	Descripcion varchar(75) not null,
	Fecha DATE not null,
	CreatedAt DATE not null,
	Usuario varchar(25) not null,
	Hecho bit not null
)

ALTER TABLE Tarea 
ADD FOREIGN KEY (Usuario)
REFERENCES Persona(Usuario)
ON DELETE CASCADE
ON UPDATE CASCADE
