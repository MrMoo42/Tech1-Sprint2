using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomUpgrades : MonoBehaviour
{
    [Header("------- Generic Info -------")]
    private String header;
    private String desciption;

    public Choice1 choice1;
    public Choice1 choice2;
    public Choice1 choice3;


    public void GenerateUpgrades()
    {
        AssignRandom(); // randomly generates an upgrade
        choice1.SetParameters(header,desciption); // sends info to the UI

        AssignRandom();
        choice2.SetParameters(header, desciption);

        AssignRandom();
        choice3.SetParameters(header, desciption);
    }

    private void AssignRandom()
    {
        int randomInt = UnityEngine.Random.Range(1, 1);

        // sets the header and description of the randomly chosen upgrade
        if (randomInt == 1)
        {
            header = "Candy Apple";
            desciption = "Buffs your maximum HP by 10!";
        }
        else if (randomInt == 2)
        {
            header = "Deep-Fried Oreos";
            desciption = "Buffs your movement speed by 10%! (Additive)";
        }
        else if (randomInt == 3)
        {
            header = "Hot Beef Sundae";
            desciption = "Buffs your atttack damage by 5!";
        }
        else if (randomInt == 4)
        {
            header = "Krispy Kreme Burger";
            desciption = "Buffs your atttack speed by 10%! (Additive)";
        }
        else if (randomInt == 5)
        {
            header = "Elephant Ears";
            desciption = "Buffs your atttack range by 10%! (Additive)";
        }
    }
}
