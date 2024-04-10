use master;
go

drop database if exists lanachotela;
go

create database lanachotela collate Croatian_CI_AS;
go

--drop database lanachotela;
use lanachotela;

create table hoteli(
sifra int not null primary key identity(1,1),
naziv varchar(50) not null,
mjesto varchar(50) not null,
gost int,
soba int);

create table gosti(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
nocenje datetime,
soba int);

create table djelatnici(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
hotel int not null);

create table sobe(
sifra int not null primary key identity(1,1),
oznaka char(50) not null,
kapacitet varchar (50) not null);

Alter table djelatnici
add foreign key (hotel) references hoteli(sifra);

Alter table gosti
add foreign key(soba) references sobe(sifra);

Alter table hoteli
add foreign key(soba) references sobe(sifra);

insert into hoteli ( naziv, mjesto)
values ('Hotel1', 'Rijeka'), ('Hotel2', 'Osijek'), ('Hotel1', 'Zagreb');

insert into djelatnici (ime, prezime, hotel)
values ('pero','perić', 1), ('ivo','ivic', 2), ('marija','maric', 3);

insert into gosti (ime, prezime, nocenje)
values ('Mate','Pernar', '2023-11-29 19:00:00'), ('Tomislav','Tomic', '2023-10-29 19:00:00'),
('Mile','Milic', '2024-11-29 15:00:00');

insert into sobe ( oznaka, kapacitet)
values ('1', 'jednokrevetna'), ('2', 'dvokrevetna'), ('3', 'jednokrevetna');

select * from gosti;
