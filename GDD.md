# **Game Authors**
Arantza Parra Martínez A01782013

Emilia Salazar Leipen A01781931

Lucía Barrenechea A01782021

Maria Fernanda Cortés Lozano A01026613

Maria Fernanda Osorio Arroyo A01026502

# **Wings of Glory: The pegasus chronicles** 

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

##
## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
        1. Ambience
        2. Objects
            1. Ambient
            2. Interactive
        3. Challenges
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
    2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_
#### Elevator pitch
Toby is a pegasus that fell into the trap of an evil equine shapeshifter, one day he found a golden apple and decided to eat it. What he didn’t know was that this apple was part of the trap and it would make him fall from his magical pegasus world into the ordinary mule world. Join Toby on his quest to return to his family.
 
While on his quest Toby will face 5 different stages, the first being a mule. Navigating through the adventure he will have to collect valuable items, overcome obstacles, and play a strategic game in order to defeat the evil mule. If the player manages to win the battle, he will evolve into a donkey, starting a new quest with increased difficulty to defeat the evil donkey. This same gameplay will apply throughout each level, mule, donkey, horse, unicorn and pegasus, increasing the difficulty to overcome the obstacles, collect items and a need for strategy.  

#### Genero del juego
El género del juego es de aventura ya que el énfasis está en la narrativa en vez de elementos de acción. El jugador debe recolectar items, poderes especiales e interactuar con NPCs para avanzar en la historia.


### **RPG Elements**
The RPG elements that the game contains are the items that you must collect: food (apple, carrots), metals (gold and silver) and powers (speed and strength). Inside the dungeon you will find special items: chocolate cake, platinum and a life of gold (if the player is victorious in the dungeon and obtains this item, once he returns to the normal world he will have 20 seconds of immortality).
Another RPG element is the NPCs, we plan to have two, a magic flower and…

#### **Visual style of the game**
The visual style of the video game will be pixel art. The graphics of the video game will be built with pixels since it is a very basic form and that allows, with relatively few resources, very striking art. It also produces a retro and nostalgic look. 

**Video Game Sketches**
- main character: 

![Toby](/Toby.jpeg)

- logo:
![Logo](/Logo.png)

- sketch of main game scene:
![view](/gameView.jpeg)


## **References**

We have taken inspiration from different games, their functionalities and views.
![FireWater](/Fireboy%20and%20Watergirl%201%20OG%20Image.png)

This game is called *Fireboy and Watergirl in The Forest Temple*. From this game we have taken the different obstacles the user has to go through in order to reach the end of the level. 
Functionalities such as incentives to go through the obstacles were also taken into account.

![Pamplona](/extremepamplonac.avif)
From the game called *Extreme pamplona*, we took the idea of the enemy following the principal character as he overcomes  the obstacles. If the enemy catches him, he needs to start over. In our game, the player will lose one of their 3 lives.
The point of having the villan chase you, is that there is only one power that you can have to beat the other ( apart from the rest of the items) thus you will nedd / want to reach it first!

![Donkey](/DonkeyKong_TA.webp)
The game *Donkey Kong* inspired us for the type of visuals we wanted our game to have. Our characters, as the ones in donkey kong will be made with pixel art. 


### **Reglas y mecánicas básicas del juego**
Se encuentran en la parte de Mechanics.

### **Listado de estadísticas va a recopilar el juego dentro de la base de datos**
Databases will partake in our video game development. Data such as lives lost, prizes recollected, levels overcome and user data will be not only useful but necessary. 
 Creating and using a database will allow us to develop a fully functional system. This system must function using relative databases in order to avoid redundancy in the data or a superfluous amount of data that could be detrimental to the main functions of the database. 

In the game we will receive information that it is essential for the game to work. Since the outcome of our game is based on the accumulation of points, it is necessary to create a database that contains the points accumulated as well as important information. Some of the statistics that will be saved throughout the game are the following:
1. Player information.
2. Quantity and quality of the items collected throughout the game by the user.
3. The location of the player in the game.
4. Game history of the player.
5. Points accumulated by the player in each level and throughout the game.
6. The rules of the game: how to lose a life, how to earn points, etc.


### **Summary**

In this game, you play as Toby, a pegasus who fell for a trick and was transformed into a mule. To return to his family, Toby must fight through levels of different transformations, collect items, and defeat enemies using weapons and shields. The game has a single-player, sideways view, and features five levels of increasing difficulty.

### **Gameplay**

- The goal of the game is for Toby, the protagonist, to make his way back to his family of pegasus; starting from a mule. In order to do this he must navigate through five different levels and defeat an enemy at the end of each. If he succeeds, he will evolve into a new character as he levels up. He must  transform from a mule to a donkey, to a horse, to a unicorn, and finally to a pegasus all while being chased by his enemies. While navigating through each level, the player must collect items such as gems, fruit and weapons, as well as overcome obstacles such as spikes, lava and pools of poison, in order to gather enough materials to eventually defeat the enemy. The player must create a strategy to succesfully use the items collected and the path taken to achieve the most points at the end of the level, in order to be ranked as a top pegasus. 

