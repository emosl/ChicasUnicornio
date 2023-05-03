// using UnityEngine;

// public class TobyController : MonoBehaviour
// {
//     [SerializeField] private ItemPickupPanel itemPickupPanel;
//     [SerializeField] private gadgets gadget;

//     void Start()
//     {
//         // Subscribe to the onItemPickedUp event in the gadgets script
//         gadget.onItemPickedUp.AddListener(ShowItemPickupPanel);
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe from the onItemPickedUp event when the object is destroyed
//         gadget.onItemPickedUp.RemoveListener(ShowItemPickupPanel);
//     }

//     private void ShowItemPickupPanel()
//     {
//         // Call the UpdatePanel() function in ItemPickupPanel script with the equippable item
//         itemPickupPanel.UpdatePanel(gadget.equippableItem);
//     }
// }
