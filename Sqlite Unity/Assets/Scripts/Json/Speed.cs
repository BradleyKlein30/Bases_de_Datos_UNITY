using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Speed : MonoBehaviour
{
    public Player player;
    public Text speedText;

    void Update()
    {
        speedText.text = player.movementSpeed.ToString("0");
    }
}
