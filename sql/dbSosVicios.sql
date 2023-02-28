
drop database dbSosvicios;

create database dbSosvicios;	

use dbSosvicios;

create table tbFuncionarios(
idFunc int not null auto_increment,
nome varchar(100),
cpf char(18) not null unique,
tel char(18),
endereco varchar(300),
primary key(idFunc)
);

create table tbUsuarios(
idUsu int not null auto_increment,                         
nome varchar(100) not null,
senha varchar(50),
primary key(idUsu)
);


create table tbONGs(
idONG int not null auto_increment,
nome varchar (100),
tel char (18) not null,
cnpj char (18) unique,
endereco varchar (300) not null,
website varchar(300),
primary key (idONG)
);

insert into tbFuncionarios(nome,cpf,tel,endereco)values('gabriel sousa silva','555.888.999-25','(11) 94320-2831','Parelheiros-Rua Sonia,N*58');

insert into tbFuncionarios(nome,cpf,tel,endereco)values('erick santos silva','455.808.999-25','(11) 94320-2861','Boa vista-Rua jose,N*12');


insert into tbUsuarios(nome,senha)values('gabriel','123');

insert into tbUsuarios(nome,senha)values('erick','1234');


insert into tbONGs(nome,tel,cnpj,endereco,website) values ('Recanto Nova Vida','(11) 98720-2831','33.133.791/001-872','Recanto Vida Nova, Estr. Armando Cunha, 1321 - Jardim Somar, Peruíbe - SP, 11750-000','https://recantonovavida.com.br/index.html');

insert into tbONGs(nome,tel,cnpj,endereco,website) values ('Pro Paz','(14) 3664-0330','28.617.933/001-412','Rod. Vicinal Angelo Poli, Km 06 Marambaia - Cep: 17.230-000 Itapuí/SP','http://www.propaz.org.br/');

insert into tbONGs(nome,tel,cnpj,endereco,website) values ('Instituto Asael','(11) 96357-5569','72.027.941/000-204','Juquitiba - SP','https://institutoasael.com.br/');

insert into tbONGs(nome,tel,cnpj,endereco,website) values ('Instituto Samprev','(11) 4784-5959','47.286.437/001-057','Av. Santa Rita, 46 Sobreloja','https://institutosamprev.com.br/');

select * from tbFuncionarios;
select * from tbUsuarios;
select * from tbONGs;

