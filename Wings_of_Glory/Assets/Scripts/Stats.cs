//Wings of Glory script. This script is used in the implementation of Wings of Glory
//Authors: Lucía Barrenechea, Fernanda Osorio, Emilia Salazar, Arantza Parra, Fernanda Cortes
//May 1, 2023
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

[Serializable]


public class Stats 
{
    public int BaseValue;



    public virtual int Value { 
        get { 
            if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value; 
            }
             
    }


    protected bool isDirty = true;

    protected int _value;

    protected int lastBaseValue = int.MinValue;
 
    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public Stats()
{
    statModifiers = new List<StatModifier>();
    StatModifiers = statModifiers.AsReadOnly();
}
 
public Stats(int baseValue) : this()
{
    BaseValue = baseValue;
}

    public virtual void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    protected int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }

    public virtual bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
        for (int i = statModifiers.Count -1 ; i >= 0; i-- )
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected int CalculateFinalValue()
    {
        int finalValue = BaseValue;

        for (int i = 0; i< statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += (int)mod.Value;

            }
            
        }

        return finalValue;
    }
 


}