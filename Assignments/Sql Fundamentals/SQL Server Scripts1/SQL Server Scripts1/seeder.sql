USE SqlAssignament;

INSERT INTO dbo.Users (Email, Pass, FirstName, LastName)
VALUES
('nmaharey0@wikimedia.org', 'EdW5REs7', 'Nola', 'Maharey'),
('cramos1@columbia.edu', 'hizd3u1qM2', 'Caryl', 'Ramos'),
('ccassella2@chronoengine.com', 'R8M5qUjPl8Kh', 'Carmina', 'Cassella'),
('cluciano3@sakura.ne.jp', 'ufJIG8Z2WKp', 'Carling', 'Luciano'),
('drye4@sohu.com', 'bUbkeGp6xc', 'Dodie', 'Rye'),
('awingfield5@stanford.edu', 'xKR5foMNlc', 'Allx', 'Wingfield'),
('lgoncaves6@wordpress.org', '4N6M2zJzY', 'Lyssa', 'Goncaves'),
('tsennett7@imgur.com', '8KJUcES2Q', 'Tod', 'Sennett'),
('dlind8@amazonaws.com', 'wGVfl8', 'Drusilla', 'Lind'),
('tchicotti9@nsw.gov.au', 'nm5tomg', 'Tamarah', 'Chicotti'),
('michael.scott@dundermifflin.com', 'aafg32gs', 'Michael', 'Scott')

INSERT INTO dbo.Properties (Owner, Name, Description, MaxGuests, Address, Price)
VALUES
(9, 'Waterloo Apartment', NULL, 3, '78 Sloan Circle', 464.22),
(3, 'Superior Studio', 'Studio for 2 people in the city center', 2, '10249 Sutteridge Avenue', 50.43),
(6, 'Executive Suite', NULL, 7, '0 Merrick Place', 340.77),
(1, 'Urban Retreat', 'Small house around London with a very nice yard', 14, '8 Sherman Way', 136.53),
(7, 'Accomodation in Croydon', 'Apartment in a historical building in town center', 4, '957 Jackson Hill', 106.38),
(2, 'Lovely, newly renovated old victorian house', NULL, 11, '50376 Grim Terrace', 643.14),
(4, '4 Beds House', NULL, 4, '1396 Caliangt Pass', 97.45),
(5, 'Stunning Refurbished house', 'Our comfortable, and recently refurbished home', 10, '8 Declaration Terrace', 129.54),
(10, 'Lovely flat', 'Lovely flat located on the outskirts of Manchester', 6, '52 East Court', 200.71),
(8, 'Heart of the city center', 'Two double bedroom apartment in the heart', 4, '10 Veith Plaza', 211.68)

INSERT INTO dbo.Reservations (Client, Owner, CheckinDate, CheckoutDate, GuestsNumber, TotalPrice)
VALUES
(7, 6, '2022-04-09', '2022-05-01', 6, 9666.95),
(3, 9, '2022-04-15', '2022-04-29', 3, 4800.48),
(9, 5, '2022-04-11', '2022-04-21', 8, 1234.97),
(7, 5, '2022-04-22', '2022-04-24', 10, 400.47),
(4, 3, '2022-04-09', '2022-05-05', 2, 1614.78),
(2, 8, '2022-04-13', '2022-05-02', 3, 3493.86),
(1, 3, '2022-04-07', '2022-04-17', 1, 9504.52),
(2, 1, '2022-04-15', '2022-04-21', 12, 4084.59),
(10, 7, '2022-04-15', '2022-05-01', 4, 3141.29),
(9, 2, '2022-04-10', '2022-04-16', 1, 680.81)