/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
function random_color(alpha=1.0)
{
    const r_c = () => Math.round(Math.random() * 255)
    return `rgba(${r_c()}, ${r_c()}, ${r_c()}, ${alpha}`;
}

Chart.defaults.font.size = 16;
// GRAFICA HIGHEST SCORES
try
{
    const highscores_response = await fetch('http://127.0.1:8000/api/highscores',{
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
        const highscores_unsername_ID = values.map(e => e['username_ID'])
        const highscores_colors = values.map(e => random_color(0.8))
        const highscores_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const highscores_total_score = values.map(e => e['total_score'])

        const ctx_highscores = document.getElementById('highscores').getContext('2d');
        const levelhighscores = new Chart(ctx_highscores,
            {
                type: 'bar',
                data: {
                    labels: highscores_unsername_ID,
                    datasets: [
                        {
                            label: 'Users_Score',
                            backgroundColor: highscores_colors,
                            borderColor: highscores_borders,
                            borderWidth: 2,
                            data: highscores_total_score
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
// GRAFICA MOST PLAYED
try
{
    const highscores_response = await fetch('http://127.0.1:8000/api/mostplayed',{
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
        const mostplayed_unsername_ID = values.map(e => e['username_ID'])
        const mostplayed_colors = values.map(e => random_color(0.8))
        const mostplayed_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const mostplayed_total_score = values.map(e => e['times_played'])

        const ctx_mostplayed = document.getElementById('mostplayed').getContext('2d');
        const levelmostplayed = new Chart(ctx_mostplayed,
            {
                type: 'bar',
                data: {
                    labels: mostplayed_unsername_ID,
                    datasets: [
                        {
                            label: 'times_played',
                            backgroundColor: mostplayed_colors,
                            borderColor: mostplayed_borders,
                            borderWidth: 2,
                            data: mostplayed_total_score
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
        const fav_gadgets_ID = values.map(e => e['gadgetid'])
        const fav_gadgets_colors = values.map(e => random_color(0.8))
        const fav_gadgets_borders = values.map(e => 'rgba(0, 0, 0, 1.0)')
        const fav_gadgets_score = values.map(e => e['gadget_count'])

        const ctx_fav_gadgets = document.getElementById('fav_gadgets').getContext('2d');
        const fav_gadgets = new Chart(ctx_fav_gadgets,
            {
                type: 'bar',
                data: {
                    labels: fav_gadgets_ID,
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

