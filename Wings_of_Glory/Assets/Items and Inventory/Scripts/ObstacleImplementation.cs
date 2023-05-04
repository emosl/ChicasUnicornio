using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// //holaoooo

public class ObstacleImplementation : MonoBehaviour
{
    private TriggerValueAssigner triggerValueAssigner;
    public StatPanel statsPanel;
    public GameManagerToby gameManagerToby;
    public GameObject itemNotRemovedPanel;
    public GameObject itemRemovedPanel;
    public GameObject blank;
    public EquippableItem equippableItem;
    public Character character;
    public batteryplayer batteryPlayer;
    public TotalScore totalScore;
    

    public List<int> killerspritelist = new List<int>();

    [SerializeField] APITest api;

    //  public static int itemsRemoved;


    


    private void Start()
    {
        triggerValueAssigner = GetComponent<TriggerValueAssigner>();

         itemRemovedPanel.SetActive(false);
         itemNotRemovedPanel.SetActive(false);
         blank.SetActive(false);

          gameManagerToby = FindObjectOfType<GameManagerToby>();

          batteryPlayer = FindObjectOfType<batteryplayer>();
          totalScore = FindObjectOfType<TotalScore>();

         


    if (gameManagerToby == null)
    {
        Debug.LogError("GameManagerToby instance not found in the scene.");
    }
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("OnTriggerEnter called with other: " + other.name);
        Toby toby = other.GetComponent<Toby>();
        if (toby != null)
        {
            CheckPlayerStats(toby);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         Toby toby = other.GetComponent<Toby>();
        if (toby != null)
        {
            Hide();
        }

    }

    private void Hide()
    {
        itemRemovedPanel.SetActive(false);
        itemNotRemovedPanel.SetActive(false);
        blank.SetActive(false);
    }

    private void CheckPlayerStats(Toby toby)
    {

        switch (triggerValueAssigner.triggerTag)
        {
            case TriggerValueAssigner.TriggerTag.Ice:
                if (toby.agility < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Agility");
                    batteryPlayer.ChangeLife(20);
                    itemRemovedPanel.SetActive(true);  
                    KillerSpriteCounter("Ice");
            
                    
                }
                else
                {
                    // blank.SetActive(true);
                    itemNotRemovedPanel.SetActive(true);
                    KillerSpriteCounter("Ice");

                }
                break;

            case TriggerValueAssigner.TriggerTag.Bomb:
                if (toby.shield < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Shield");
                    batteryPlayer.ChangeLife(20);
                        itemRemovedPanel.SetActive(true);
                        KillerSpriteCounter("Shield");

                        
                }
                    else
                    {

                        itemNotRemovedPanel.SetActive(true);
                         totalScore.UpdateScore(10);
                        KillerSpriteCounter("Shield");
                    }
                
                break;

            case TriggerValueAssigner.TriggerTag.Water:
                if (toby.speed < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Speed");
                    batteryPlayer.ChangeLife(20);

                        itemRemovedPanel.SetActive(true);
                        KillerSpriteCounter("Water");
                       
                }
                    else
                    {
                        itemNotRemovedPanel.SetActive(true);
                        KillerSpriteCounter("Water");
                    }
                
                break;
            case TriggerValueAssigner.TriggerTag.Rock:
                if (toby.strength < triggerValueAssigner.requiredValue)
                {
                    toby.RemoveItem("Strength");
                    
                    batteryPlayer.ChangeLife(20);
                        itemRemovedPanel.SetActive(true);
                        KillerSpriteCounter("Rock");
                       
                }
                    else
                    {
                        // blank.SetActive(true);
                        itemNotRemovedPanel.SetActive(true);
                        KillerSpriteCounter("Rock");
                    }
                
                break;
        }
    }
    //This function stores the killersprite_id in a list for the API.
    //When the player accepts the challenge of a killersprite, the id is added to the list.
    public void KillerSpriteCounter(string killersprite)
    {
        Debug.Log(killersprite);
        if (killersprite == "Bomb")
        {
            killerspritelist.Add(131);
            api.UpdateKillSprite(131);
            Debug.Log("added "+killersprite);
        }
        else if (killersprite == "Water")
        {
            killerspritelist.Add(133);
            api.UpdateKillSprite(133);
            Debug.Log("added "+killersprite);
        }
        else if (killersprite == "Ice")
        {
            killerspritelist.Add(132);
            api.UpdateKillSprite(132);
            Debug.Log("added "+killersprite);
        }
        else if (killersprite == "Rock")
        {
            killerspritelist.Add(134);
            api.UpdateKillSprite(134);
            Debug.Log("added "+killersprite);
        }
        else{
            Debug.Log("Error in syntax could not add "+killersprite);
        }
    }
}