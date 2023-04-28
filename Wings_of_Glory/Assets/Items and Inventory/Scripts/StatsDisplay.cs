
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro

public class StatsDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

    [SerializeField] TMP_Text nameText; // Change this to TMP_Text
    [SerializeField] TMP_Text valueText; // Change this to TMP_Text


    public Stats Stat{ 
        get {return _stat;} 
        set {
            _stat = value;
            UpdateStatValue();
        } 
        }
    

    public string Name{ 
        get {return _name;} 
        set {
            _name = value;
            nameText.text = _name.ToLower();
        }
        }




    private Stats _stat ;
    private string _name;
    [SerializeField] StatTooltip tooltip;

    private void OnValidate()
    {
        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>(); // Change this to TMP_Text
        if (texts.Length >= 2)
        {
            nameText = texts[0];
            valueText = texts[1];
        }
        if (tooltip == null)
            tooltip = FindObjectOfType<StatTooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
{
    
        tooltip.ShowTooltip(Stat, Name);

    
    
}

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

   public void UpdateStatValue(int baseValue = 0, int currentValue = 0)
{
    if (baseValue == 0 && currentValue == 0)
    {
        valueText.text = _stat.Value.ToString();
    }
    else
    {
        if (currentValue < 0)
        {
            // Display just the currentValue when it's less than 0
            valueText.text = $"{currentValue}";
        }
        else
        {
            // Display just the baseValue in all other cases
            valueText.text = $"{baseValue}";
        }
    }
}



}
