using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Import untuk mengontrol UI Button

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

    // Heal Button and Cooldown
    public Button healButton; // Reference to Heal button
    public float healCooldown = 2f; // Cooldown in seconds
    private bool isHealOnCooldown = false;

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

    public void OnHealButton()
    {
        if (!isPlayerTurn || isHealOnCooldown) return;

        int healAmount = 20; // Heal amount (can be adjusted)
        playerUnit.Heal(healAmount);
        logText.text = $"Player healed for {healAmount} health!";

        StartCoroutine(HealCooldown());
        CheckBattleOutcome();

        isPlayerTurn = false;
        Invoke("EnemyTurn", 1f);
    }

    private IEnumerator HealCooldown()
    {
        isHealOnCooldown = true;
        healButton.interactable = false; // Disable the Heal button
        yield return new WaitForSeconds(healCooldown); // Wait for cooldown duration
        isHealOnCooldown = false;
        healButton.interactable = true; // Re-enable the Heal button
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
