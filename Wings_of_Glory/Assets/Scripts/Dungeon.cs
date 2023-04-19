using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public Transform target;
    public string sceneName;
    public string sceneToLoad;

    void Update()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // if (player.transform.position == target.position)
        // {
        //     Debug.Log("Scene loaded");
        //     // SceneManager.LoadScene(sceneName);
        //     UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
        //     Debug.Log("Scene loaded");
        // }
        // if (player != null && Vector3.Distance(player.transform.position, target.position) < 0.1f)
        // {
        //     Debug.Log("Player reached the target position.");
        //     // show the canvas and ask the user whether or not to change scene
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        if (other.CompareTag("Player") && other.gameObject.CompareTag("Dungeon"))
        {
            Debug.Log("Triggered!");
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Scene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
