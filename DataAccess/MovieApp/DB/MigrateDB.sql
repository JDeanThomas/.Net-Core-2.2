CREATE TABLE Movies.`__efmigrationshistory` (
`MigrationId` varchar(95) NOT NULL,
`ProductVersion` varchar(32) NOT NULL,
PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
insert into Movies.__efmigrationshistory 
select * from MoviesTemp.__efmigrationshistory;
select * from Movies.__efmigrationshistory;