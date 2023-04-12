# Base de datos
### Identificar que datos se guardaran en la base de datos

#### Gadgets (Instance)
- gadget_Id (attribute, PK)(NOT NULL, AUTO_INCREMENT, SMALLINT)
- name (attribute)(NOT NULL, varchar(45))
- ability_speed (attribute)
- ability_strength (attribute)
- ability_agility (attribute)
- ability_shield (attribute)

#### Killer sprites (Instance)
- killersprite_Id (attribute, PK) (NOT NULL, AUTO_INCREMENT, SMALLINT)
- name (attribute)(NOT NULL, varchar(45))
- ability (attribute)(NOT NULL, varchar(45))
- point_consequence (attribute) (NOT NULL, SMALLINT)

#### Shields (Instance)
- shield_ID (attribute, PK)
- color (attribute)(NOT NULL, varchar(45))
- ability_speed (attribute)
- ability_strength (attribute)
- ability_agility (attribute)
- ability_shield (attribute)


#### Puntuaje Usuario (Instance)
- register_ID (atributo PK)
- username_ID (atributo)
- ability_speed (attribute)
- ability_strength (attribute)
- ability_agility (attribute)
- ability_shield (attribute)
- lives
- points

#### Usuario (Instance)
- username_ID (attribute PK) (NOT NULL, varchar(45))
- password (attribute) (NOT NULL, varchar(45))
- email (attribute) (NOT NULL, varchar(45))
- name (attribute) (NOT NULL, varchar(45))
- last_name (attribute) (NOT NULL, varchar(45))
- highscore (attribute) (NOT NULL, SMALLINT)
- times_played (attribute)(SMALLINT)

#### Losing register (Instance)
- register_ID (attribute PK)
- username (attribute)
- loss_register (attribute)

#### User Inventory (Estancia)
- space_id (attribute PK)(NOT NULL AUTO_INCREMENT<=8)
- gadget_id (attribute)

#### Register Game Time
- registro_id
- created_at
- checkpoint
- username
- game_time 

Table gadgets {
  gadget_ID "tiny unsigned integer" [NOT NULL, PK, increment] 
  name  "varchar(45)" [NOT NULL]
  ability_speed "tiny unsigned integer" [NOT NULL] 
  ability_strength "tiny unsigned integer" [NOT NULL]
  ability_agility "tiny unsigned integer" [NOT NULL]
  ability_shield "tiny unsigned integer" [NOT NULL]
}

Table inventory {
  inventory_id  "tiny unsigned integer" [pk, NOT NULL, increment] 
  gadget1_ID "tiny unsigned integer" [NOT NULL] 
  gadget2_ID "tiny unsigned integer" [NOT NULL] 
  gadget3_ID "tiny unsigned integer" [NOT NULL] 
  gadget4_ID "tiny unsigned integer" [NOT NULL] 
  gadget5_ID "tiny unsigned integer" [NOT NULL] 
  gadget6_ID "tiny unsigned integer" [NOT NULL] 
  gadget7_ID "tiny unsigned integer" [NOT NULL] 
  gadget8_ID "tiny unsigned integer" [NOT NULL] 
}

Table current_score{
  score_ID "tiny unsigned integer" [NOT NULL, PK, increment] 
  score_speed "tiny unsigned integer" [NOT NULL] 
  score_strength "tiny unsigned integer" [NOT NULL] 
  score_agility "tiny unsigned integer" [NOT NULL] 
  score_shield "tiny unsigned integer" [NOT NULL] 
}

Table killer_sprites{
  killersprite_Id  "tiny unsigned integer" [NOT NULL, PK, increment]
  name  "varchar(45)" [NOT NULL] 
  ability  "varchar(45)" [NOT NULL] 
  point_consequence  "SMALLINT" [NOT NULL] 
}

Table shields{
  shield_id "tiny unsigned integer" [NOT NULL, PK, increment]
  color "varchar(45)" [NOT NULL] 
  ability_speed "integer" [NOT NULL] 
  ability_strength "integer" [NOT NULL] 
  ability_agility "integer" [NOT NULL] 
  ability_shield "integer" [NOT NULL] 
}

Table game_assets{
  asset_id "unsigned integer" [Not null, pk]
  asset_type "varchar(45)" [NOT NULL]
}


Table game_history{
  register_ID integer [primary key, NOT NULL, increment]
  created_at "timestamp" [NOT NULL]
  username_ID "varchar(45)" [NOT NULL]
  shield_id "integer" [NOT NULL]
  inventory_id "integer" [NOT NULL]
  score_id "unsigned integer" [NOT NULL]
  lives "integer" [NOT NULL]
  score "integer" [NOT NULL]
  loss_reason "varchar(45)"
  
}

Table users {
  username_ID "varchar(45)" [pk, NOT NULL]
  password "varchar(45)" [NOT NULL]
  name "varchar(45)" [NOT NULL]
  last_name "varchar(45)" [NOT NULL]
  email "varchar(45)" [NOT NULL]
}

Table checkpoint{
  register_ID "unsigned integer" [pk, NOT NULL, increment]
  created_at "timestamp" [NOT NULL]
  checkpoint "unsigned integer" [NOT NULL]
  username_ID "varchar(45)" [NOT NULL]
  game_time "integer" [NOT NULL] //must display the time elapsed in the game
}

Table highscore{
  highscore_id "integer" [primary key, NOT NULL, increment]
  username_ID "varchar(45)" [NOT NULL]
  highscore "integer" [NOT NULL]
  times_played "integer" [NOT NULL]
}

Ref:checkpoint.register_ID < users.username_ID  
Ref: game_history.shield_id > shields.shield_id //checar esta relación
REf: game_history.username_ID > users.username_ID
REf: inventory.gadget1_ID < gadgets.gadget_ID
Ref: users.username_ID < highscore.highscore_id
Ref: game_history.inventory_id < inventory.inventory_id
Ref: current_score.score_ID < game_history.score_id
Ref: game_assets.asset_id < killer_sprites.killersprite_Id
Ref: game_assets.asset_id < shields.shield_id
Ref: game_assets.asset_id < gadgets.gadget_ID

