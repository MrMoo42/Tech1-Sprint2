using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int level;
    private int enemyKills;
    public int totalEnemies;
    public PlayerUpgradeManager PUM;
    public PlayerHealth HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        enemyKills++;
        if (enemyKills == totalEnemies)
        {
            LevelComplete();
        }
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
