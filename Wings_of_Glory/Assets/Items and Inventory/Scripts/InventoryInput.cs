using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject characterPanelGameObject;
    [SerializeField] KeyCode[] toggleCharacterPanelKeys;

    void Start()
    {
        characterPanelGameObject.SetActive(false);

    }


    void Update()
    {
        for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
            {
                characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

                if (characterPanelGameObject.activeSelf)
                {
                    characterPanelGameObject.SetActive(true);
                   
                }
                else
                    
                break; // so we don't open and close more than once if we accidentally press again 
            }
        }

    }



}