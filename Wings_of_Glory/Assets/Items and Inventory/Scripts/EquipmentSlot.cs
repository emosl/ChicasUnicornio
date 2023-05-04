// This script is used to state the type of equipment that the character can use.
// Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot
{
    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + "Slot";
    }
    
}
