create database Fase2_s2_2011
ON
(
Name = practica1_data,
FileName = 'C:\Users\NelsonLaptop\Desktop\db2011\Fase2_s2_2011.mdf',
size = 3,
maxsize = unlimited,
filegrowth = 1
)
GO

create table Usuarios(
	idUsuario varchar(100) primary key,
	contraseñaUsuario varchar(20),
	nombres varchar(50), 
	apellidos varchar(50),
	telefono varchar(10),
)

create table RolUsuario(
	idRolUsuario int Identity (1,1) primary key,
	tipoRol varchar(30),
	usuario_idUsuario varchar(100),
	foreign key(usuario_idUsuario) references Usuarios(idUsuario),
)

create table ArchivoXml(
	nombreArchivo varchar(100) primary key,
	Archivo Image,
	usuario_idUsuario varchar(100),
	foreign key(usuario_idUsuario) references Usuarios(idUsuario),
)

create table HistorialUsuario(
	idHistorial int Identity (1,1) primary key,
	usuario_idUsuario varchar(100),
	fecha datetime,
	Accion varchar(50),
	foreign key(usuario_idUsuario) references Usuarios(idUsuario),
)



select idRolUsuario,tipoRol,usuario_idUsuario,contraseñaUsuario from RolUsuario,Usuarios where usuario_idUsuario = 'usuario1@correo.com'





