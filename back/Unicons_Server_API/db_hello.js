"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5000

app.use(express.json())
app.use(express.static('./public'));

async function connectToDB()
{
    return await mysql.createConnection({
        host:'localhost',
        user:'chica_unicornio',
        password:'admin1',
        database:'chicasunicornio'
    })
}

app.get('/', (request,response)=>{
    fs.readFile('./public/html/db_use_cases.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
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
app.get('/api/game_assets', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from game_assets')

        
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
app.get('/api/current_score', async (request, response)=>{
    let connection = null
    
    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from current_score')

        
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
// app.post('/api/gameinventory', async (request, response)=>{

//     let connection = null

//     try
//     {    
//         connection = await connectToDB()

//         const [results, fields] = await connection.query('insert into gameinventory set ?', request.body)
        
//         response.json({'message': "Data inserted correctly."})
//     }
//     catch(error)
//     {
//         response.status(500)
//         response.json(error)
//         console.log(error)
//     }
//     finally
//     {
//         if(connection!==null) 
//         {
//             connection.end()
//             console.log("Connection closed succesfully!")
//         }
//     }
// })
// app.post('/api/game_history', async (request, response)=>{

//     let connection = null

//     try
//     {    
//         connection = await connectToDB()

//         const [results, fields] = await connection.query('insert into game_history set ?', request.body)
        
//         response.json({'message': "Data inserted correctly."})
//     }
//     catch(error)
//     {
//         response.status(500)
//         response.json(error)
//         console.log(error)
//     }
//     finally
//     {
//         if(connection!==null) 
//         {
//             connection.end()
//             console.log("Connection closed succesfully!")
//         }
//     }
// })
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

// app.delete('/api/users/:id', async (request, response)=>{

//     let connection = null

//     try
//     {
//         connection = await connectToDB()

//         const [results, fields] = await connection.query('delete from users where id_users= ?', [request.params.id])
        
//         response.json({'message': "Data deleted correctly."})
//     }
//     catch(error)
//     {
//         response.status(500)
//         response.json(error)
//         console.log(error)
//     }
//     finally
//     {
//         if(connection!==null) 
//         {
//             connection.end()
//             console.log("Connection closed succesfully!")
//         }
//     }
// })

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})