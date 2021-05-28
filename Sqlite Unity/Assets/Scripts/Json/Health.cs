using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Player player;
    public Text healthText;

    void Update()
    {
        healthText.text = player.health.ToString("0");
    }
}
