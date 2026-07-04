USE DB_GestorEmpleados
GO

CREATE PROCEDURE InsertEmpleado
@Nombre VARCHAR(200),
@FechaIngreso DATETIME,
@FechaExoneracion DATETIME,
@IdMotivoExoneracion INT,
@IdTipoContratacion INT,
@IdSucursal INT,
@IdCargo INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Empleados(Nombre, Identificacion, FechaIngreso, FechaExoneracion, IdMotivoExoneracion, IdTipoContratacion, IdSucural, IdCargo)
			 VALUES (@Nombre, 'temporal', @FechaIngreso, @FechaExoneracion, @IdMotivoExoneracion, @IdTipoContratacion, @IdSucursal, @IdCargo)
			
			--Capturamos el Id de la insersion
			DECLARE @EmpleadoId INT;
			SET @EmpleadoId = SCOPE_IDENTITY();

			DECLARE @Codigo VARCHAR(20);
			SET @Codigo = 'EMP' + RIGHT('000000' + CAST(@EmpleadoId AS varchar(6)),6);

			UPDATE Empleados
			SET Identificacion = @Codigo
			WHERE IdEmpleado = @EmpleadoId;

			SELECT @EmpleadoId;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE();

		IF XACT_STATE() = 1
		BEGIN
			ROLLBACK TRANSACTION;
		END
		ELSE IF XACT_STATE() = -1
		BEGIN
			ROLLBACK TRANSACTION;
		END;
		THROW
	END CATCH
END
GO

CREATE PROCEDURE UpdateEmpleado
@Nombre VARCHAR(200),
@FechaIngreso DATETIME,
@FechaExoneracion DATETIME,
@IdMotivoExoneracion INT,
@IdTipoContratacion INT,
@IdSucursal INT,
@IdCargo INT,
@IdEmpleado INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			UPDATE Empleados
				SET Nombre = @Nombre,
					FechaIngreso = @FechaIngreso,
					FechaExoneracion = @FechaExoneracion,
					IdMotivoExoneracion = @IdMotivoExoneracion,
					IdTipoContratacion = @IdTipoContratacion,
					IdSucural = @IdSucursal,
					IdCargo = @IdCargo
				WHERE IdEmpleado = @IdEmpleado AND Activo = 1;
			SELECT SCOPE_IDENTITY();
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE();

		IF XACT_STATE() = 1
		BEGIN
			ROLLBACK TRANSACTION;
		END
		ELSE IF XACT_STATE() = -1
		BEGIN
			ROLLBACK TRANSACTION;
		END;
		THROW
	END CATCH
END
GO

CREATE PROCEDURE DeleteEmpleados
@IdEmpleado INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			UPDATE Empleados
				SET Activo = 0
				WHERE IdEmpleado = @IdEmpleado AND Activo = 1;
			SELECT SCOPE_IDENTITY();
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE();

		IF XACT_STATE() = 1
		BEGIN
			ROLLBACK TRANSACTION;
		END
		ELSE IF XACT_STATE() = -1
		BEGIN
			ROLLBACK TRANSACTION;
		END;
		THROW
	END CATCH
END
GO
