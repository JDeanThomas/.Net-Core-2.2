CREATE TABLE `movies`.`FilmImage` (
FilmImageId int NOT NULL AUTO_INCREMENT,
Title varchar(255),
ImageUrl varchar(255),
FilmId int,
Film varchar (255),
primary key (FilmImageId),
foreign key (FilmId) references Film(FilmId)
);