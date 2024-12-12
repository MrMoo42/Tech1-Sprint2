using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static List<Upgrade> upgradeStorage;
    public static float playerSavedHP;
    public static DataStorage instance;

    private void Awake() {
        instance = this;
    }

    public void ClearUpgradeStorage() {
        upgradeStorage.Clear();
    }
}
