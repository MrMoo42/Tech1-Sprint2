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

    public TextMeshProUGUI headerText;
    public TextMeshProUGUI descriptionText;

    public Image image;

    public void SetParameters(string head, string desc)
    {
        header = head;
        description = desc;

        headerText.text = $"{header}";
        headerText.text = $"{descriptionText}";

        GetCorrespondent(header);
    }

    private void GetCorrespondent(string head)
    {
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
