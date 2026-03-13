CREATE DATABASE TalentBusDB;
GO
USE TalentBusDB;
GO

CREATE TABLE Cargo (
    Id INT IDENTITY PRIMARY KEY,
    NombreCargo VARCHAR(50) NOT NULL,
    Departamento VARCHAR(50) NOT NULL
);

CREATE TABLE Empleado (
    Id INT IDENTITY PRIMARY KEY,
    Cedula VARCHAR(15) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    IdCargo INT NOT NULL,
    SalarioBase DECIMAL(10,2) NOT NULL,
    FechaIngreso DATE DEFAULT GETDATE(),
    FOREIGN KEY (IdCargo) REFERENCES Cargo(Id)
);

CREATE TABLE DeduccionBeneficio (
    Id INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Tipo VARCHAR(20) NOT NULL,
    Porcentaje DECIMAL(5,2) NOT NULL
);

CREATE TABLE Nomina (
    Id INT IDENTITY PRIMARY KEY,
    Fecha DATE DEFAULT GETDATE(),
    TotalBruto DECIMAL(10,2),
    TotalDeducciones DECIMAL(10,2),
    TotalNeto DECIMAL(10,2)
);

CREATE TABLE NominaDetalle (
    Id INT IDENTITY PRIMARY KEY,
    IdNomina INT NOT NULL,
    IdEmpleado INT NOT NULL,
    SalarioBruto DECIMAL(10,2),
    TotalDeducciones DECIMAL(10,2),
    SalarioNeto DECIMAL(10,2),
    FOREIGN KEY (IdNomina) REFERENCES Nomina(Id),
    FOREIGN KEY (IdEmpleado) REFERENCES Empleado(Id)
);

INSERT INTO DeduccionBeneficio (Nombre, Tipo, Porcentaje)
VALUES
('AFP Empleado', 'AFP', 2.87),
('ARS Empleado', 'ARS', 3.04),
('ISR',          'ISR', 0.00);

SELECT * FROM DeduccionBeneficio;

SELECT * FROM Nomina;

-- Ver detalle completo
SELECT 
    n.Id         AS IdNomina,
    n.Fecha,
    e.Nombre,
    e.Apellido,
    nd.SalarioBruto,
    nd.TotalDeducciones,
    nd.SalarioNeto
FROM NominaDetalle nd
INNER JOIN Nomina   n ON nd.IdNomina   = n.Id
INNER JOIN Empleado e ON nd.IdEmpleado = e.Id
ORDER BY n.Fecha DESC;

SELECT 
    c.Departamento,
    COUNT(e.Id)        AS TotalEmpleados,
    SUM(nd.SalarioBruto)      AS TotalBruto,
    SUM(nd.TotalDeducciones)  AS TotalDeducciones,
    SUM(nd.SalarioNeto)       AS TotalNeto
FROM NominaDetalle nd
INNER JOIN Empleado e ON nd.IdEmpleado = e.Id
INNER JOIN Cargo    c ON e.IdCargo     = c.Id
GROUP BY c.Departamento;