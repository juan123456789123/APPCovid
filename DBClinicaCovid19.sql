--Script BDClinicaCovid19
--Integridad Referencial
ALTER TABLE Sintomas ADD FOREIGN KEY (cedula) references paciente(cedula)
ALTER TABLE SintomasDetalle ADD FOREIGN KEY(numRegistro) references Sintomas(numRegistro)
--Creación de la base de Datos
Create database DBClinicaCovid19
go
--Uso de la Base de Datos
use DBClinicaCovid19
go
--Deletes total de las tablas
delete from Sintomas 
go
delete from sintomasDetalle
go
--Selectos de las tablas
select * from usuario
go
select * from paciente
go
select * from sintomasDetalle
go
select * from sintomas
go
--Drops de las tablas
drop table usuario 
go
drop table paciente
go
drop table sintomasDetalle
go
drop table sintomas
go
drop table Auditoria;
go
--Creación de las tablas
create table usuario(
login varchar(15) not null,
password varchar(15) not null,
email varchar(40) not null,
rol varchar(15) not null,
primary key(login))
go

create table paciente(
cedula varchar(15) not null,
nombreCompleto varchar(35) not null,
provincia varchar(15) not null,
sexo char not null,
usuario varchar(15),
edad int not null,
primary key(cedula))
go

create table sintomas(
numRegistro int identity(1,1) not null,
cedula varchar(15) not null,
fecha datetime not null,
usuario varchar(15)
primary key(numRegistro))
go

create table sintomasDetalle(
numRegistro int not null,
codInterno int not null,
descripcion varchar(max) not null,
duracion int not null,
primary key(numRegistro,codInterno))
go

create table Auditoria(
tabla varchar(15) not null,
usuario varchar(15),
maquina varchar(15)not null,
fecha datetime not null,
tipoMovimiento varchar(15) not null)
go
--Inserción de datos
insert into usuario (login,password,email,rol) values ('admin','admin','ejemplo@ejemplo.com','Administrador') 
go
select* from usuario
--Este Query en general muestra la información total de todos los pacientes que se encuentren registrados en el sistema

--Este Query muestra la cantidad de registros de sintomas que se han ingresado
select count(numRegistro)
from sintomas
go
--Este siguiente query muestra la cantidad de casos por provincia
select provincia,count(provincia)
from paciente
group by provincia
go
--el siguiente Query nos realiza el filtrado de los sintomas que queramos consultar y devuelve todos 
--los registros que tengan concordancia con lo que se desea buscar en el query se pone como ejemplo buscar
--cuales son los registros en los que se defini+o tos como uno de los sintomas padecidos
select count(numRegistro) AS 'cantidad de registros del sintoma'
from sintomasDetalle
where descripcion like 'tos'
go
--Query que muestra cantidad de pacientes asintomaticos
select count(*)
from sintomasDetalle
where descripcion ='asintomatico'
go
--Query que muestra la cantidad de mujeres infectadas
select count(*)
from paciente p, sintomas s
where p.cedula=s.cedula

and   p.sexo like 'M'
go
-- similiar al anterior Query pero este filtra por provincia la cantidad de mujeres que hay
select p.provincia, count(*)
from paciente p, sintomas s
where p.cedula=s.cedula
and   p.sexo like 'M'
group by  p.provincia
go
--Query que muestra el promedio de duracion de los sintomas registrados pero con posibilidad a ver el promedio por sintoma

--Query que muestra el promedio de duración de los sintomas de cada paciente agrupado por provincia
select p.provincia,avg(sd.duracion) as 'Duración promedio de los sintomas por provincia'
from sintomasDetalle sd,paciente p,sintomas s
where s.numRegistro=sd.numRegistro
and s.cedula=p.cedula
group by  p.provincia
go
--Query que indica los 3 sintomas más comunes registrados
select TOP 3 descripcion,count(*)
from sintomasDetalle
group by descripcion
order by count(*) DESC
go

create procedure [Sp_cnsUsuarioLogin](
@login varchar(30))
as 
select login,email,password,rol 
from usuario
where login like @login
go
--Procedimientos almacenados

