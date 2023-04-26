DROP SCHEMA IF EXISTS chicasunicornio;
CREATE SCHEMA chicasunicornio;
USE chicasunicornio;

-- Los usuarios que existen
CREATE TABLE `users` (
  `username_ID`integer unsigned NOT NULL AUTO_INCREMENT ,
  `password` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (username_ID)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Los gadgets que existen en el juego (12)
CREATE TABLE `gadgets` (
  `gadget_ID` integer  NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment,
  `gadgetname` varchar(45) NOT NULL,
  `ability_speed` tinyint  NOT NULL,
  `ability_strength` tinyint  NOT NULL,
  `ability_agility` tinyint  NOT NULL,
  `ability_shield` tinyint  NOT NULL,
   PRIMARY KEY (gadget_ID)
    -- CONSTRAINT gadgetasset FOREIGN KEY (gadget_ID) REFERENCES game_assets(asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Los shields que existen en el juego (3)
CREATE TABLE `shields` (
  `shield_id`  integer NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `color` varchar(45) NOT NULL,
  `ability_speed` tinyint NOT NULL,
  `ability_strength` tinyint  NOT NULL,
  `ability_agility` tinyint NOT NULL,
  `ability_shield` tinyint NOT NULL,
  PRIMARY KEY (shield_id)
	-- CONSTRAINT shieldasset FOREIGN KEY (shield_id) REFERENCES game_assets(asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Los killer sprites que existen en el juego. (4)
CREATE TABLE `killer_sprites` (
  `killersprite_Id` integer NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `name` varchar(45) NOT NULL,
  `ability` varchar(45) NOT NULL,
  `point_consequence` tinyint NOT NULL,
  PRIMARY KEY (killersprite_Id)
  -- CONSTRAINT killerspriteasset FOREIGN KEY (killersprite_Id) REFERENCES game_assets(asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Esta tabla contiene el historial de los gadgets recolectados dentro del juego
CREATE TABLE `gadgetinventory` (
  `inventory_id` tinyint unsigned auto_increment, 
  `gadgetid` integer NOT NULL,
  PRIMARY KEY (inventory_id),
  CONSTRAINT FKgadgetname FOREIGN KEY (gadgetid) REFERENCES gadgets(gadget_ID) ON DELETE RESTRICT ON UPDATE CASCADE 
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Esta tabla contiene el historial de los killersprites pasados en el juego.
CREATE TABLE `killerspriteinventory` (
  `inventory_id` integer NOT NULL AUTO_INCREMENT, 
  `killersprite_Id` integer NOT NULL,
  PRIMARY KEY (inventory_id),
  CONSTRAINT FKkillersprite_inventory FOREIGN KEY (killersprite_Id) REFERENCES killer_sprites(killersprite_Id) ON DELETE RESTRICT ON UPDATE CASCADE 
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Indica el score con el que acaba el usuario la partida.
CREATE TABLE `final_score` ( -- final score
  `score_ID` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `username_ID`integer unsigned NOT NULL,
  `total_score` int unsigned NOT NULL, -- añadi esta columna
  `score_speed` tinyint unsigned  NOT NULL,
  `score_strength` tinyint unsigned  NOT NULL,
  `score_agility` tinyint unsigned  NOT NULL,
  `score_shield` tinyint unsigned  NOT NULL,
   PRIMARY KEY (score_ID),
   CONSTRAINT userscore FOREIGN KEY (username_ID) REFERENCES users(username_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Indica el checkpoint por el cual paso el usuario (Donde cambia de mundos)
CREATE TABLE `checkpoint` (
  `register_ID`  integer unsigned NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NOT NULL,
  `checkpoint` tinyint unsigned NOT NULL,
  `username_ID` integer unsigned NOT NULL,
  `game_time` smallint unsigned NOT NULL,
  PRIMARY KEY (register_ID),
  CONSTRAINT usercheckpoint FOREIGN KEY (username_ID) REFERENCES users(username_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Historial final de la partida.
CREATE TABLE `game_history` (
  `register_ID` integer unsigned NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NOT NULL,
  `username_ID` integer unsigned NOT NULL,
  `shield_id` integer NOT NULL,
  `lives` tinyint NOT NULL,
  `score_ID` tinyint unsigned NOT NULL ,
  `times_played` integer unsigned NOT NULL,
  PRIMARY KEY (register_ID),
  CONSTRAINT currentgamehistory FOREIGN KEY (username_ID) REFERENCES users(username_ID) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT shieldused FOREIGN KEY (shield_id) REFERENCES shields(shield_id) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT finalscore FOREIGN KEY (score_ID) REFERENCES final_score(score_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
