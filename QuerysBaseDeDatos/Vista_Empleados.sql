USE DB_GestorEmpleados
GO

CREATE VIEW vEmpleados AS
SELECT 
E.IdEmpleado,
E.Nombre,
E.Identificacion,
E.FechaIngreso,
E.FechaExoneracion,
C.Nombre AS Cargo,
S.Nombre AS Sucursal,
ME.Motivo AS 'Motivo de Exoneracion',
TC.Tipo AS 'Tipo de Contratación'
FROM Empleados E
INNER JOIN Cargos C ON C.IdCargo = E.IdCargo
INNER JOIN Sucursales S ON S.IdSucursal = E.IdSucural
INNER JOIN MotivoExoneraciones ME ON ME.IdMotivoExoneracion = E.IdMotivoExoneracion
INNER JOIN TipoContrataciones TC ON TC.IdTipoContratacion = E.IdTipoContratacion
WHERE E.Activo = 1
GO
