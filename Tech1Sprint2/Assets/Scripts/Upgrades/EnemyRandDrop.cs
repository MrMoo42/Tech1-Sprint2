using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyRandDrop : MonoBehaviour
{
    [Description("In percentage!!!")]
    public float deathDropChance = 1.0f;
    private int choice;
    [SerializeField] private GameObject hpDrop, speedDrop, damageDrop, atkSpeedDrop, rangeDrop;

    private void OnDestroy() {
        int temp = Random.Range(1, 100);

        if (deathDropChance >= temp) {
            choice = Random.Range(1, 6);
            Debug.Log("Upgrade Choice: " + choice);
            switch (choice) {
                case 1:
                    Instantiate(hpDrop, transform.position, Quaternion.identity, GameObject.Find("TempObjects").transform);
                    break;
                case 2:
                    Instantiate(speedDrop, transform.position, Quaternion.identity, GameObject.Find("TempObjects").transform);
                    break;
                case 3:
                    Instantiate(damageDrop, transform.position, Quaternion.identity, GameObject.Find("TempObjects").transform);
                    break;
                case 4:
                    Instantiate(atkSpeedDrop, transform.position, Quaternion.identity, GameObject.Find("TempObjects").transform);
                    break;
                case 5:
                    Instantiate(rangeDrop, transform.position, Quaternion.identity, GameObject.Find("TempObjects").transform);
                    break;
                default:
                    Debug.LogError(choice + " is an invalid upgrade ID");
                    break;
            }
        }
    }
}
