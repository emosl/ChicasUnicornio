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

