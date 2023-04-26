
USE chicasunicornio;
CREATE VIEW  highscores AS SELECT x.username_ID, y.total_score FROM chicasunicornio.users as x INNER JOIN chicasunicornio.final_score as y
ON x.username_ID = y.username_ID ORDER BY y.total_score DESC LIMIT 5;

CREATE VIEW mostplayed AS SELECT x.username_ID, y.times_played FROM chicasunicornio.users as x INNER JOIN chicasunicornio.game_history as y
ON x.username_ID = y.username_ID ORDER BY y.times_played DESC LIMIT 6;

CREATE VIEW gadget_count_view AS
SELECT chicasunicornio.gadgetinventory.gadgetid, COUNT(gadgetid) AS gadget_count
FROM chicasunicornio.gadgetinventory
GROUP BY gadgetid;

CREATE VIEW killersprite_count_view AS
SELECT chicasunicornio.killerspriteinventory.killersprite_Id, COUNT(killersprite_Id) AS killersprite_count
FROM chicasunicornio.killerspriteinventory
GROUP BY killersprite_Id;

SELECT * FROM highscores;
SELECT * FROM mostplayed;
SELECT * FROM gadget_count_view;
SELECT * FROM killersprite_count_view;




