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
                    ShowMouseCursor();
                }
                else
                    HideMouseCursor();
                break; // so we don't open and close more than once if we accidentally press again 
            }
        }

    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // allows mouse to move freely
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor to centre game view
    }


}