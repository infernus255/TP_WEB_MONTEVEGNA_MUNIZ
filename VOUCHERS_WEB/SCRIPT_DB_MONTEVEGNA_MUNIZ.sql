CREATE DATABASE VOUCHERS_WEB_DB
GO
USE VOUCHERS_WEB_DB
GO
--SOLO CIUDADES DE BUENOS AIRES YA QUE NO SE ESPECIFICA EN EL ENUNCIADO
create TABLE LOCALIDADES(
ID INT NOT NULL identity(1,1) PRIMARY KEY,
NOMBRE VARCHAR(50) NOT NULL
)
GO
create TABLE CLIENTES(
DNI INT NOT NULL PRIMARY KEY CHECK(DNI>0),
NOMBRE VARCHAR(30) NOT NULL,
APELLIDO VARCHAR(30) NOT NULL,
NROCALLE SMALLINT NOT NULL CHECK(NROCALLE>0),
CALLE VARCHAR(30) NOT NULL,
ID_LOCALIDAD INT NOT NULL FOREIGN KEY REFERENCES LOCALIDADES(ID),
TELEFONO INT NOT NULL CHECK(TELEFONO>0),
EMAIL VARCHAR(30) NOT NULL
)
GO

create TABLE PRODUCTOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(30) NOT NULL,

)
GO
CREATE TABLE SORTEOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(30) NULL,
FECHA_INI SMALLDATETIME NOT NULL,
FECHA_FIN SMALLDATETIME NOT NULL,
CHECK(FECHA_FIN>FECHA_INI)
)

GO
create TABLE VOUCHERS(
ID VARCHAR(8) NOT NULL PRIMARY KEY,
FECHA DATETIME NOT NULL,
ACTIVO BIT NOT NULL,
ID_SORTEO INT NOT NULL FOREIGN KEY REFERENCES SORTEOS(ID),
ID_PROD_SELEC INT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID)
)
GO
create TABLE COMPRAS(
ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
ID_PRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
ID_VOUCHER VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES VOUCHERS(ID),
FECHA DATETIME NOT NULL
)
GO
create TABLE NOCLIENTES(
ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
ID_COMPRA BIGINT NOT NULL FOREIGN KEY REFERENCES COMPRAS(ID)
)
GO
create TABLE COMPRAS_X_CLIENTE(
ID_COMPRA BIGINT NOT NULL FOREIGN KEY REFERENCES COMPRAS(ID),
ID_CLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(DNI),
PRIMARY KEY(ID_COMPRA,ID_CLIENTE)
)
GO
create TABLE PREMIOS(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
ID_PRODUCTO INT NOT NULL FOREIGN KEY REFERENCES PRODUCTOS(ID),
ID_VOUCHER VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES VOUCHERS(ID),
ACTIVO BIT NOT NULL
)
GO

--VOUCHERS

--SP PARA BUSCAR VOUCHER POR ID
--si el id es igual al de db, esta activo,fue comprado, no fue utilizado antes y esta en el sorteo actual
CREATE PROCEDURE SP_BUSCAR_VOUCHER_X_ID
(
@ID_VOUCHER VARCHAR(8)
)
AS
BEGIN


SELECT V.ID,V.FECHA,V.ACTIVO,V.ID_SORTEO FROM VOUCHERS AS V 
INNER JOIN COMPRAS AS C ON V.ID=C.ID_VOUCHER
INNER JOIN SORTEOS AS S ON V.ID_SORTEO=S.ID
WHERE @ID_VOUCHER=V.ID AND V.ACTIVO=1 AND V.FECHA=C.FECHA AND V.FECHA BETWEEN CAST(S.FECHA_INI AS DATETIME) AND CAST(S.FECHA_FIN AS DATETIME)


END


GO
CREATE PROCEDURE SP_IS_WIN
(
@ID_VOUCHER VARCHAR(8)
)
AS
BEGIN
DECLARE @RESULT BIT
SELECT @RESULT=0

