DROP SCHEMA IF EXISTS chicasunicornio;
CREATE SCHEMA chicasunicornio;
USE chicasunicornio;

CREATE TABLE `gameinventory` (
  `inventory_id` varchar(45) PRIMARY KEY NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `gadget_id` tinyint unsigned NOT NULL, 
  `inventory_space` tinyint unsigned NOT NULL
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `game_assets` (
  `asset_id`  varchar(45) PRIMARY KEY NOT NULL, -- AQUI NO VA EL USTOINCREMENT, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `asset_type` varchar(45) NOT NULL
  -- CONSTRAINT gadgetasset FOREIGN KEY (asset_id) REFERENCES gadgets (gadget_id) ON DELETE RESTRICT ON UPDATE CASCADE -- ya cambiada
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `gadgets` (
  `gadget_ID` varchar(45) PRIMARY KEY NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment,
  `name` varchar(45) NOT NULL,
  `ability_speed` tinyint  NOT NULL,
  `ability_strength` tinyint  NOT NULL,
  `ability_agility` tinyint  NOT NULL,
  `ability_shield` tinyint  NOT NULL,
	-- CONSTRAINT gadgetinventory FOREIGN KEY (gadget_ID) REFERENCES gameinventory(inventory_id) ON DELETE RESTRICT ON UPDATE CASCADE
    CONSTRAINT gadgetasset FOREIGN KEY (gadget_ID) REFERENCES game_assets (asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
	
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `killer_sprites` (
  `killersprite_Id` varchar(45) PRIMARY KEY NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `name` varchar(45) NOT NULL,
  `ability` varchar(45) NOT NULL,
  `point_consequence` tinyint NOT NULL,
  CONSTRAINT killerspriteasset FOREIGN KEY (killersprite_Id) REFERENCES game_assets (asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `current_score` (
  `score_ID` tinyint unsigned  PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `score_speed` tinyint unsigned  NOT NULL,
  `score_strength` tinyint unsigned  NOT NULL,
  `score_agility` tinyint unsigned  NOT NULL,
  `score_shield` tinyint unsigned  NOT NULL
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `shields` (
  `shield_id`  varchar(45) PRIMARY KEY NOT NULL, -- Lo teníamos asignado como tinyint unsigned auto_increment
  `color` varchar(45) NOT NULL,
  `ability_speed` tinyint NOT NULL,
  `ability_strength` tinyint  NOT NULL,
  `ability_agility` tinyint NOT NULL,
  `ability_shield` tinyint NOT NULL,
	CONSTRAINT shieldasset FOREIGN KEY (shield_id) REFERENCES game_assets (asset_id) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `checkpoint` (
  `register_ID`  integer unsigned PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NOT NULL,
  `checkpoint` tinyint unsigned NOT NULL,
  `username_ID` integer NOT NULL,
  `game_time` smallint unsigned NOT NULL
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `users` (
  `username_ID`  integer unsigned PRIMARY KEY NOT NULL,
  `password` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  CONSTRAINT usercheckpoint FOREIGN KEY (username_ID) REFERENCES checkpoint (register_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `game_history` (
  `register_ID` integer unsigned PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `created_at` timestamp NOT NULL,
  `username_ID` integer unsigned NOT NULL,
  `shield_id` tinyint unsigned NOT NULL,
  `inventory_id` varchar(45) NOT NULL,
  `score_id`  tinyint unsigned NOT NULL,
  `lives` tinyint NOT NULL,
  `score` smallint NOT NULL,
  `loss_reason` varchar(45),
  CONSTRAINT currentgamehistory FOREIGN KEY (username_ID) REFERENCES users (username_ID) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT currentgameinventory FOREIGN KEY (inventory_id) REFERENCES gameinventory (inventory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT currentscorehistory FOREIGN KEY (score_id) REFERENCES current_score (score_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `highscore` (
  `highscore_id` integer unsigned PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `username_ID` integer NOT NULL,
  `highscore` integer unsigned NOT NULL,
  `times_played` integer unsigned NOT NULL,
  CONSTRAINT highscore FOREIGN KEY (highscore_id) REFERENCES users (username_ID) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;