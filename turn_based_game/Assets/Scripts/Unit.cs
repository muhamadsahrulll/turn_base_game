using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats unitStats;

    public void TakeDamage(int damage)
    {
        unitStats.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        unitStats.Heal(amount);
    }

    public string GetUnitName()
    {
        return unitStats.unitName;
    }

    public int GetHealth()
    {
        return unitStats.health;
    }

    public int GetMaxHealth()
    {
        return unitStats.maxHealth;
    }

    public int GetAttack()
    {
        return unitStats.attack;
    }

    public int GetDefense()
    {
        return unitStats.defense;
    }
}