IF (SELECT TOP 1 V.ACTIVO FROM VOUCHERS AS V 
INNER JOIN PREMIOS as PRE ON PRE.ID_VOUCHER=V.ID
WHERE @ID_VOUCHER=V.ID)=1
BEGIN
SELECT @RESULT=1
END

SELECT @RESULT

END

GO
--INSERTA EL ID DEL PRODUCTO SELECCIONADO EN EL VOUCHER GANADOR USADO Y LO DA DE BAJA
CREATE PROCEDURE SP_BAJA_VOUCHER
(@ID_VOUCHER VARCHAR(8),
@ID_PROD INT)
AS
BEGIN

UPDATE VOUCHERS SET ID_PROD_SELEC=@ID_PROD , ACTIVO=0
WHERE ID=@ID_VOUCHER

END

--PRODUCTOS
GO
-- SP PARA LISTAR LOS PRODUCTOS DEL VOUCHER GANADOR
CREATE PROCEDURE SP_LISTAR_PROD_WIN_X_VOUCHER
(
@ID_VOUCHER VARCHAR(8)
)
AS
BEGIN

SELECT P.ID,P.NOMBRE FROM PRODUCTOS AS P 
INNER JOIN PREMIOS AS PR ON P.ID=PR.ID_PRODUCTO
WHERE @ID_VOUCHER=PR.ID_VOUCHER

END

GO
--CLIENTES

--CARGAR CLIENTE
--si la localidad no existe, la agrega
CREATE PROCEDURE SP_CARGAR_CLIENTE
(
@DNI INT,
@NOMBRE VARCHAR(30),
@APELLIDO VARCHAR(30),
@NROCALLE SMALLINT,
@CALLE VARCHAR(30),
@IDLOCALIDAD INT,
@TELEFONO INT,
@EMAIL VARCHAR(30)
)
AS
BEGIN

INSERT INTO CLIENTES (DNI,NOMBRE,APELLIDO,NROCALLE,CALLE,ID_LOCALIDAD,TELEFONO,EMAIL)
VALUES(@DNI,@NOMBRE,@APELLIDO,@NROCALLE,@CALLE,@IDLOCALIDAD,@TELEFONO,@EMAIL)

END

GO
--SP PARA SABER SI ESTA REGISTRADO EL CLIENTE
CREATE PROCEDURE SP_VERIFICAR_CLIENTE
(
@DNI INT
)
AS
BEGIN

DECLARE @BIT BIT

SELECT @BIT=0

IF CAST((SELECT DNI FROM CLIENTES WHERE @DNI=DNI) AS BIT )=1
BEGIN
SELECT @BIT=1
END

SELECT @BIT

END

GO
--SP PARA MODIFICAR EL CLIENTE
CREATE PROCEDURE SP_MODIFICAR_CLIENTE
(@DNI INT,
@NOMBRE VARCHAR(30),
@APELLIDO VARCHAR(30),
@NROCALLE SMALLINT,
@CALLE VARCHAR(30),
@IDLOCALIDAD INT,
@TELEFONO INT,
@EMAIL VARCHAR(30)
)
AS
BEGIN 


UPDATE CLIENTES SET DNI=@DNI,NOMBRE=@NOMBRE,
APELLIDO=@APELLIDO,NROCALLE=@NROCALLE,CALLE=@CALLE,
ID_LOCALIDAD=@IDLOCALIDAD,TELEFONO=@TELEFONO,EMAIL=@EMAIL
WHERE @DNI=DNI

END

GO
--SP PARA BUSCAR EL CLIENTE POR SU DNI
CREATE PROCEDURE SP_BUSCAR_CLIENTE_X_DNI
(@DNI INT)
AS
BEGIN

SELECT * FROM CLIENTES WHERE @DNI=DNI

END


EXEC SP_BUSCAR_CLIENTE_X_DNI 40306303

GO
--SP PARA BUSCAR LOCALIDAD POR ID
CREATE PROCEDURE SP_BUSCAR_LOC_X_ID
(
@ID INT
)AS
BEGIN 
SELECT NOMBRE FROM LOCALIDADES WHERE ID=@ID
END

