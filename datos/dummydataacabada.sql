USE chicasunicornio;

-- Dumping data for table users
INSERT INTO users VALUES 
(NOT NULL, 'password1', 'Fer', 'Osorio', 'Fer.Osorio@unicornios.com'),
(NOT NULL,'password2', 'Emo', 'Salazar', 'Emo.Salazar@unicornios.com'),
(NOT NULL, 'password3', 'Lu', 'Barrenechea', 'Lu.Barrenechea@unicornios.com'),
(NOT NULL, 'password4', 'Fer', 'Cortes', 'Fer.Cortes@unicornios.com'),
(NOT NULL, 'password5', 'Asha', 'Parra', 'Asha.Parra@unicornios.com'),
(NOT NULL, 'password6', 'Esteban', 'Castillo', 'Esteban.Castillo@unicornios.com'),
(NOT NULL, 'password7', 'Octavio', 'Navarro', 'Octavio.Navarro@unicornios.com'),
(NOT NULL, 'password8', 'Gilberto', 'Echeverria', 'Gilberto.Echeverria@unicornios.com');

-- Dumping data for table gadgets
INSERT INTO gadgets VALUES
(121,'Carrot', -1, 2, 8, 1),
(122,'Fire Shoe', 2, 6, -4, -2),
(123,'Silver', -4, 1, 2, 6),
(124,'Spike Shoe', 1, 5, -3, -1),
(125,'Hairband', 4, -2, 1, -1),
(126,'Apple', 1, -2, 8, -4),
(127,'Gold', -5, 2, 2, 8),
(128,'Crown', 8, -5, 2, 2);

-- Dumping data for table shields
INSERT INTO shields VALUES 
(141,'pink', 2, -1, 2, 4),
(142,'blue', 1, -3, 2, -1),
(143,'red', 1, 2, 3, 0);

-- Dumping data for table killer_sprites
INSERT INTO killer_sprites VALUES 
(131,'Bomb','Shield', -7),
(132,'Iceiles', 'Agility',-6),
(133,'Pool', 'Speed', -5),
(134,'Rock', 'Shield', -9);

INSERT INTO killerspriteinventory VALUES
(NOT NULL, 131),
(NOT NULL, 132),
(NOT NULL, 133),
(NOT NULL, 133),
(NOT NULL, 131),
(NOT NULL, 134),
(NOT NULL, 134);

-- Dumping data for table game inventory 
SET AUTOCOMMIT=1;
INSERT INTO gadgetinventory VALUES 
(NOT NULL, 121), 
(NOT NULL, 122),
(NOT NULL, 123),
(NOT NULL, 124),
(NOT NULL, 122),
(NOT NULL, 126),
(NOT NULL, 127),
(NOT NULL, 128);

-- Dumping data for table Current_score
INSERT INTO final_score VALUES 
(NOT NULL, 1, 105, 11, 6, 7, 8),
(NOT NULL, 2, 106, 16, 12, 10, 9),
(NOT NULL, 3, 107, 2, 3, 4, 17),
(NOT NULL, 1, 108, 0, 13, 18, 1),
(NOT NULL, 5, 1010, 17, 20, 13, 1),
(NOT NULL, 2, 103, 0, 2, 3, 16),
(NOT NULL, 7, 107, 9, 16, 0, 6),
(NOT NULL, 8, 102, 5, 19, 6, 20);

-- Dumping data for table checkpoint
INSERT INTO checkpoint VALUES 
(NOT NULL, '2023-04-12 12:00:00', 1, 1, 120),
(NOT NULL, '2023-04-12 13:00:00', 1, 1, 240),
(NOT NULL, '2023-04-12 14:00:00', 3, 2, 180),
(NOT NULL, '2023-04-12 15:00:00', 2, 3, 90),
(NOT NULL, '2023-04-12 16:00:00', 4, 4, 60),
(NOT NULL, '2023-04-12 17:00:00', 5, 5, 300),
(NOT NULL, '2023-04-12 18:00:00', 6, 4, 200),
(NOT NULL, '2023-04-12 19:00:00', 6, 4, 150);

-- Dumping data for table game_history
INSERT INTO game_history VALUES
(NOT NULL, '2023-04-12 12:00:00', 1, 141, 1, 1, 250),
(NOT NULL, '2023-04-12 13:10:00', 2, 142, 2, 2, 20),
(NOT NULL, '2023-04-12 13:10:00', 7, 143, 3, 3, 70),
(NOT NULL, '2023-04-12 13:10:00', 3, 141, 1, 4, 50),
(NOT NULL, '2023-04-12 13:10:00', 4, 142, 2, 5, 150),
(NOT NULL, '2023-04-12 13:10:00', 5, 143, 3, 6, 12),
(NOT NULL,'2023-04-12 13:10:00',  6, 141, 1, 7, 4),
(NOT NULL, '2023-04-12 13:10:00', 1, 142, 2, 8, 140);
