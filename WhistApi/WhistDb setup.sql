drop table Regels�tPlus;
drop table SpilBruger;
drop table Runder;

drop table Venner;
drop table Spil;
drop table Regels�t;
drop table Plus;
drop table Bruger;

create table Bruger(
Id int primary key identity(1,1),
Brugernavn varchar(20) not null,
Adgangskode varchar(30) not null,
Fornavn varchar(15) not null,
Efternavn varchar(20) not null,
Mail varchar(50) not null
)

create table Venner(
AcceptId int foreign key references Bruger(Id),
Ans�gId int foreign key references Bruger(Id),
Godkendt bit not null
)





create table Regels�t(
Id int primary key identity(1,1),
Base decimal  not null,
MultiplyTab decimal not null,
BaseVip decimal not null,
)

create table Spil(
Id int primary key identity(1,1),
Regels�tId int foreign key references Regels�t(Id)
)

create table SpilBruger(
SpilId int foreign key references Spil(Id),
BrugerId int foreign key references Bruger(Id)
)

create table Plus(
Id int primary key identity(1,1),
Navn varchar(15) not null
)

create table Regels�tPlus(
RegelId int foreign key references Regels�t(Id),
PlusId int foreign key references Plus(Id)
)

create table Runder(
Id int primary key identity(1,1),
SpilId int foreign key references Spil(Id),
RundeNr int not null,
Melder int not null,
Melding int not null,
PlusId int foreign key references Plus(Id),
Makker int,
Vundet bit not null,
Bel�b decimal not null,
Spiller1 int not null,
Spiller2 int not null,
Spiller3 int not null,
Spiller4 int not null
)



