# Prueba Técnica – Fullstack NET

Aplicación para gestión de usuarios desarrollada en ASP.NET Core MVC utilizando Dapper, SQL Server, Bootstrap 5 y un sistema de login simple basado en email + rol. 

## 🚀 Ejecución del proyecto

Siga los pasos a continuación para ejecutar la aplicación correctamente.

---

## 1️⃣ Crear la base de datos

El script completo se encuentra en: /Database/create_database.sql

## 2️⃣ Configurar la cadena de conexión

En `appsettings.json`, actualizar la ConnectionString: DefaultConnection

## 3️⃣ Ejecutar la aplicación
Restaurar dependencias y ejecutar:

dotnet restore
dotnet run

O desde Visual Studio: Run / F5

##4️⃣ Login simulado (sin contraseñas)
Este proyecto utiliza un login simple sin contraseñas.
La autenticación se realiza verificando email + rol contra la tabla Usuarios.

Usuarios precargados:

admin@test.com
Administrador
  
user@test.com
Usuario

##5️⃣ Permisos del sistema

El proyecto implementa control de acceso basado en roles:

👑 Administrador

Ver listado completo
Crear usuario
Editar usuario
Eliminar usuario

👤 Usuario estándar
Solo ve usuarios de su mismo rol
No puede crear/editar/eliminar
Si intenta acceder a una ruta no permitida, es redirigido a: /Home/AccessDenied
