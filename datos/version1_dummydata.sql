USE chicasunicornio;

-- Dumping data for table game inventory 
SET AUTOCOMMIT=0;
INSERT INTO gameinventory VALUES 
("inv1", 1, 1), 
("inv2", 12, 8),
("inv3", 8, 4),
("inv4", 11, 7),
("inv5", 3, 5),
("inv6", 9, 3),
("inv7", 2, 6),
("inv8", 10, 2),
("inv9", 7, 3);

-- Dumping data for table game assets
-- SET AUTOCOMMIT=0;
INSERT INTO game_assets VALUES 
("sh4", 'Shield'),
("g6", 'Gadget'),
("sh5", 'Shield'),
("ks5", 'Killer-Sprite'),
("sh6", 'Shield'),
("g2", 'Gadget'),
("ks7", 'Killer-Sprite'),
("sh1", 'Shield'),
("ks6", 'Killer-Sprite'),
("g1", 'Gadget'),
("g4", 'Gadget'),
("ks2", 'Killer-Sprite'),
("sh7", 'Shield'),
("ks1", 'Killer-Sprite'),
("sh3", 'Shield'),
("ks8", 'Killer-Sprite'),
("sh8", 'Shield'),
("g3", 'Gadget'),
("ks4", 'Killer-Sprite'),
("sh2", 'Shield'),
("g8", 'Gadget'),
("g5", 'Gadget'),
("ks3", 'Killer-Sprite'),
("g7", 'Gadget');

-- Dumping data for table gadgets
SET AUTOCOMMIT=0;
INSERT INTO gadgets VALUES
('g1','Carrot', -1, 2, 8, 1),
('g2','Fire Shoe', 2, 6, -4, -2),
('g3','Silver', -4, 1, 2, 6),
('g4','Spike Shoe', 1, 5, -3, -1),
('g5','Hairband', 4, -2, 1, -1),
('g6','Apple', 1, -2, 8, -4),
('g7','Gold', -5, 2, 2, 8),
('g8','Crown', 8, -5, 2, 2);

-- Dumping data for table Current_score
SET AUTOCOMMIT=0;
INSERT INTO current_score VALUES 
(NOT NULL, 11, 6, 7, 8),
(NOT NULL, 16, 12, 10, 9),
(NOT NULL, 2, 3, 4, 17),
(NOT NULL, 0, 13, 18, 1),
(NOT NULL, 17, 20, 13, 1),
(NOT NULL, 0, 2, 3, 16),
(NOT NULL, 9, 16, 0, 6),
(NOT NULL, 5, 19, 6, 20);

-- Dumping data for table killer_sprites
SET AUTOCOMMIT=0;
INSERT INTO killer_sprites VALUES 
('ks1','Bomb','Shield', -7),
('ks2','Iceiles', 'Agility',-6),
('ks3','Pool', 'Speed', -5),
('ks4','Bomb', 'Shield', -9),
('ks5','Rock', 'Strength',-8),
('ks6','Iceiles', 'Agility', -5),
('ks7','Rock', 'Strength',-7),
('ks8','Pool', 'Speed', -6);

-- Dumping data for table shields
SET AUTOCOMMIT=0;
INSERT INTO shields VALUES 
('sh1','pink', 2, -1, 2, 4),
('sh2','Green', 1, -3, 2, -1),
('sh3','Blue', 1, 2, 3, 0),
('sh4','Green', 3, -2, 0, 2),
('sh5','Blue', -2, 3, 1, 2),
('sh6','pink', 1, 0, -1, 1), 
('sh7','Green', -1, 0, 1, 0),
('sh8','pink', 0, 1, 0, 2);

-- Dumping data for table checkpoint
SET AUTOCOMMIT=0;
INSERT INTO checkpoint VALUES 
(NOT NULL, '2023-04-12 12:00:00', 1, 1, 120),
(NOT NULL, '2023-04-12 13:00:00', 1, 1, 240),
(NOT NULL, '2023-04-12 14:00:00', 3, 2, 180),
(NOT NULL, '2023-04-12 15:00:00', 2, 3, 90),
(NOT NULL, '2023-04-12 16:00:00', 4, 4, 60),
(NOT NULL, '2023-04-12 17:00:00', 5, 5, 300),
(NOT NULL, '2023-04-12 18:00:00', 6, 4, 200),
(NOT NULL, '2023-04-12 19:00:00', 6, 4, 150);

-- Dumping data for table users
SET AUTOCOMMIT=0;
INSERT INTO users VALUES 
(1, 'password1', 'Fer', 'Osorio', 'Fer.Osorio@unicornios.com'),
(2, 'password2', 'Emo', 'Salazar', 'Emo.Salazar@unicornios.com'),
(3, 'password3', 'Lu', 'Barrenechea', 'Lu.Barrenechea@unicornios.com'),
(4, 'password4', 'Fer', 'Cortes', 'Fer.Cortes@unicornios.com'),
(5, 'password5', 'Asha', 'Parra', 'Asha.Parra@unicornios.com'),
(6, 'password6', 'Esteban', 'Castillo', 'Esteban.Castillo@unicornios.com'),
(7, 'password7', 'Octavio', 'Navarro', 'Octavio.Navarro@unicornios.com'),
(8, 'password8', 'Gilberto', 'Echeverria', 'Gilberto.Echeverria@unicornios.com');

-- Dumping data for table game_history
SET AUTOCOMMIT=0;
INSERT INTO game_history VALUES
(NOT NULL, '2023-04-12 12:00:00', 1, 1, "inv1", 1, 3, 250, NULL),
(NOT NULL, '2023-04-12 13:10:00', 2, 6, "inv2", 8, 0, 20, 'Life tank'),
(NOT NULL, '2023-04-12 13:10:00', 8, 7, "inv3", 7, 0, 70, 'Final battle'),
(NOT NULL, '2023-04-12 13:10:00', 7, 8, "inv4", 4, 0, 50, 'Life tank'),
(NOT NULL, '2023-04-12 13:10:00', 4, 45, "inv5", 3, 3, 150, NULL),
(NOT NULL, '2023-04-12 13:10:00', 3, 4, "inv6", 4, 0, 12, 'Final battle'),
(NOT NULL,'2023-04-12 13:10:00',  8, 2, "inv7", 7, 0, 4, 'Life tank'),
(NOT NULL, '2023-04-12 13:10:00', 1, 8, "inv8", 6, 1, 140, NULL),
(NOT NULL, '2023-04-12 13:10:00', 1, 10, "inv9", 6, 2, 80, NULL);

-- Dumping data for table highscore
SET AUTOCOMMIT=0;
INSERT INTO highscore VALUES
(NOT NULL, 1, 80, 1),
(NOT NULL,2, 140, 3),
(NOT NULL,3, 150, 5),
(NOT NULL,4, 250, 3);
