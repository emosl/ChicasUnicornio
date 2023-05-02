
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFight : MonoBehaviour
{
    public Stats Strength;
    public Stats Agility;
    public Stats Shield;
    public Stats Speed;

    [SerializeField] private TobyBattle toby;
    [SerializeField] private batteryplayerfight batteryPlayerfight;
    // public EquipmentPanel equipmentPanel;
    public GameManagerFight gameManagerFight;

public void start(){
            batteryPlayerfight.ChangeAgility(Agility.Value);
            batteryPlayerfight.ChangeShield(Shield.Value);
            batteryPlayerfight.ChangeSpeed(Speed.Value);
            batteryPlayerfight.ChangeStrength(Strength.Value);
            batteryPlayerfight.ChangeLife(Shield.Value,Strength.Value,Agility.Value,Speed.Value);
}


}