GO
--SP PARA BUSCAR ID POR LOCALIDAD
CREATE PROCEDURE SP_BUSCAR_ID_X_LOC
(
@LOCALIDAD varchar(30)
)AS
BEGIN 
SELECT ID FROM LOCALIDADES WHERE NOMBRE=@LOCALIDAD
END

GO

CREATE PROCEDURE SP_AGREGAR_LOCALIDAD
(
@LOCALIDAD VARCHAR(30)
)
AS
BEGIN
INSERT INTO LOCALIDADES(NOMBRE)
VALUES(@LOCALIDAD)

END

--CARGA DE ALGUNOS DATOS
GO
INSERT INTO LOCALIDADES(NOMBRE)
VALUES('TORTUGUITAS'),('LA SANJA')
GO
SET DATEFORMAT DMY
INSERT INTO SORTEOS(NOMBRE,FECHA_INI,FECHA_FIN)
VALUES('PROMO MAYO','15/05/2019','30/05/2019'),('PROMO ABRIL','15/04/2019','30/04/2019')
GO
SET DATEFORMAT DMY
INSERT INTO VOUCHERS(ID,FECHA,ACTIVO,ID_SORTEO)
VALUES('AAAAAAAA','20/05/2019 14:05',1,1),('AAAAAAAB','21/05/2019 14:05',1,1),('AAAAAAAC','22/05/2019 14:05',1,1),('AAAAAAAD','23/05/2019 14:05',1,1),
('AAAAAAAE','24/04/2019 14:05',1,2),('AAAAAAAF','25/04/2019 14:05',1,2),('AAAAAAAG','26/05/2019 14:05',1,1),('AAAAAAAH','27/05/2019 14:05',0,1)
GO
INSERT INTO PRODUCTOS(NOMBRE)
VALUES('MAYONESA'),('BARBACOA'),('KETCHUP'),
('SALSAGOLF'),('MOSTAZA')
GO
SET DATEFORMAT DMY
INSERT INTO COMPRAS(ID_PRODUCTO,ID_VOUCHER,FECHA)
VALUES(1,'AAAAAAAA','20/05/2019 14:05'),(2,'AAAAAAAB','21/05/2019 14:05'),(3,'AAAAAAAC','22/05/2019 14:05'),(4,'AAAAAAAD','23/05/2019 14:05'),
(5,'AAAAAAAE','24/04/2019 14:05'),(2,'AAAAAAAF','25/04/2019 14:05'),(3,'AAAAAAAG','26/05/2019 14:05'),(2,'AAAAAAAH','27/05/2019 14:05')
GO
INSERT INTO PREMIOS(ID_VOUCHER,ID_PRODUCTO,ACTIVO)
VALUES('AAAAAAAA',1,1),('AAAAAAAA',2,1),('AAAAAAAA',3,1),('AAAAAAAA',4,1),
('AAAAAAAE',5,1),('AAAAAAAH',1,1),('AAAAAAAH',2,1),('AAAAAAAH',3,1),('AAAAAAAH',4,1),('AAAAAAAH',5,1)
GO
INSERT INTO CLIENTES(DNI,NOMBRE,APELLIDO,NROCALLE,CALLE,ID_LOCALIDAD,TELEFONO,EMAIL)
VALUES(40306303,'EROS','MONTEVEGNA',1203,'LA ROCA',1,1124547869,'EROS_GABRIEL@LIVE.COM.AR'),(40000000,'PEPE','PEJELAGARTO',1200,'PEGALE PEGALE',2,1124548869,'NOMEHAGASCARTERA@GMAIL.COM')
GO
INSERT INTO COMPRAS_X_CLIENTE(ID_COMPRA,ID_CLIENTE)
VALUES(1,40306303),(2,40000000),(3,40000000),(4,40306303),(5,40306303),(6,40000000)
GO 
INSERT INTO NOCLIENTES(ID_COMPRA)
VALUES(7),(8)

