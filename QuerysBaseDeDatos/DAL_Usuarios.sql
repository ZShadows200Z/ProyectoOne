USE DB_GestorEmpleados
GO

CREATE PROCEDURE InsertUsuario
@Nombre VARCHAR(200),
@Usuario VARCHAR(50),
@Contraseña VARBINARY(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Usuarios(Nombre, Usuario, Contraseña)
				VALUES(@Nombre, @Usuario, @Contraseña)
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

CREATE PROCEDURE UpdateUsuario
@Nombe VARCHAR(200),
@Usuario VARCHAR(50),
@Contraseña VARBINARY(MAX),
@CambiarPassword BIT,
@IdUsuario INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			IF(@CambiarPassword = 1)
			BEGIN
				UPDATE Usuarios
					SET Nombre = @Nombe, Usuario = @Usuario, Contraseña = @Contraseña
					WHERE IdUsuario = @IdUsuario AND Activo = 1;
				SELECT SCOPE_IDENTITY();
			END
			IF(@CambiarPassword = 0)
			BEGIN
				UPDATE Usuarios
					SET Nombre = @Nombe, Usuario = @Usuario
					WHERE IdUsuario = @IdUsuario AND Activo = 1;
				SELECT SCOPE_IDENTITY();
			END
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

CREATE PROCEDURE DeleteUsuario
@IdUsuario INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			UPDATE Usuarios
				SET Activo = 0
				WHERE IdUsuario = @IdUsuario AND Activo = 1;
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

--Esto es para obtener la contraseña de un usuario y mandarlo a C#
CREATE PROCEDURE ValidateLogin
@Usuarios VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		SELECT U.Contraseña FROM Usuarios U
		WHERE U.Usuario = @Usuarios AND U.Activo = 1;
	END TRY
	BEGIN CATCH
		THROW --Esto es para que tire el error a C# y ahí capturarlo
	END CATCH
END
GO