- There will be a dungeon on each level where the player can obtain special items that will increase their chance at defeating the enemy. The player can decide if they go in or not. If the player loses in the dungeon, they will lose the items they had previously collected and they will be sent back to a checkpoint in the normal world. The player should also be strategic in their use of Toby's limited lives and resources to ensure they make it through all five levels.
The items play a crucial role in the game since the combination of said items can improve the possibilities for the player to defeat the enemy. If the player is not strategic with the combination he made, he will lose the fight against the enemy.  
Another factor that the player should be cautious about is the pace they keep while going through the level because they will always have an enemy on their backs. If the enemy catches up with them, they lose a life. 
At the final step of the game, Toby will have to confront his enemy. He will be faced with a fight that he can only win if he collected enough valuable gadgets. In order for Toby to win the fight he must be strong enough.to achieve this he must collect points throughout the level. 



 
### **Mindset**

What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?
- The mindset we want to create for the players is for them to have a sense of need to reunite Toby with his family. As they level up and unlock new features, we want them to feel like they are becoming stronger and more capable of overcoming challenges. As the player increases the level, we want to challenge them with tough enemies and obstacles that will require them to think carefully about their tactics and strategies. We also want them to feel rushed and excited while navigating each level. To evoke these emotions, we have the enemy following them around while they try to pass each level.  Overall, the goal is to create a game that is engaging and immersive, that will make the player want to keep coming back for more. Always keeping the game balanced between the sense of achievement and the need to win challenges.

## _Technical_

---

### **Screens**

1. Title Screen
    1. Options
2. Level Select
3. Game
    1. Inventory
    2. Assessment / Next Level
4. End Credits

_(example)_

### **Controls**

How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)
- The player will interact with the game using standard platformer controls, such as moving left and right, jumping, tapping, and attacking. In-game events can be triggered by the player through various actions such as attacking enemies, collecting items, and reaching specific points in the level. Additionally, the player may have to solve puzzles to progress through the game, which would require interacting with the environment and manipulating objects in various ways.

### **Mechanics**

Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.
- 
While playing the game, the player will be ranked on a point basis, each battle winned will increase their points as well as each life lost and the way it was lost will decrease points. When reaching the final stage of the quest and becoming the pegasus, Toby will evolve into one of the five ranks of pegasus, depending the points accumulated by the player, making the game scalable and leaving the player with the need to keep playing and changing their strategy each time in order to play a perfect game and become the Supreme Pegasus. 
The main objective of the game is for Toby to eventually reach his family. To do this he must travel through 5 different worlds (levels). At the end of each level Toby will have to fight his enemy. To do this he will have to use the gadgets collected throughout the level. Toby's enemy will be chasing the player throughout the game ensuring that the player feels pressured to move along and finish the course. The player will have 3 lives throughout each level. If the player loses them all it’s game over.

### The Gadgets
To have a greater chance, as Toby goes  through the course he will collect different gadgets that will make him stronger in the final battle. Some gadgets will be used throughout the game since they will help Toby collect even better gadgets. In order to get the best gadgets, the player will have the choice to access “the dungeon”. 

### Killer Sprites
As Toby traverses through each level he will face threats such as spikes, acid pool and lava pool. If the player touches any of these, he will die. He will reappear next to the killer sprite with his gadgets intact but with one less life.

### The Dungeon
In the dungeon better gadgets will exist. Inside the dungeon, Toby will be chased by smaller enemies in a maze setting. If he is caught, he will lose his life. There is one thing that the player must take into consideration, if he loses a life inside the dungeon, he will also lose all of the gadgets he has collected. Each dungeon can only be accessed once by the player.

### How to Lose a Life
It is important that the player understands that they have 3 lives through each level. if they lose all 3, they will start from the beginning with nothing.
    There are 4 possibilities for the player to lose a life in the game. These are the following:
1. If you touch a killer sprite you will die. The player will reappear next to the killer sprite with one less life but with his gadgets intact.
2. If you get caught inside the dungeon, you will lose a life and you will lose all of the gadgets collected. The player will reappear next to the dungeon.
3. If you get caught by Toby’s enemy at any point throughout the game you will lose a life and you will appear at the beginning of the obstacle course with your gadgets intact.
4. If you don’t have the necessary gadgets to beat Toby's enemy at the final stage of the game, you will lose a life and the gadgets you used trying to win. If you have extra lives and extra gadgets, you can fight once again.   

### The Final Battle
The final battle is the most important aspect of the game. Here, Toby will confront his enemy in an epic battle. He will have to put to use all of the gadgets that he collected along the level as well as his strategies. Toby will have to create gadget combinations that will uncover the enemies weakness. The player will have hints of the enemies weakness in the level.



## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
    1. Mood
        1. Dark, calm, foreboding
  2. Objects
        1. _Ambient_
            1. Fireflies
            2. Beams of moonlight
            3. Tall grass
        2. _Interactive_
            1. Wolves
            2. Goblins
            3. Rocks
