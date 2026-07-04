--Aquí Creamos la base de datos
CREATE DATABASE DB_GestorEmpleados
GO

--Corremos el comando usar para poder trabajar dentro de la base de datos creada
USE DB_GestorEmpleados
GO


--Creamos todas las tablas igual al diagrama relacional hecho en Drawio
CREATE TABLE Cargos(
IdCargo INT PRIMARY KEY IDENTITY,--Esto hace que se cree un registro secuencial
Nombre VARCHAR(100) NOT NULL,
Activo BIT NOT NULL DEFAULT 1 --Lo inicializamos en 1, significa que esta activo
)
GO

CREATE TABLE TipoContrataciones(
IdTipoContratacion INT PRIMARY KEY IDENTITY,
Tipo VARCHAR(50) NOT NULL,
Activo BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE Sucursales(
IdSucursal INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(50) NOT NULL,
Activo BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE MotivoExoneraciones(
IdMotivoExoneracion INT PRIMARY KEY IDENTITY,
Motivo VARCHAR(50) NOT NULL,
Activo BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE Empleados(
IdEmpleado INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(200) NOT NULL,
Identificacion VARCHAR(20) NOT NULL UNIQUE,
FechaIngreso DATETIME NOT NULL,
FechaExoneracion DATETIME NOT NULL,
IdMotivoExoneracion INT FOREIGN KEY REFERENCES MotivoExoneraciones(IdMotivoExoneracion),--Esta es la manera de conectar la tabla Empleados con las tabla MotivoExoneraiones atravez del ID
IdTipoContratacion INT FOREIGN KEY REFERENCES TipoContrataciones(IdTipoContratacion),
IdSucural INT FOREIGN KEY REFERENCES Sucursales(IdSucursal),
IdCargo INT FOREIGN KEY REFERENCES Cargos(IdCargo),
Activo BIT NOT NULL DEFAULT 1
)
GO

CREATE TABLE Usuarios(
IdUsuario INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(200) NOT NULL,
Usuario VARCHAR(50) NOT NULL UNIQUE,
Contraseña VARBINARY(MAX) NOT NULL, --Es así y no INT o VARCHAR porque con una función en codigo utilizando SHA512 se genera una contraseña unica
Activo BIT NOT NULL DEFAULT 1
)
GO

--Este es el primer usuario administrador para iniciar el programa.
INSERT INTO Usuarios(Nombre, Usuario, Contraseña)
	VALUES ('Señor Usuario Administrador', 'Admin', HASHBYTES('SHA2_512','1234'))
GO

/*INSERCIONES INICIALES*/
INSERT INTO Cargos(Nombre)
	VALUES	('Asistente Contable'),
			('Analista Contable'),
			('Gerente de Contabilidad'),
			('Gerente de Administración'),
			('Administrador'),
			('Recursos Humanos'),
			('Asistente de Recursos Humanos'),
			('Arquitecto'),
			('Ingeniero')
GO

INSERT INTO Sucursales(Nombre)
	VALUES	('Managua - Camino Oriente'),
			('Managua - Las Palmas'),
			('Managua - Centro America'),
			('Masaya'),
			('Leon'),
			('Matagalpa')
GO

INSERT INTO TipoContrataciones(Tipo)
	VALUES	('Motivo no establecido'),
			('Contrato nominal'),
			('Servicio Profesional'),
			(''),