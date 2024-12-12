using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomUpgrades : MonoBehaviour
{
    [Header("------- Generic Info -------")]
    private String header;
    private String desciption;

    [Header("------- Choice info -------")]
    public String Choice1header;
    public String Choice1description;

    public String Choice2header;
    public String Choice2description;

    public String Choice3header;
    public String Choice3description;

    public void GenerateUpgrades()
    {
        AssignRandom();
        Choice1header = header;
        Choice1description = desciption;

        AssignRandom();
        Choice2header = header;
        Choice2description = desciption;

        AssignRandom();
        Choice3header = header;
        Choice1description = desciption;
    }

    private void AssignRandom()
    {
        int randomInt = UnityEngine.Random.Range(1, 1);
        if (randomInt == 1)
        {
            header = "Candy Apple";
            desciption = "Buffs your maximum HP by 10!";
        }
        else if (randomInt == 2)
        {

        }
        else if (randomInt == 3)
        {

        }
        else if (randomInt == 4)
        {

        }
        else if (randomInt == 5)
        {

        }
    }
}