2. Castle
    1. Mood
        1. Dangerous, tense, active
    2. Objects
        1. _Ambient_
            1. Rodents
            2. Torches
            3. Suits of armor
        2. _Interactive_
            1. Guards
            2. Giant rats
            3. Chests

2. Rainbow sky
    1. Mood
        1. tricky, fun, fast
    2. Objects
        1. _Ambient_
            1. 
            2. 
            3. 
        2. _Interactive_
            1. 
            2. 
            3. 

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseEnemy
    3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_

### **Derived Classes / Component Compositions**

1. BasePlayer
    1. PlayerMain
    2. PlayerUnlockable
2. BaseEnemy
    1. EnemyWolf
    2. EnemyGoblin
    3. EnemyGuard (may drop key)
    4. EnemyGiantRat
    5. EnemyPrisoner
3. BaseObject
    1. ObjectRock (pick-up-able, throwable)
    2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
    3. ObjectGoldCoin (cha-ching!)
    4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
    1. ObstacleWindow (destroyed with rock)
    2. ObstacleWall
    3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
    1. InteractableButton

_(example)_

## _Graphics_

---

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
    1. Human-like
        1. Goblin (idle, walking, throwing)
        2. Guard (idle, walking, stabbing)
        3. Prisoner (walking, running)
    2. Other
        1. Wolf (idle, walking, running)
        2. Giant Rat (idle, scurrying)
2. Blocks
    1. Dirt
    2. Dirt/Grass
    3. Stone Block
    4. Stone Bricks
    5. Tiled Floor
    6. Weathered Stone Block
    7. Weathered Stone Bricks
3. Ambient
    1. Tall Grass
    2. Rodent (idle, scurrying)
    3. Torch
    4. Armored Suit
    5. Chains (matching Weathered Stone Bricks)
    6. Blood stains (matching Weathered Stone Bricks)
4. Other
    1. Chest
    2. Door (matching Stone Bricks)
    3. Gate
    4. Button (matching Weathered Stone Bricks)

_(example)_


## _Sounds/Music_

---

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

 Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

### **Sounds Needed**

1. Effects
    1. Soft Footsteps (dirt floor)
    2. Sharper Footsteps (stone floor)
    3. Soft Landing (low vertical velocity)
    4. Hard Landing (high vertical velocity)
    5. Glass Breaking
    6. Chest Opening
    7. Door Opening
2. Feedback
    1. Relieved &quot;Ahhhh!&quot; (health)
    2. Shocked &quot;Ooomph!&quot; (attacked)
    3. Happy chime (extra life)
    4. Sad chime (died)

_(example)_

### **Music Needed**

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

_(example)_


## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
    1. base entity
        1. base player
        2. base enemy
        3. base block
  2. base app state
        1. game world
        2. menu world
2. develop player and basic block classes
    1. physics / collisions
3. find some smooth controls/physics
4. develop other derived classes
    1. blocks
        1. moving
        2. falling
        3. breaking
        4. cloud
    2. enemies
        1. soldier
        2. rat
        3. etc.
5. design levels
    1. introduce motion/jumping
    2. introduce throwing
    3. mind the pacing, let the player play between lessons
6. design sounds
7. design music

_(example)_

# Requirements
Requerimientos Funcionales (Críticos para el buen funcionamiento del sistema)

**Base De Datos

Establecer prioridades para realizar el proyecto
Creación de Base de datos
Creación de llaves primarias en la base de datos.
Identificar qué datos se guardarán en la base (info personajes, info niveles, estructuras primitivas, gadgets)
Crear el modelo de datos a partir de un diagrama entidad relación uml.(cada columna e información que guardar)

**Videogame**

Instalar unity de manera funcional en todos los equipos
Creacion de sprites de los personajes principales en Unix
Definición de mecánicas del juego
Creación de bocetos del videojuego (pantalla principal, dungeon, etc)
Crear 4 sprite del jugador principal. Implica el monito en movimiento y su funcionalidad
Determinar sprites reusables o modificables.
Crear ambiente del juego a través de sprites usables. (buscarlos)
Diseñar los NPC (non player characters).
Crear la interacción entre los NPC
Crear mecánica de movilidad.
Inserción de sonidos de ambiente en el juego, (encontrarlo, asociarlo a acción)
Crear un midy adecuado a cierta mecánica del juego
reutilizar un midi para cierta mecánica del juego.
Crear mecánica de combate del personaje
Creación de controles del juego

**WEB**
Crear pantalla principal con login y que se conecte con la base de datos.
embeber juego con pagina web
Configurar el servidor que va a alojar la página web.
Aprender a usar javascript, unity
usar bootstrap para implementarlo en la página web y reducir el tiempo de diseño.

Requerimientos No Funcionales
Establecer colores y diseño
Agregar manual de usuario
Determinar fuente de texto
Creación de un usuario
Creación de cosas extras.
Crear una tabla que guarde el log de todo lo sucedido en el juego
