using UnityEngine;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    public float statsMultiplier = 0.01f;
    public int experienceMultiplierPerLevel = 500;
    public int previousExperience = 0;
    public int currentExperience = 0;
    public int currentLevel = 1;

    PlayerMovement playerMovement;
    PlayerHealth playerHealth;
    PlayerAttack playerAttack;

    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddExperience(int experience)
    {
        previousExperience = currentExperience;
        currentExperience += experience;

        int previousLevel = (previousExperience / experienceMultiplierPerLevel) + 1;
        int level = (currentExperience / experienceMultiplierPerLevel) + 1;

        if (previousLevel != level)
        {
            SetLevel(level);
        }
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
        print("Leveled up to " + currentLevel + "!");

        playerMovement.speed = playerMovement.initialSpeed * (1 + (statsMultiplier * currentLevel));
        playerHealth.startingHealth = playerHealth.initialHealth * (1 + (statsMultiplier * currentLevel));

        playerAttack.damagePerShot = playerAttack.initialDamagePerShot * (1 + (statsMultiplier * currentLevel));
        playerAttack.timeBetweenBullets = playerAttack.initialTimeBetweenBullets * (1 - (statsMultiplier * currentLevel));
        ScoreManager.Instance.Level = currentLevel;
    }
}
