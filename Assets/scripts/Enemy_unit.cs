using John_Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_unit : JohnScript
{
    public string unitName;
    public int unitDamage;
    public int unitMaxhp;
    public int unitCurrenthp;

    public bool TakeDamage(int dmg)
    {
        unitCurrenthp -= dmg;

        if (unitCurrenthp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PlayerTakeDamage(int dmg)
    {
        rations -= dmg;
        if (rations >= 0)
        {
            return true;
        }
        else  
        {
            return false; 
        }

    }
}
