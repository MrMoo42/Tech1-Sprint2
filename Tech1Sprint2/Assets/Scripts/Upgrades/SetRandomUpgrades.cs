using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomUpgrades : MonoBehaviour
{
    [Header("------- Generic Info -------")]
    private String header;
    private String desciption;

    //[Header("------- Choice info -------")]
    //public String Choice1header;
    //public String Choice1description;

    //public String Choice2header;
    //public String Choice2description;

    //public String Choice3header;
    //public String Choice3description;

    public Choice1 choice1;
    public Choice1 choice2;
    public Choice1 choice3;


    public void GenerateUpgrades()
    {
        AssignRandom();
        choice1.SetParameters(header,desciption);
        //Choice1header = header;
        //Choice1description = desciption;

        AssignRandom();
        choice2.SetParameters(header, desciption);
        //Choice2header = header;
        //Choice2description = desciption;

        AssignRandom();
        choice3.SetParameters(header, desciption);
        //Choice3header = header;
        //Choice1description = desciption;
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
