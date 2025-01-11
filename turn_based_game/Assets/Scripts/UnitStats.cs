using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitStats", menuName = "ScriptableObjects/UnitStats", order = 1)]
public class UnitStats : ScriptableObject
{
    public string unitName;
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }
}
