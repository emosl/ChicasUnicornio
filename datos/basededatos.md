# Base de datos
### Identificar que datos se guardaran en la base de datos

#### Gadgets (Estancia)
- gadget_Id (atributo, PK)(NOT NULL, AUTO_INCREMENT, SMALLINT)
- nombre (atributo)(NOT NULL, varchar(45))
<!-- - habilidad (atributo)(NOT NULL, varchar(45))
- puntos (atributo) (NOT NULL, SMALLINT) -->
- habilidad_speed (atributo)
- habilidad_strength (atributo)
- habilidad_agility (atributo)
- habilidad_shield (atributo)

#### Killer sprites (Estancia)
- killersprite_Id (atributo, PK) (NOT NULL, AUTO_INCREMENT, SMALLINT)
- nombre (atributo)(NOT NULL, varchar(45))
- habilidad (atributo)(NOT NULL, varchar(45))
- puntos (atributo) (NOT NULL, SMALLINT)

#### Shields (Estancia)
- shield_ID (atributo, PK)
- color (atributo)(NOT NULL, varchar(45))
- shield_ability
- strength_ability
- speed_ability
- agility_ability

#### Puntuaje Usuario (Estancia)
- registro (atributo PK)
- usuario_ID (atributo)
- habilidad_speed (atributo)
- habilidad_strength (atributo)
- habilidad_agility (atributo)
- habilidad_shield (atributo)

#### Usuario (Estancia)
- useraname (atributo PK) (NOT NULL, varchar(45))
- password (atributo) (NOT NULL, varchar(45))
- email (atributo) (NOT NULL, varchar(45))
- nombre (atributo) (NOT NULL, varchar(45))
- apellido (atributo) (NOT NULL, varchar(45))
- highscore (atributo) (NOT NULL, SMALLINT)
- times_played (atributo)(SMALLINT)

#### Losing register (Estancia)
- register_ID (atributo PK)
- username (atributo)
- loss_register (atributo)

#### User Inventory (Estancia)
- space_id (atributo PK)(NOT NULL AUTO_INCREMENT<=8)
- gadget_id (atributo)

#### Registro Game Time
- registro_id
- username
- game_time 



