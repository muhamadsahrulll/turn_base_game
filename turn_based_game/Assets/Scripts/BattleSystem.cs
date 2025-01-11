using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyUnit;

    // PlayerStat Text Fields
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerAttackText;
    public TextMeshProUGUI playerDefenseText;

    // EnemyStat Text Fields
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI enemyAttackText;
    public TextMeshProUGUI enemyDefenseText;

    public TextMeshProUGUI logText;

    private bool isPlayerTurn = true;

    void Start()
    {
        UpdateUI();
        logText.text = "Battle Start! Player's Turn.";
    }

    public void OnAttackButton()
    {
        if (!isPlayerTurn) return;

        int damage = Mathf.Max(0, playerUnit.GetAttack() - enemyUnit.GetDefense());
        enemyUnit.TakeDamage(damage);

        logText.text = $"Player attacked Enemy for {damage} damage!";
        CheckBattleOutcome();

        isPlayerTurn = false;
        Invoke("EnemyTurn", 1f);
    }

    public void OnDefendButton()
    {
        if (!isPlayerTurn) return;

        logText.text = "Player is defending!";
        isPlayerTurn = false;
        Invoke("EnemyTurn", 1f);
    }

    void EnemyTurn()
    {
        if (enemyUnit.GetHealth() <= 0) return;

        bool attack = Random.value > 0.5f;
        if (attack)
        {
            int damage = Mathf.Max(0, enemyUnit.GetAttack() - playerUnit.GetDefense());
            playerUnit.TakeDamage(damage);
            logText.text = $"Enemy attacked Player for {damage} damage!";
        }
        else
        {
            logText.text = "Enemy is defending!";
        }

        CheckBattleOutcome();
        isPlayerTurn = true;
    }

    void CheckBattleOutcome()
    {
        if (enemyUnit.GetHealth() <= 0)
        {
            logText.text = "Player wins!";
        }
        else if (playerUnit.GetHealth() <= 0)
        {
            logText.text = "Enemy wins!";
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        // Update Player Stats
        playerNameText.text = playerUnit.GetUnitName();
        playerHealthText.text = $"Health: {playerUnit.GetHealth()}/{playerUnit.GetMaxHealth()}";
        playerAttackText.text = $"Attack: {playerUnit.GetAttack()}";
        playerDefenseText.text = $"Defense: {playerUnit.GetDefense()}";

        // Update Enemy Stats
        enemyNameText.text = enemyUnit.GetUnitName();
        enemyHealthText.text = $"Health: {enemyUnit.GetHealth()}/{enemyUnit.GetMaxHealth()}";
        enemyAttackText.text = $"Attack: {enemyUnit.GetAttack()}";
        enemyDefenseText.text = $"Defense: {enemyUnit.GetDefense()}";
    }
}