--Procedimeintos del Módulo de Pacientes--
--Procedimiento almacenado para consultar pacientes por su nombre
create procedure [SP_Cns_Paciente_Nombre](
@nombre varchar(max))
as select cedula as 'Cédula',nombreCompleto as 'Nombre Completo',provincia as 'Provincia',sexo as 'Sexo',edad as'Edad' 
from paciente
where nombreCompleto like '%'+@nombre+'%'
go
--Prueba del procedimiento
exec [SP_Cns_Paciente_Nombre] ''
go
--Procedimiento almacenado para agregar un nuevo paciente al sistema
create procedure [Sp_Ins_Paciente](
@cedula varchar(15),
@nombreCompleto varchar(max),
@provincia varchar(15),
@sexo char,
@edad int)
as insert into paciente(cedula,nombreCompleto,provincia,sexo,edad) values(@cedula,@nombreCompleto,@provincia,@sexo,@edad)
go
--Procedimiento almacenado para editar un paciente que ya se encuentre registrado en la base de datos
create procedure [Sp_upd_Paciente](
@cedula varchar(15),
@nombreCompleto varchar(max),
@provincia varchar(15),
@sexo char,
@edad int)
as
update paciente
set 
nombreCompleto=@nombreCompleto,
provincia=@provincia,
sexo=@sexo,
edad=@edad
where cedula=@cedula
go
--Procedimiento almacenado para consultar un paciente pero por su número de cédula
create procedure [Sp_Cns_PacienteCedula](
@cedula varchar(15))
as
select cedula,nombreCompleto,provincia,sexo,edad
from paciente
where cedula=@cedula
go
--Procedimiento almacenado para eliminar un paciente de la base de datos
create procedure [Sp_Del_Paciente](
@cedula varchar(15))
as 
delete 
from paciente
where cedula=@cedula
go
create procedure [Cns_CantCasos_Asintomatico_Genero]
as
select p.sexo,count(*)as 'Cantidad Asintom�ticos'
from paciente p,sintomas s,sintomasDetalle sd
where p.cedula=s.cedula
and s.numRegistro=sd.numRegistro
and sd.descripcion like 'Asintomatico'
group by p.sexo
go
--Procedimientos almacenados para los distintos registros de Covid-19 que se van a realizar  en el sistema
alter procedure [Sp_Agregar_RegistroSintoma](
@cedula varchar(15),
@usuario varchar(15))
as
insert into sintomas (cedula,fecha,usuario) values(@cedula,GETDATE(),@usuario)
go
--procedimiento almacenado para agregar un detalle a un registro de sintomas
create procedure [Sp_Agr_DetalleSintomas](
@numRegistro int,
@codInterno int,
@descripcion varchar(30),
@duracion int)
as
insert into sintomasDetalle (numRegistro,codInterno,descripcion,duracion) values(@numRegistro,@codInterno,@descripcion,@duracion)
go
--procedimiento almacenado que me devuelve la cantidad +1 de registros de la tabla sintomas
create procedure [Sp_ConsultarSintomas]
as
select COUNT(numRegistro)+1
from sintomas
go
--procedimiento almacenado que devuelve el último registro insertado a la tabla sintomas
create procedure [Sp_ConsultarUltimo_Indice]
as
select max(numRegistro) 
from sintomas
go
--Procedimientos para el módulo de Estadística
--procedimiento almacenado para consultar cantidad de hombres y mujeres por provincia
create procedure [CnsCantH_M]
as
select p.provincia as'Provincia',p.sexo as 'Sexo',count(s.numRegistro) as 'Cantidad'
from paciente p,sintomas s
where p.cedula=s.cedula
group by p.provincia,p.sexo
order by p.provincia
go
--procedimiento almacenado que me indica el promedio de duracion de cada sintoma registrado
create procedure [Sp_cnsPromDuracion_Sintomas]
as
select distinct descripcion as 'Sintoma',avg(duracion) as 'Promedio Duración (Días)'
from sintomasDetalle
group by descripcion
go
--Prodecimiento almacenado que muestra los sintomas más comunes por provincia
create procedure [Sp_cns_SintomasComunes_Provincia]
as
select  sd.descripcion as 'Descripción',count(*) as 'Cantidad casos',p.provincia as 'Provincia'
from sintomasDetalle sd,paciente p,sintomas s
where sd.numRegistro=s.numRegistro
and s.cedula=p.cedula
group by descripcion,p.provincia
order by count(*) DESC
go
--procedimiento almacenado que muestra la cantidad de sintomas por provincia
create procedure [Sp_cns_CntSintomas_Provincia]
as
select provincia as 'Provincia' ,count(*) as 'N° Casos'
from sintomas s,paciente p
where s.cedula=p.cedula
group by p.provincia
go
--Procedimiento almacenado que muestra cantidad de casos totales por género
create procedure [Cns_CantCasos_Género]
as
select p.sexo, count(*) as 'Cantidad'
from paciente p,sintomas s
where p.cedula=s.cedula
group by p.sexo
go


--
delete from sintomas where cedula =(select cedula from paciente where sexo ='') 
--
delete from sintomasDetalle where numRegistro=(select numRegistro from sintomas where cedula =(select cedula from paciente where sexo ='') )


