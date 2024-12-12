using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int level;
    private int enemyKills; // how many enemies the player ahs killed so far
    public int totalEnemies; // how many enemies are on the map
    public PlayerUpgradeManager PUM; // reference to player upgrades
    public PlayerHealth HP;

    public SetRandomUpgrades SRU;

    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex; // gets the current level
    }

    public void EnemyKilled()
    {
        enemyKills++;
        if (enemyKills == totalEnemies)
        {
            EndLevelUI(); // end level if all enemies are dead
        }
    }

    private void EndLevelUI()
    {
        SRU.GenerateUpgrades();
    }

    private void LevelComplete()
    {
        DataStorage.upgradeStorage = PUM.upgrades;
        DataStorage.playerSavedHP = HP.health;
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        int randomInt = Random.Range(1, 4);
        while (randomInt == level)
        {
            randomInt = Random.Range(1, 4);
        }

        switch (randomInt)
        {
            case 1:
                SceneManager.LoadScene("Floor 1");
                break;
            case 2:
                SceneManager.LoadScene("Floor 2");
                break;
            case 3:
                SceneManager.LoadScene("Floor 3");
                break;
            case 4:
                SceneManager.LoadScene("Floor 4");
                break;
            default:

                break;
        }
    }
}
