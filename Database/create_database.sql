/* ============================================================
   DATABASE CREATION SCRIPT – Prueba Técnica Fullstack .NET
   ============================================================ */

-- 1. Crear base de datos
IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'PruebaAtica')
BEGIN
    CREATE DATABASE PruebaAtica;
END
GO

USE PruebaAtica;
GO

/* ============================================================
   2. Crear tabla Usuarios
   ============================================================ */

IF OBJECT_ID('Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE Usuarios (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Apellido NVARCHAR(100) NOT NULL,
        Documento NVARCHAR(20) NOT NULL,
        Email NVARCHAR(150) NOT NULL,
        Rol NVARCHAR(20) NOT NULL
    );
END
GO

/* ============================================================
   3. Insertar datos iniciales (opcional)
   ============================================================ */

-- Usuario administrador inicial para login
INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Admin', 'Sistema', '12345678', 'admin@test.com', 'Administrador');

-- Usuario común inicial
INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Juan', 'Pérez', '23456789', 'user@test.com', 'Usuario');


/* Más usuarios Administrador */
INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Lucía', 'Ramírez', '30111222', 'lucia.ramirez@test.com', 'Administrador');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Marcos', 'Díaz', '28445566', 'marcos.diaz@test.com', 'Administrador');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Sofía', 'Villalba', '27566789', 'sofia.villalba@test.com', 'Administrador');


/* Usuarios comunes */
INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Pedro', 'Gómez', '23322112', 'pedro.gomez@test.com', 'Usuario');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Carla', 'López', '29988776', 'carla.lopez@test.com', 'Usuario');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Mateo', 'Fernández', '31123456', 'mateo.fernandez@test.com', 'Usuario');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Ana', 'Torres', '32112233', 'ana.torres@test.com', 'Usuario');

INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
VALUES ('Bruno', 'Martínez', '30199887', 'bruno.martinez@test.com', 'Usuario');

GO

