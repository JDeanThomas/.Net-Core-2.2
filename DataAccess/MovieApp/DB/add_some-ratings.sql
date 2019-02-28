insert into rating (Code, Name) values ('G', 'General Audiences');
insert into rating (Code, Name) values ('PG', 'Parental Guidance Suggested');
insert into rating (Code, Name) values ('PG-13', 'Parents Strongly Cautioned');
insert into rating (Code, Name) values ('R', 'Restricted');

update film set RatingCode = 'PG', RatingId = 2 where FilmId in (6, 7, 8, 9, 10);
update film set RatingCode = 'PG-13', RatingId = 3 where RatingId is null;

select FilmId, RatingCode, RatingId, Title from film;
select * from rating;