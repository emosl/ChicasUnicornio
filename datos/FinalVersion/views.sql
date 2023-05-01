
USE chicasunicornio;
CREATE VIEW  high_scores_users AS SELECT x.name, y.total_score FROM chicasunicornio.users as x INNER JOIN chicasunicornio.final_score as y
ON x.username_ID = y.username_ID ORDER BY y.total_score DESC LIMIT 5;

CREATE VIEW mostplayed_users AS SELECT x.name, y.times_played FROM chicasunicornio.users as x INNER JOIN chicasunicornio.game_history as y
ON x.username_ID = y.username_ID ORDER BY y.times_played DESC LIMIT 6;

CREATE VIEW gadget_name_count_view AS
SELECT chicasunicornio.gadgets.gadgetname, COUNT(gadgetid) AS gadget_count
FROM chicasunicornio.gadgetinventory
JOIN chicasunicornio.gadgets ON chicasunicornio.gadgetinventory.gadgetid = chicasunicornio.gadgets.gadget_ID
GROUP BY gadgetid
ORDER BY gadget_count DESC LIMIT 5;

CREATE VIEW killersprite_name_count_view AS
SELECT chicasunicornio.killer_sprites.name, COUNT(chicasunicornio.killerspriteinventory.killersprite_Id) AS killersprite_count
FROM chicasunicornio.killerspriteinventory
JOIN chicasunicornio.killer_sprites ON chicasunicornio.killerspriteinventory.killersprite_Id = chicasunicornio.killer_sprites.killersprite_Id
GROUP BY chicasunicornio.killerspriteinventory.killersprite_Id
ORDER BY killersprite_count DESC LIMIT 5;


SELECT * FROM high_scores_users;
SELECT * FROM mostplayed_users;
SELECT * FROM gadget_name_count_view;
SELECT * FROM killersprite_name_count_view;
