// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Dungeon : MonoBehaviour
// {
//     public Transform target;
//     public Transform respawn;
//     public string sceneName;
//     public string sceneToLoad;
//     public GameObject player;  
//     // Start is called before the first frame update
    

//     // Update is called once per frame
    

//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player");
//     }    

//     void Update()
//     {
        
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("Triggered!");
//         if (other.CompareTag("Player") && other.gameObject.CompareTag("Dungeon"))
//         {
//             Debug.Log("Triggered!");
//             SceneManager.LoadScene(sceneName);
//         }
//     }

//     public void Scene()
//     {
//         SceneManager.LoadScene(sceneName);

//     }

//     public void RespwanD()
//     {
//         player.transform.position = respawn.position;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dungeon : MonoBehaviour

{
    public Transform target;
    public Transform respawn;
    public string sceneName;
    public string sceneToLoad;
    public GameObject player;
    private Vector3 lastPlayerPos; // variable to store player's last position

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPos = player.transform.position; // save player's initial position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.CompareTag("Dungeon"))
        {
            lastPlayerPos = player.transform.position; // save player's last position before loading scene
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Scene()
    {
        lastPlayerPos = player.transform.position; // save player's last position before loading scene
        SceneManager.LoadScene(sceneName);
    }

    public void RespawnD()
    {
        player.transform.position = respawn.position;
    }

    public void ReturnToLastPos()
    {
        player.transform.position = lastPlayerPos; // set player's position to last saved position
    }
}