------------------------------
create procedure [SP_Cns_Paciente_Nombre](
@nombre varchar(max))
as select cedula as 'C�dula',nombreCompleto as 'Nombre Completo',provincia as 'Provincia',sexo as 'Sexo',edad as'Edad' 
from paciente
where nombreCompleto like '%'+@nombre+'%'
go
--Prueba del procedimiento
exec [SP_Cns_Paciente_Nombre] ''
go
--Procedimiento almacenado para agregar un nuevo paciente al sistema
create procedure [Sp_Ins_Paciente](
@cedula varchar(15),
@nombreCompleto varchar(max),
@provincia varchar(15),
@sexo char,
@edad int)
as insert into paciente(cedula,nombreCompleto,provincia,sexo,edad) values(@cedula,@nombreCompleto,@provincia,@sexo,@edad)
go
--Procedimiento almacenado para editar un paciente que ya se encuentre registrado en la base de datos
create procedure [Sp_upd_Paciente](
@cedula varchar(15),
@nombreCompleto varchar(max),
@provincia varchar(15),
@sexo char,
@edad int)
as
update paciente
set 
nombreCompleto=@nombreCompleto,
provincia=@provincia,
sexo=@sexo,
edad=@edad
where cedula=@cedula
go
--Procedimiento almacenado para consultar un paciente pero por su n�mero de c�dula
create procedure [Sp_Cns_PacienteCedula](
@cedula varchar(15))
as
select cedula,nombreCompleto,provincia,sexo,edad
from paciente
where cedula=@cedula
go
--Procedimiento almacenado para eliminar un paciente de la base de datos
create procedure [Sp_Del_Paciente](
@cedula varchar(15))
as 
delete 
from paciente
where cedula=@cedula
go
--Procedimientos almacenados para los distintos registros de Covid-19 que se van a realizar  en el sistema
create procedure [Sp_Agregar_RegistroSintoma](
@cedula varchar(15),
@usuario varchar(15))
as
insert into sintomas (cedula,fecha,usuario) values(@cedula,GETDATE(),@usuario)
go
--procedimiento almacenado para agregar un detalle a un registro de sintomas
create procedure [Sp_Agr_DetalleSintomas](
@numRegistro int,
@codInterno int,
@descripcion varchar(30),
@duracion int)
as
insert into sintomasDetalle (numRegistro,codInterno,descripcion,duracion) values(@numRegistro,@codInterno,@descripcion,@duracion)
go
--procedimiento almacenado que me devuelve la cantidad +1 de registros de la tabla sintomas
create procedure [Sp_ConsultarSintomas]
as
select COUNT(numRegistro)+1
from sintomas
go
--procedimiento almacenado que devuelve el �ltimo registro insertado a la tabla sintomas
create procedure [Sp_ConsultarUltimo_Indice]
as
select max(numRegistro) 
from sintomas
go
--Procedimientos para el m�dulo de Estad�stica
--procedimiento almacenado para consultar cantidad de hombres y mujeres por provincia
create procedure [CnsCantH_M]
as
select p.provincia as'Provincia',p.sexo as 'Sexo',count(s.numRegistro) as 'Cantidad'
from paciente p,sintomas s
where p.cedula=s.cedula
group by p.provincia,p.sexo
order by p.provincia
go
--procedimiento almacenado que me indica el promedio de duracion de cada sintoma registrado
create procedure [Sp_cnsPromDuracion_Sintomas]
as
select distinct descripcion as 'Sintoma',avg(duracion) as 'Promedio Duraci�n (D�as)'
from sintomasDetalle
group by descripcion
go
--Prodecimiento almacenado que muestra los sintomas m�s comunes por provincia
create procedure [Sp_cns_SintomasComunes_Provincia]
as
select top 4 sd.descripcion as 'Descripci�n',count(*) as 'Cantidad casos'
from sintomasDetalle sd,paciente p,sintomas s
where sd.numRegistro=s.numRegistro
and s.cedula=p.cedula
group by descripcion
order by count(*) DESC
go
--procedimiento almacenado que muestra la cantidad de sintomas por provincia
create procedure [Sp_cns_CntSintomas_Provincia]
as
select provincia as 'Provincia' ,count(*) as 'N� Casos'
from sintomas s,paciente p
where s.cedula=p.cedula
group by p.provincia
go
--Procedimiento almacenado que muestra cantidad de casos totales por g�nero
create procedure [Cns_CantCasos_Género]
as
select p.sexo, count(*) as 'Cantidad'
from paciente p,sintomas s
where p.cedula=s.cedula
group by p.sexo
go

create procedure [Cns_CantCasos_Asintomatico_Genero]
as
select p.sexo,count(*)as 'Cantidad Asintom�ticos'
from paciente p,sintomas s,sintomasDetalle sd
where p.cedula=s.cedula
and s.numRegistro=sd.numRegistro
and sd.descripcion like 'Asintomatico'
group by p.sexo
go
--

--Procedimientos m�dulo usuarios
create procedure [Sp_cons_Usuarios](
@login varchar(30))
as
select login as 'Login',email as 'Correo Electr�nico',rol as 'Rol'
from usuario
where login like '%'+@login+'%'
go
create procedure [Sp_agr_Usuario](
@login varchar(15),
@password varchar(15),
@email varchar(max),
@rol varchar(50))
as insert into usuario (login,password,email,rol)values(@login,@password,@email,@rol)
go
--Procedimiento almacenado que devuelve un usuario por su login
create procedure [Sp_cnsUsuarioLogin](
@login varchar(30))
as 
select login,email,password,rol 
from usuario
where login like @login
go
--
create procedure [Sp_upd_Usuario](
@login varchar(15),
@password varchar(15),
@email varchar(max),
@rol varchar(15))
as
update usuario
set 
password=@password,
email=@email,
rol=@rol
where login =@login
go
--
create procedure [Del_Usuario](
@login varchar(30))
as 
delete 
from usuario
where login=@login
go