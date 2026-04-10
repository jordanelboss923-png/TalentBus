/* ============================================
	Creacion de la base de datos para la nomina
	del Proyecto Final de Programacion Basica.
   ============================================ */

   --Segmento donde creamos la base de datos y le asignamos un lugar donde se almacenara en nuestro almacenamiento de preferencia.
   --Tambien se designan parametros como el tamaño base, el cremiento y el maximo. 
CREATE DATABASE TalentBus;

GO
USE TalentBus;
GO

--=================================
--	   Creacion de las tablas
--=================================

Create Table Departamentos (
Id int primary key identity(1,1),
Nombre varchar(100)Unique );
Go

Create Table Posiciones(
ID int primary key identity(1,1),
Nombre varchar(100) Not null,  
Salario decimal(10,2) check (Salario > 0),
IdDepartamento int Not Null, 
	Constraint FK_Posiciones_Departamentos
	Foreign Key (IdDepartamento)
	References Departamentos(Id));
Go

Create Table Empleados(
Id int primary key identity(1,1),
CodigoEmpleado varchar(5) Unique Not Null,
Nombre varchar(50) Not null,
Apellido varchar(50) Not null,
Cedula varchar(20) Unique Not null, 
Tipo Tinyint not null Check (Tipo IN (1, 2)), --1 = Fijo, 2 = Por hora,
IdPosicion int not null, 
Estatus varchar(30) check (Estatus IN('Activo', 'Baja Medica', 'Inactivo', 'Permiso', 'Vacaciones'),
SalarioBase DECIMAL(10,2) NOT NULL, 
FechaIngreso Date Default GetDate(),
	CONSTRAINT FK_Empleados_Posiciones
    FOREIGN KEY (IdPosicion) 
	REFERENCES Posiciones(ID)
);
GO

Create Table Deducciones(
Id int primary key identity(1,1),
Nombre varchar(50) Not null,
Porcentaje decimal (8,2),
Descripcion varchar (200));
GO

Create Table Asignaciones(
Id int primary key identity(1,1),
Nombre varchar(50) Not null,
Porcentaje decimal (8,2),
Descripcion varchar (200));
GO


Create Table AsignacionesEmpleado(
Id int primary key identity(1,1),
IdAsignacion int Not Null, 
IdEmpleado int not null,  
Tipo Tinyint not null Check (Tipo IN (1, 2)), --1 = Mensual, 2 = Quincenal
Monto decimal (8,2) default 0,
FechaEfectividad Date Not Null, 
FechaRegistro Date Default GetDate(),
    Constraint FK_AsignacionesEmpleado_Asignaciones
    Foreign key (IdAsignacion)
    References Asignaciones(Id),
    Constraint FK_AsignacionesEmpleado_Empleado
    Foreign key (IdEmpleado)
    References Empleados(Id));
GO

Create table Asistencias(
Id int Primary key identity(1,1),
IdEmpleado int not null, 
Descripcion varchar(30) Not Null 
check (Descripcion IN ('Entrada', 'Salida', 'Almuerzo', 'Retorno de Almuerzo')),
FechaHora DateTime default SYSDATETIME(),
    Constraint FK_Asistencias_Empleados
    Foreign key (IdEmpleado)
    References Empleados(Id));
Go

Create Table Loggin(
Id int primary key identity(1,1),
IdEmpleado int Unique not null,
Estatus varchar(20) check (Estatus IN('Activo', 'Inactivo'),
Usser varchar(5) Unique,
Clave VARBINARY(50) not null,
    CONSTRAINT FK_Login_Empleados
    FOREIGN KEY (IdEmpleado) 
    REFERENCES Empleados(Id) );
GO

Create Table SalarioST(
Id int primary key identity(1,1),
IdEmpleado int,
Sueldobase decimal(10,2) not null, 
Asignacion decimal(10,2) not null DEFAULT 0,
Total decimal(10,2) not null DEFAULT 0,
FechaEfectividad date not null,
FechaRegistro date default GetDate()
    CONSTRAINT FK_SalarioST_Empleados
    FOREIGN KEY (IdEmpleado) 
    REFERENCES Empleados(Id));
GO

Create Table DeduccionesEmpleado(
Id int primary key identity(1,1),
IdDeduccion int Not Null, 
IdEmpleado int not null, 
IdSubtotal int not null, 
Tipo Tinyint not null Check (Tipo IN (1, 2)), --1 = Mensual, 2 = Quincenal
Monto decimal (8,2)  DEFAULT 0,
FechaEfectividad Date Not Null, 
FechaRegistro Date Default GetDate(),
    Constraint FK_DeduccionesEmpleado_Deducciones
    Foreign key (IdDeduccion)
    References Deducciones(Id),
    Constraint FK_DeduccionesEmpleado_Empleado
    Foreign key (IdEmpleado)
    References Empleados(Id),
    Constraint FK_DeduccionesEmpleado_SalarioST
    Foreign key (IdSubtotal)
    References SalarioST(Id));
GO

Create Table VolantesPago(
Id int primary key identity(1,1),
IdEmpleado int, 
IdAsignaciones int, 
IdDeducciones int, 
Subtotal decimal(10,2) default 0, 
Deducciones decimal(10,2) default 0,
Total decimal(10,2) default 0,
FechaEfectividad date not null, 
FechaRegistro date default getdate()
    CONSTRAINT FK_VolantesPago_Empleados
        FOREIGN KEY (IdEmpleado)     
        REFERENCES Empleados(Id),
    CONSTRAINT FK_VolantesPago_SalarioST
        FOREIGN KEY (IdAsignaciones) 
        REFERENCES SalarioST(Id),
    CONSTRAINT FK_VolantesPago_DeduccionesEmpleado
        FOREIGN KEY (IdDeducciones)  
        REFERENCES DeduccionesEmpleado(Id));
Go

Create table BonoNavidad(
Id int primary key identity(1,1),
IdEmpleado int, 
SalarioAnual decimal(10,2) default 0,
MontoBono decimal(10,2) default 0,
FechaEfectividad date not null, 
FechaRegistro date default getdate()
    CONSTRAINT FK_BonoNavidad_Empleados
        FOREIGN KEY (IdEmpleado)     
        REFERENCES Empleados(Id));
GO

Create table BonoAnual(
Id int primary key identity(1,1),
IdEmpleado int, 
SalarioAnual decimal(10,2) default 0,
MontoBono decimal(10,2) default 0,
FechaEfectividad date not null, 
FechaRegistro date default getdate()
    CONSTRAINT FK_BonoAnual_Empleados
        FOREIGN KEY (IdEmpleado)     
        REFERENCES Empleados(Id));
GO

Create table ISR(
Id int primary key identity(1,1),
Porcentaje decimal(8,2),
MontoExcedente decimal(8,2),
Descripcion varchar(200));
Go

INSERT INTO ISR (Porcentaje, MontoExcedente, Descripcion) VALUES
(0.00,      0.00,      'Exento - Hasta RD$416,220.00'),
(15.00,     0.00, '15% del extra sobre RD$416,220.01 hasta RD$624,329.00'),
(20.00,     31216.00, '20% del extra sobre RD$624,329.01 hasta RD$867,123.00 + RD$31,216.00 fijo'),
(25.00,     79776.00, '25% del extra sobre RD$867,123.00 + RD$79,776.00 fijo');
GO

-- Departamentos
INSERT INTO Departamentos (Nombre) VALUES
('Recursos Humanos'),
('Tecnología'),
('Finanzas'),
('Ventas'),
('Marketing'),
('Operaciones'),
('Contabilidad'),
('Logística'),
('Servicio al Cliente'),
('Administración');
GO

-- Posiciones
INSERT INTO Posiciones (Nombre, Salario, IdDepartamento) VALUES
('Gerente de RRHH',           85000.00,  1),
('Desarrollador Senior',      95000.00,  2),
('Analista Financiero',       75000.00,  3),
('Ejecutivo de Ventas',       55000.00,  4),
('Especialista en Marketing', 60000.00,  5),
('Supervisor de Operaciones', 65000.00,  6),
('Contador General',          70000.00,  7),
('Coordinador de Logística',  58000.00,  8),
('Agente de Servicio',        45000.00,  9),
('Asistente Administrativo',  40000.00, 10);
GO

/* ==================================
    Trigger para simplificar calculos
    en las diversas tablas.
   ================================== */

-- TRIGGER: Calcula y guarda SalarioBase automaticamente al INSERT o UPDATE
CREATE TRIGGER trg_Empleados_SalarioBase
ON Empleados
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evitar loop si el trigger se dispara por el mismo UPDATE interno
    IF UPDATE(SalarioBase) AND NOT UPDATE(Tipo) AND NOT UPDATE(IdPosicion)
        RETURN;

    UPDATE e
    SET e.SalarioBase = CASE 
                            WHEN i.Tipo = 1 
                                THEN p.Salario
                            WHEN i.Tipo = 2 
                                THEN ROUND(p.Salario / (44.0 * 4.33), 2)
                        END
    FROM Empleados e
    INNER JOIN inserted i  ON e.Id = i.Id
    INNER JOIN Posiciones p ON p.ID = i.IdPosicion;
END;
GO

--Trigger para asignar el codigo de empleado como usser

CREATE TRIGGER trg_Loggin_Usser
ON Loggin
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE l
    SET l.Usser = e.CodigoEmpleado
    FROM Loggin l
    INNER JOIN inserted i   ON l.Id = i.Id
    INNER JOIN Empleados e  ON e.Id = i.IdEmpleado;
END;
GO

--Trigger para calcular el subtotal en base a las asignaciones de x empleado en tal mes.

CREATE TRIGGER trg_SalarioST_Calcular
ON AsignacionesEmpleado
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Recalcula SalarioST para cada empleado/fecha afectado
    MERGE SalarioST AS target
    USING (
        SELECT 
            ae.IdEmpleado,
            e.SalarioBase                               AS SueldoBase,
            SUM(ae.Monto)                               AS Asignacion,
            e.SalarioBase + SUM(ae.Monto)               AS Total,
            ae.FechaEfectividad
        FROM AsignacionesEmpleado ae
        INNER JOIN Empleados e ON e.Id = ae.IdEmpleado
        WHERE ae.IdEmpleado IN (SELECT IdEmpleado FROM inserted)
          AND ae.FechaEfectividad IN (SELECT FechaEfectividad FROM inserted)
        GROUP BY ae.IdEmpleado, e.SalarioBase, ae.FechaEfectividad
    ) AS source
    ON target.IdEmpleado      = source.IdEmpleado
    AND target.FechaEfectividad = source.FechaEfectividad

    -- Si ya existe el registro, lo actualiza
    WHEN MATCHED THEN
        UPDATE SET
            target.SueldoBase       = source.SueldoBase,
            target.Asignacion       = source.Asignacion,
            target.Total            = source.Total

    -- Si no existe, lo inserta
    WHEN NOT MATCHED THEN
        INSERT (IdEmpleado, SueldoBase, Asignacion, Total, FechaEfectividad)
        VALUES (source.IdEmpleado, source.SueldoBase, source.Asignacion, 
                source.Total, source.FechaEfectividad);
END;
GO

--Trigger para calcular las deducciones de cada empleado 

CREATE TRIGGER trg_DeduccionesEmpleado_Monto
ON DeduccionesEmpleado
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evitar loop si el trigger se dispara por el UPDATE interno del Monto
    IF UPDATE(Monto) AND NOT UPDATE(IdDeduccion) AND NOT UPDATE(IdSubtotal)
        RETURN;

    -- Actualiza el Monto de CADA deduccion del empleado
    -- usando el Total de SalarioST y el Porcentaje de cada Deduccion
    UPDATE de
    SET de.Monto = ROUND(st.Total * (d.Porcentaje / 100.0), 2)
    FROM DeduccionesEmpleado de
    INNER JOIN Deducciones d  ON  d.Id               = de.IdDeduccion
    INNER JOIN SalarioST   st ON  st.IdEmpleado       = de.IdEmpleado
                              AND st.FechaEfectividad = de.FechaEfectividad
    WHERE de.IdEmpleado IN (SELECT IdEmpleado FROM inserted)
      AND de.FechaEfectividad IN (SELECT FechaEfectividad FROM inserted);
END;
GO

--Trigger para las sumas y restas del volante de pago

CREATE TRIGGER trg_VolantesPago_Calcular
ON VolantesPago
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evitar loop si el trigger se dispara por el UPDATE interno
    IF UPDATE(Subtotal) AND NOT UPDATE(IdAsignaciones) AND NOT UPDATE(IdDeducciones)
        RETURN;

    UPDATE vp
    SET 
        -- Subtotal = SueldoBase + Asignacion (de SalarioST)
        vp.Subtotal = st.SueldoBase + st.Asignacion,

        -- Deducciones = suma de todos los montos del empleado en esa fecha
        vp.Deducciones = (
            SELECT ISNULL(SUM(de.Monto), 0)
            FROM DeduccionesEmpleado de
            WHERE de.IdEmpleado = i.IdEmpleado
              AND de.FechaEfectividad = i.FechaEfectividad
        ),

        -- Total = Subtotal - Deducciones
        vp.Total = (st.SueldoBase + st.Asignacion) - (
            SELECT ISNULL(SUM(de.Monto), 0)
            FROM DeduccionesEmpleado de
            WHERE de.IdEmpleado       = i.IdEmpleado
              AND de.FechaEfectividad = i.FechaEfectividad
        )

    FROM VolantesPago vp
    INNER JOIN inserted  i  ON  vp.Id  = i.Id
    INNER JOIN SalarioST st ON  st.Id  = i.IdAsignaciones
                            AND st.FechaEfectividad = i.FechaEfectividad;
END;
GO

--Trigger para calcular las asignaciones de un empleado

CREATE TRIGGER trg_AsignacionesEmpleado_Monto
ON AsignacionesEmpleado
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evitar loop si el trigger se dispara por el UPDATE interno del Monto
    IF UPDATE(Monto) AND NOT UPDATE(IdAsignacion) AND NOT UPDATE(IdEmpleado)
        RETURN;

    UPDATE ae
    SET ae.Monto = ROUND(
        -- Calcula salario segun tipo de empleado
        CASE 
            WHEN e.Tipo = 1 THEN e.SalarioBase                        -- Fijo: salario directo
            WHEN e.Tipo = 2 THEN e.SalarioBase * (44.0 * 4.33)        -- Por hora: hora * horas al mes
        END
        * (a.Porcentaje / 100.0), 2)                                   -- Aplica el porcentaje

    FROM AsignacionesEmpleado ae
    INNER JOIN inserted      i  ON  ae.Id          = i.Id
    INNER JOIN Empleados     e  ON  e.Id           = i.IdEmpleado
    INNER JOIN Asignaciones  a  ON  a.Id           = i.IdAsignacion;
END;
GO


--trigger para calcular el doble, toma los salarios del volante de pago y calculando el monto que equivale al salario 13. 
CREATE TRIGGER trg_BonoNavidad_Calcular
ON BonoNavidad
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(SalarioAnual) AND NOT UPDATE(IdEmpleado)
        RETURN;

    UPDATE bn
    SET 
        bn.SalarioAnual = (
            SELECT ISNULL(SUM(vp.Total), 0)
            FROM VolantesPago vp
            WHERE vp.IdEmpleado            = i.IdEmpleado
              AND YEAR(vp.FechaEfectividad) = YEAR(i.FechaEfectividad)
        ),
        bn.MontoBono = (
            SELECT ISNULL(ROUND(SUM(vp.Subtotal) / 12.0, 2), 0)
            FROM VolantesPago vp
            WHERE vp.IdEmpleado            = i.IdEmpleado
              AND YEAR(vp.FechaEfectividad) = YEAR(i.FechaEfectividad)
        )
    FROM BonoNavidad bn
    INNER JOIN inserted i ON bn.Id = i.Id;
END;
GO


--Trigger para calcular el bonoanual o bono de pascua, considerando antinguedad de empleado 
-- < 3 recibe 45 dias de salario, > 3 recibe 60 dias

CREATE TRIGGER trg_BonoAnual_Calcular
ON BonoAnual
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(SalarioAnual) AND NOT UPDATE(IdEmpleado)
        RETURN;

    UPDATE ba
    SET
        ba.SalarioAnual = (
            SELECT ISNULL(SUM(vp.Subtotal), 0)
            FROM VolantesPago vp
            WHERE vp.IdEmpleado            = i.IdEmpleado
              AND YEAR(vp.FechaEfectividad) = YEAR(i.FechaEfectividad)
        ),
        ba.MontoBono = ROUND(
            -- Salario diario
            (
                SELECT ISNULL(SUM(vp.Subtotal), 0)
                FROM VolantesPago vp
                WHERE vp.IdEmpleado            = i.IdEmpleado
                  AND YEAR(vp.FechaEfectividad) = YEAR(i.FechaEfectividad)
            ) / 360.0
            *
            -- Dias segun antiguedad
            CASE 
                WHEN DATEDIFF(YEAR, e.FechaIngreso, i.FechaEfectividad) >= 3 
                THEN 60.0
                ELSE 45.0
            END
            *
            -- Proporcion del año trabajado
            CASE
                WHEN YEAR(e.FechaIngreso) = YEAR(i.FechaEfectividad)
                THEN DATEDIFF(DAY, e.FechaIngreso, i.FechaEfectividad) / 360.0
                ELSE 1.0
            END
        , 2)

    FROM BonoAnual   ba
    INNER JOIN inserted  i ON ba.Id = i.Id
    INNER JOIN Empleados e ON e.Id  = i.IdEmpleado;
END;
GO

