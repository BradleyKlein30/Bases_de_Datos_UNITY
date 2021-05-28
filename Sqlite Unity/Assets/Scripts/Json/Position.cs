using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    public Player player;
    public Text positionText;

    void Update()
    {
        positionText.text = player.transform.position.ToString("0");
    }
}
