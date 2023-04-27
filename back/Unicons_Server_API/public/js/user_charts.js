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
// To plot data from an API, we first need to fetch a request, and then process the data.
async function fetchData() {
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
                            label: 'Highscores',
                            backgroundColor: highscores_colors,
                            borderColor: highscores_borders,
                            borderWidth: 2,
                            data: highscores_total_score
                        }
                    ]
                }
            })

        // const ctx_levels2 = document.getElementById('apiChart2').getContext('2d');
        // const levelChart2 = new Chart(ctx_levels2, 
        //     {
        //         type: 'line',
        //         data: {
        //             labels: level_names,
        //             datasets: [
        //                 {
        //                     label: 'Completion Rate',
        //                     backgroundColor: level_colors,
        //                     pointRadius: 10,
        //                     data: level_completion
        //                 }
        //             ]
        //         }
        //     })
        
        // const ctx_levels3 = document.getElementById('apiChart3').getContext('2d');
        // const levelChart3 = new Chart(ctx_levels3, 
        //     {
        //         type: 'bar',
        //         data: {
        //             labels: level_names,
        //             datasets: [
        //                 {
        //                     label: 'Completion Rate',
        //                     backgroundColor: level_colors,
        //                     borderColor: level_borders,
        //                     borderWidth: 2,
        //                     data: level_completion
        //                 }
        //             ]
        //         }
        //     })
    }
}
catch(error)
{
    console.log(error)
}
}
fetchData();