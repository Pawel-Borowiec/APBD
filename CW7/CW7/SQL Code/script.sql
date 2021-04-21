insert into trip.Country (IdCountry, Name)
VALUES (1, 'Poland');

insert into trip.Country (IdCountry, Name)
VALUES (2, 'Tunis');

insert into trip.Country (IdCountry, Name)
VALUES (3, 'Izrael');

insert into trip.Country (IdCountry, Name)
VALUES (4, 'India');

insert into trip.Country (IdCountry, Name)
VALUES (5, 'Egypt');

INSERT INTO trip.Trip (IdTrip, Name, Description, DateFrom, DateTo, MaxPeople)
VALUES (1,'Voyage without toilet','Someone expects good toilet in India? XD','2001-01-01','2001-02-02',6);

INSERT INTO trip.Trip (IdTrip, Name, Description, DateFrom, DateTo, MaxPeople)
VALUES (2,'Nile trip','Traveling via Nile from alexandria to cradle of civilization','2004-01-01','2005-02-02',20);

INSERT INTO trip.Trip (IdTrip, Name, Description, DateFrom, DateTo, MaxPeople)
VALUES (3,'Holy land','We will take jerusalem','2008-01-01','2009-04-20',6);


INSERT INTO trip.Client (IdClient, FirstName, LastName, Email, Telephone, Pesel)
VALUES (1, 'Paweł', 'Borowiec','pawel@gmail.com','000-000-000','2137124414')

INSERT INTO trip.Client (IdClient, FirstName, LastName, Email, Telephone, Pesel)
VALUES (2, 'Radek', 'Kulka','kulekcza@gmail.com','111-111-111','2178070914')

INSERT INTO trip.Client (IdClient, FirstName, LastName, Email, Telephone, Pesel)
VALUES (3, 'Paweł', 'Makareński','makarena@gmail.com','212-340-420','2112407084')

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (1, 1);

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (4, 1);

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (1, 2);

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (5, 2);

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (1, 3);

INSERT INTO trip.Country_Trip(IdCountry, IdTrip)
VALUES (3, 3);


INSERT INTO trip.Client_Trip(IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 1, '2000-01-01','2000-01-01');

INSERT INTO trip.Client_Trip(IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 2, '2000-01-01','2000-01-11');

INSERT INTO trip.Client_Trip(IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 3, '2000-01-01','2000-01-02');

INSERT INTO trip.Client_Trip(IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (2, 2, '2000-01-01','2000-01-14');

INSERT INTO trip.Client_Trip(IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (3, 3, '2000-01-01','2000-02-02');
