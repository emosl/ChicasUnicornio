"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'
import cors from 'cors'


const app = express()
const port = 8000


app.use(express.json())
app.use(express.static('./public'));
app.use(cors())


async function connectToDB()
{
    return await mysql.createConnection({host:'localhost', user:'unicorn01', password:'admin01', database:'chicasunicornio'})   
}

/////END POINTS FOR WEB
app.get('/', (request,response)=>{
    fs.readFile('./public/html/landing.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
    
})
app.get('/index.html', (request,response)=>{
    fs.readFile('./public/html/index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
    
})
app.get('/statistics.html', async (request, response) => {
    fs.readFile('./public/html/statistics.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
  });
  app.get('/usersManual.html', async (request, response) => {
    fs.readFile('./public/html/usersManual.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
  });
  app.get('/aboutus.html', async (request, response) => {
    fs.readFile('./public/html/aboutus.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
  });
  app.get('/register.html', async (request, response) => {
    fs.readFile('./public/html/register.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
  });
   app.get('/Game', async (request, response) => {
    fs.readFile('./public/WingsOfGlory/index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
  });


////BASE DE DATOS
// GET REQUESTS
app.get('/api/users', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from users')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/users/:id', async (request, response)=>
{
    let connection = null
    try
    {
        connection = await connectToDB()

        const [results, fields] = await connection.query('select * from users where username_ID= ?', [request.params.id])
        

        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/gadgets', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from gadget_name_count_view')

        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//gadgets - post (id_gadgets), killersprite - post(id_ks -> ks_inventory)
//gamehistory - get (userID,shield,scoreID)
//shield - post (shieldif -> game history))
//scoreID - post (scoreID -> game history) scoreID viene de FINAL SCORE 

// DUDITA OCTAVIO -> GADGET INVEMTORY 
app.get('/api/Gadget_inventory', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from Gadget_inventory')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/killer_sprites', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from killer_sprites')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/killerspriteinventory', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from killerspriteinventory')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
// Tengi que borrar los get point que tienen vistas?
app.get('/api/final_score', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from final_score')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/shields', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from shields')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/checkpoint', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from checkpoint')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/api/game_history', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from game_history')

        
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
// POST REQUESTS
app.post('/api/users/:id', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into users set ?', request.body)
        
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.post('/api/register', async (request, response) => {

    let connection = null;

    try {
        connection = await connectToDB();

        const { password, name, last_name, email } = request.body;

        if (!password || !name || !last_name || !email) {
            response.status(400);
            response.json({ 'message': 'All fields are required.' });
            return;
        }

        const insertQuery = 'INSERT INTO `chicasunicornio`.`users` (`password`, `name`, `last_name`, `email`) VALUES (?, ?, ?, ?)';
        const [results, fields] = await connection.query(insertQuery, [password, name, last_name, email]);

        response.json({ 'message': "Data inserted correctly." });
    }
    catch (error) {
        response.status(500);
        response.json(error);
        console.log(error);
    }
    finally {
        if (connection !== null) {
            connection.end();
            console.log("Connection closed succesfully!");
        }
    }
});

app.post('/api/gameinventory', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into gameinventory set ?', request.body)
        
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.post('/api/game_history', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into game_history set ?', request.body)
        
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
 })
 // PUT REQUESTS
app.put('/api/users', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()

        const [results, fields] = await connection.query('update users set name = ?, surname = ? where id_users= ?', [request.body['name'], request.body['surname'], request.body['userID']])
        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.put('/api/', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()

        const [results, fields] = await connection.query('update users set name = ?, surname = ? where id_users= ?', [request.body['name'], request.body['surname'], request.body['userID']])
        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.put('/api/save_data', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        console.log(request.body)
        const [results, fields] = await connection.query('update final_score set total_score = ? where username_ID = ?', [request.body['total_score'], request.body['username_ID']])
        const [results02, fields02] = await connection.query('update game_history set times_played = ? where username_ID = ?', [request.body['times_played'], request.body['username_ID']])
        // const [results03, fields03] = await connection.query('insert gadgetinventory set  = ? where username_ID = ?', [request.body['gadgetid'], request.body['username_ID']])
        const [results03, fields03] = await connection.query('update final_score set score_agility = ? where username_ID = ?', [request.body['score_agility'], request.body['username_ID']])
        // const [results04, fields04] = await connection.query('update gadgetinventory set gadgetid = ?', [request.body['gadgetid']])
        const [results04, fields04] = await connection.query('update final_score set score_speed = ? where username_ID = ?', [request.body['score_speed'], request.body['username_ID']])
        const [results05, fields05] = await connection.query('update final_score set score_strength = ? where username_ID = ?', [request.body['score_strength'], request.body['username_ID']])
        const [results06, fields06] = await connection.query('update final_score set score_shield = ? where username_ID = ?', [request.body['score_shield'], request.body['username_ID']])


        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


app.post('/api/save_gadget', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        console.log(request.body)
        const [results, fields] = await connection.query('insert into gadgetinventory set gadgetid = ?', [request.body['gadgetid']])


        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


app.post('/api/save_kill', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        console.log(request.body)
        const [results, fields] = await connection.query('insert into killerspriteinventory set killersprite_Id = ?', [request.body['killersprite_Id']])


        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



// VIEWS
app.get('/api/highscores_users', async (request, response)=>{
    let connection = await connectToDB()

    try{

        const[results, fields] = await connection.query('select * from high_scores_users')

        response.json(results)

        connection.end()
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
})
app.get('/api/mostplayed_users', async (request, response)=>{
    let connection = await connectToDB()

    try{

        const[results, fields] = await connection.query('select * from mostplayed_users')

        response.json(results)

        connection.end()
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
})
app.get('/api/gadget_count_view', async (request, response)=>{
    let connection = await connectToDB()

    try{

        const[results, fields] = await connection.query('select * from gadget_name_count_view')

        response.json(results)

        connection.end()
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
})
app.get('/api/killersprite_count_view', async (request, response)=>{
    let connection = await connectToDB()

    try{

        const[results, fields] = await connection.query('select * from killersprite_name_count_view')

        response.json(results)

        connection.end()
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
})
// IDEA
app.get('/api/highscoresusers', async (request, response)=>{
    let connection = await connectToDB()

    try{

        const[results, fields] = await connection.query('select * from  highscoresuser')

        response.json(results)

        connection.end()
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
})



app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})



///UNITY
app.get('/api/user', async (request, response) => {
    let connection = await connectToDB()
    try
    {
        const { usernameID } = request.query;
        const [results, fields] = await connection.execute('SELECT name FROM `users` WHERE `username_ID` = ?', [usernameID]);

        console.log(results[0])
        response.json(results[0])
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }

});

app.get('/api/timesplayed', async (request, response) => {
    let connection = await connectToDB()
    try
    {
        const { usernameID } = request.query;
        const [results, fields] = await connection.execute('SELECT times_played FROM `game_history` WHERE `username_ID` = ?', [usernameID]);

        console.log(results[0])
        response.json(results[0])
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }

});

app.get('/api/save_data', async (request, response)=>{

    let connection = await connectToDB()

    try{
        const { usernameID } = request.query;
        const [result1] = await connection.query('SELECT total_score FROM `final_score` WHERE `username_ID` = ?', [usernameID]);
        const [result2] = await connection.query('SELECT times_played FROM `game_history` WHERE `username_ID` = ?', [usernameID]);
        const [result3] = await connection.query('SELECT score_agility FROM `final_score` WHERE `username_ID` = ?', [usernameID]);
        const [result4] = await connection.query('SELECT score_speed FROM `final_score` WHERE `username_ID` = ?', [usernameID]);
        const [result5] = await connection.query('SELECT score_strength FROM `final_score` WHERE `username_ID` = ?', [usernameID]);
        const [result6] = await connection.query('SELECT score_shield FROM `final_score` WHERE `username_ID` = ?', [usernameID]);

        const data = {
          "username_ID": usernameID,
          "times_played": result2[0].times_played,
          "total_score": result1[0].total_score,
          "score_shield": result6[0].score_shield,
          "score_agility": result3[0].score_agility,
          "score_speed": result4[0].score_speed,
          "score_strength": result5[0].score_strength
        }

        response.json(data);
        
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
});

  


  