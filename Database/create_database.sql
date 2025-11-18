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

GO
