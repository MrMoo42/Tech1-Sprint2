using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // for updating text UI

public class Choice1 : MonoBehaviour
{
    public string header;
    public string description;

    public TextMeshProUGUI headerText; // calls text that displays upgrade name
    public TextMeshProUGUI descriptionText; // calls text that displays upgrade description

    public Image image; // calls image to be set to upgrade image

    public void SetParameters(string head, string desc)
    {
        header = head;
        description = desc;

        headerText.text = $"{header}"; // set upgrade name to the header given by the random selecter
        headerText.text = $"{descriptionText}"; // set upgrade name to the description given by the random selecter

        GetCorrespondent(header);
    }

    private void GetCorrespondent(string head)
    { 
        // based on the name of the header, assigns the appropriate image
        if (head == "Candy Apple")
        {
            image = Resources.Load<Image>("Sprites/Candy Apple");
        }
        else if (head == "Deep-Fried Oreos")
        {
            image = Resources.Load<Image>("Sprites/Deep-Fried Oreos");
        }
        else if (head == "Hot Beef Sundae")
        {
            image = Resources.Load<Image>("Sprites/Hot Beef Sundae");
        }
        else if (head == "Krispy Kreme Burger")
        {
            image = Resources.Load<Image>("Sprites/Krispy Kreme Burger");
        }
        else if (head == "Elephant Ears")
        {
            image = Resources.Load<Image>("Sprites/Elephant Ears");
        }
    }
}
