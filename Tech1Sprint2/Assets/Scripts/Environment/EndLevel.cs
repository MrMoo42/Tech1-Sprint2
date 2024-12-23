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

    [SerializeField] public Upgrade[] upgradeArray = new Upgrade[5];

    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex; // gets the current level
    }

    public void EnemyKilled()
    {
        enemyKills++;
        if (enemyKills == totalEnemies)
        {
            //EndLevelUI(); // end level if all enemies are dead
            StartCoroutine(NextScene());
        }
    }

    private void EndLevelUI()
    {
        SRU.GenerateUpgrades(); // starts the UI process for selecting upgardes
    }

    private void LevelComplete()
    {
        DataStorage.upgradeStorage = PUM.upgrades; // stores upgrades
        DataStorage.playerSavedHP = HP.health; // stores current hp
    }

    IEnumerator NextScene()
    {
        int randomUp = Random.Range(1, 6);
        PUM.AddUpgrade(upgradeArray[randomUp-1]);

        LevelComplete();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Floor 1");



        int randomInt = Random.Range(1, 4);
        while (randomInt == level) // randomly chooses the next level so long as it's not the same as the current level
        {
            randomInt = Random.Range(1, 4);
        }

        /*switch (randomInt) // loads a level based on the random number
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
        }*/
    }
}
