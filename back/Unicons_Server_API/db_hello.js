"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 8000


import path from 'path';
import { fileURLToPath } from 'url';

const __dirname = path.dirname(fileURLToPath(import.meta.url));

app.use(express.json())
app.use(express.static('./public'));

function connectToDB()
{
    return mysql.createConnection({host:'localhost', user:'unicorn01', password:'admin01', database:'chicasunicornio'})   
}
// async function connectToDB()
// {
//     return await mysql.createConnection({
//         host:'localhost',
//         user:'unicorn01',
//         password:'admin01',
//         database:'chicasunicornio'
//     })
// }

/////END POINTS FOR WEB
app.get('/statistics.html', async (request, response) => {
    fs.readFile('../statistics.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
    // try {
    //   const htmlPath = path.join(__dirname, '..','..', 'statistics.html'); // Change 'path/to/file.html' to the actual path of the HTML file you want to read
    //   const html = fs.readFileSync(htmlPath, 'utf-8'); // Read the contents of the HTML file
  
    //   response.send(html);
    // } catch (error) {
    //   response.status(500).send(error);
    //   console.log(error);
    // }
  });

app.get('/', (request,response)=>{
    fs.readFile('./public/html/index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
    // fs.readFile('../assets/images/principal.mp4', 'utf8', (err, html)=>{
    //     if(err) response.status(500).send('There was an error: ' + err)
    //     console.log('Loading page...')
    //     response.send(html)
    // })
    
})
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
        const [results, fields] = await connection.execute('select * from gadgets')

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
app.get('/api/gameinventory', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from gameinventory')

         
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
app.get('/api/highscores', (request, response)=>{
    let connection = connectToDB()

    try{

        connection.connect()

        connection.query('select * from highscores', (error, results, fields)=>{
            if(error) console.log(error)
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        })

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