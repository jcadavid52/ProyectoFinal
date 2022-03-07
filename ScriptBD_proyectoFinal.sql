CREATE DATABASE BD_PROYECTO_FINAL
USE BD_PROYECTO_FINAL

--TABLA CLIENTES
CREATE TABLE CLIENTE
(
ID_CLIENTE INT PRIMARY KEY IDENTITY,
NOMBRE_CLIENTE VARCHAR(50),
APELLIDO_CLIENTE VARCHAR(50),
TELEFONO VARCHAR(20),
CELULAR VARCHAR(20),
CORREO VARCHAR(60)
)
--TABLA USUARIOS
CREATE TABLE USUARIO
(
ID_USUARIO INT PRIMARY KEY IDENTITY,
NOMBRE_USUARIO VARCHAR(50),
APELLIDO_USUARIO VARCHAR(50),
TELEFONO VARCHAR(20),
CELULAR VARCHAR(20),
CORREO VARCHAR(60),
PAIS VARCHAR(30),
FK_SESION INT REFERENCES SESION(ID_SESION)

)
--TABLA LOGIN
CREATE TABLE SESION
(
ID_SESION INT PRIMARY KEY IDENTITY,
USUARIO VARCHAR(50),
CLAVE VARCHAR(100),

)
--TABLA PEDIDOS
CREATE TABLE PEDIDO
(
ID_PEDIDO INT PRIMARY KEY IDENTITY,
ESTADO VARCHAR(20),
PRECIO_TOTAL FLOAT,
FECHA_ENTREGA DATE,
FECHA_PEDIDO DATETIME,
DETALLE VARCHAR(200),
CANTIDAD INT,
FK_CLIENTE INT REFERENCES CLIENTE(ID_CLIENTE)
)
--TABLA CATEGOR�A
CREATE TABLE CATEGORIA
(
ID_CATEGORIA INT PRIMARY KEY IDENTITY,
NOMBRE_CATEGORIA VARCHAR(100)

--FK_SESION INT REFERENCES SESION(ID_SESION)
)
--TABLA PRODUCTOS
CREATE TABLE PRODUCTO
(
ID_PRODUCTO INT PRIMARY KEY IDENTITY,
NOMBRE_PRODUCTO VARCHAR(50),
PRECIO FLOAT,
DESCRIPCION VARCHAR(200),
FK_PEDIDO INT REFERENCES PEDIDO(ID_PEDIDO),
FK_CATEGORIA INT REFERENCES CATEGORIA(ID_CATEGORIA),
FK_USUARIO INT REFERENCES USUARIO(ID_USUARIO)
)

--REGISTROS
delete from SESION where ID_SESION = 1
delete from USUARIO where ID_USUARIO = 1
INSERT INTO SESION(USUARIO,CLAVE)VALUES('cadavidcamilo360@gmail.com','123')
declare @idsesion int
set @idsesion = SCOPE_IDENTITY() 
INSERT INTO USUARIO(FK_SESION) VALUES(@idsesion)

INSERT INTO CATEGORIA (NOMBRE_CATEGORIA) VALUES('M�sica')

ALTER PROCEDURE REGISTRAR_USER
@USUARIO VARCHAR(50),
@CLAVE VARCHAR(100)
AS
BEGIN
INSERT INTO SESION(USUARIO,CLAVE)VALUES(@USUARIO,@CLAVE)
declare @idsesion int
declare @idusuario int
set @idsesion = SCOPE_IDENTITY() 
INSERT INTO USUARIO(FK_SESION) VALUES(@idsesion)
END

EXEC REGISTRAR_USER 'user3@gmail.com','789'

INSERT INTO CATEGORIA (NOMBRE_CATEGORIA) VALUES('Tecnolog�a')
-----------------------------------------------------------------------------------
CREATE PROC USP_PUBLICAR_USER
@NOMBRE_USUARIO VARCHAR(50),
@APELLIDO_USUARIO VARCHAR(50),
@TELEFONO VARCHAR(20),
@CELULAR VARCHAR(20),
@CORREO VARCHAR(60),
@PAIS VARCHAR(30),
@FK_SESION INT
AS
BEGIN
UPDATE USUARIO SET NOMBRE_USUARIO = @NOMBRE_USUARIO,APELLIDO_USUARIO = @APELLIDO_USUARIO,TELEFONO = @TELEFONO,CELULAR = @CELULAR, CORREO = @CORREO,PAIS = @PAIS 
WHERE FK_SESION = @FK_SESION
END


--CONSULTAS
SELECT * FROM USUARIO
SELECT * FROM SESION
SELECT * FROM CATEGORIA
SELECT * FROM PRODUCTO



DBCC CHECKIDENT (USUARIO, RESEED, 0)
DBCC CHECKIDENT (SESION, RESEED, 0)