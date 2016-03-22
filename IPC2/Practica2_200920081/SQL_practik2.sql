CREATE TABLE AEROLINEA(
id_Aerolinea varchar(50)not null primary key,
nombre varchar (50) not null,
telefono int not null,
direccion varchar(50) not null,

)

CREATE TABLE AVION(
id_avion varchar(50) not null primary key,
capacidad int not null,
peso int not null,
id_Aerolinea varchar(50)not null,
)

CREATE TABLE CLIENTE(
id_cliente varchar(50) not null primary key,
nombre varchar(50) not null ,
fecha_nac char(10) not null,
telefono int not null,
direccion varchar (50) not null,
correo varchar(50) not null,
id_reservacion varchar(50) not null,


)
CREATE TABLE RESERVACION(
id_reservacion varchar(50) not null primary key,
destino varchar(50) not null, 
fecha date not null,
precio int not null
)

