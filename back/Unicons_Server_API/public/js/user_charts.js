/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
function random_color(alpha=1.0)
{
    const hex_colors = ["#AF1B3F", "#29274C", "#656256", "#D295BF", "#E6BCCD","#C8C6AF","#BB6B00","#EF8354","#759FBC","#6E9887","#5D5F71","#721121"]; 
    const random_hex = hex_colors[Math.floor(Math.random() * hex_colors.length)];
    const r = parseInt(random_hex.slice(1, 3), 16);
    const g = parseInt(random_hex.slice(3, 5), 16);
    const b = parseInt(random_hex.slice(5, 7), 16);
    return `rgba(${r}, ${g}, ${b}, ${alpha})`;
}

Chart.defaults.font.size = 20;
// GRAFICA HIGHEST SCORES
try
{
    const highscores_response = await fetch('http://127.0.1:8000/api/highscores_users',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(highscores_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await highscores_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const highscores_unsername = values.map(e => e['name'])
        const highscores_colors = values.map(e => random_color(0.8))
        const highscores_borders = values.map(e => 'rgba(255,255,255,1.0)')
        const highscores_total_score = values.map(e => e['total_score'])

        const ctx_highscores = document.getElementById('highscores').getContext('2d');
        const levelhighscores = new Chart(ctx_highscores,
            {
                type: 'bar',
                data: {
                    labels: highscores_unsername,
                    datasets: [
                        {
                            label: 'Users_Score',
                            backgroundColor: highscores_colors,
                            borderColor: highscores_borders,
                            borderWidth: 2,
                            data: highscores_total_score
                        }
                    ]
                },
                options:{
                    scales:{
                        x:{
                            title:{
                                display: true,
                                text: "Username"
                            }
                        },
                        y:{
                            title:{
                                display:true,
                                text:"Total Score"
                            }
                        }
                    }
                }
            });
         }
    }
catch(error)
{
    console.log(error)
}
// GRAFICA MOST PLAYED
try
{
    const mostplayed_response = await fetch('http://127.0.1:8000/api/mostplayed_users',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(mostplayed_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await mostplayed_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const mostplayed_unsername = values.map(e => e['name'])
        const mostplayed_colors = values.map(e => random_color(0.8))
        const mostplayed_borders = values.map(e => 'rgba(255,255,255,1.0)')
        const mostplayed_total_score = values.map(e => e['times_played'])

        const ctx_mostplayed = document.getElementById('mostplayed_users').getContext('2d');
        const mostplayed = new Chart(ctx_mostplayed,
            {
                type: 'bar',
                data: {
                    labels: mostplayed_unsername,
                    datasets: [
                        {
                            label: 'times_played',
                            backgroundColor: mostplayed_colors,
                            borderColor: mostplayed_borders,
                            borderWidth: 2,
                            data: mostplayed_total_score
                        }
                    ]
                },
                options:{
                    scales:{
                        x:{
                            title:{
                                display: true,
                                text: "Username"
                            }
                        },
                        y:{
                            title:{
                                display:true,
                                text:"Total Score"
                            }
                        }
                    }
                }
            });
         }
    }
catch(error)
{
    console.log(error)
}
// GRAFICA FAVORITE GADGET
try
{
    const fav_gadgets_response = await fetch('http://127.0.1:8000/api/gadget_count_view',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(fav_gadgets_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await fav_gadgets_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const fav_gadgets_name = values.map(e => e['gadgetname'])
        const fav_gadgets_colors = values.map(e => random_color(0.8))
        const fav_gadgets_borders = values.map(e => 'rgba(255,255,255,1.0)')
        const fav_gadgets_score = values.map(e => e['gadget_count'])

        const ctx_fav_gadgets = document.getElementById('fav_gadgets').getContext('2d');
        const fav_gadgets = new Chart(ctx_fav_gadgets,
            {
                type: 'pie',
                data: {
                    labels: fav_gadgets_name,
                    datasets: [
                        {
                            label: 'times_chosen',
                            backgroundColor: fav_gadgets_colors,
                            borderColor: fav_gadgets_borders,
                            borderWidth: 2,
                            data: fav_gadgets_score
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}
// GRAFICA favorite killersprite
try
{
    const fav_killersprite_response = await fetch('http://127.0.1:8000/api/killersprite_count_view',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(fav_killersprite_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await fav_killersprite_response.json()

        console.log(results)
        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const fav_killersprite_name = values.map(e => e['name'])
        const fav_killersprite_colors = values.map(e => random_color(0.8))
        const fav_killersprite_borders = values.map(e => 'rgba(255,255,255,1.0)')
        const fav_killersprite_score = values.map(e => e['killersprite_count'])

        const ctx_fav_killersprite = document.getElementById('fav_killersprite').getContext('2d');
        const fav_killersprite = new Chart(ctx_fav_killersprite,
            {
                type: 'pie',
                data: {
                    labels: fav_killersprite_name,
                    datasets: [
                        {
                            label: 'times_chosen',
                            backgroundColor: fav_killersprite_colors,
                            borderColor: fav_killersprite_borders,
                            borderWidth: 2,
                            data: fav_killersprite_score
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}
