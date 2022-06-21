create database ferreteria;

use ferreteria;

create table Herramienta(
id int identity(1,1) primary key not null,
nombre varchar(100) not null,
precio decimal not null,
marca varchar(100),
existencias int not null
);

select * from Herramienta;