using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public void ApplyBuff(UnitStats stats, int attackIncrease, int defenseIncrease)
    {
        stats.attack += attackIncrease;
        stats.defense += defenseIncrease;
    }

    public void ApplyDebuff(UnitStats stats, int attackDecrease, int defenseDecrease)
    {
        stats.attack -= attackDecrease;
        stats.defense -= defenseDecrease;

        if (stats.attack < 0) stats.attack = 0;
        if (stats.defense < 0) stats.defense = 0;
    }
}
