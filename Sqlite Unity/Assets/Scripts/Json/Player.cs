using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 40;
    public float movementSpeed = 5F;
    public float rotationSpeed = 0.2F;

    void Start()
    {
        LoadPlayer();
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), rotationSpeed);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        movementSpeed = data.movementSpeed;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void ChangeHealth (int amount)
    {
        health += amount;
    }

    public void ChangeMovementSpeed(float amount)
    {
        movementSpeed += amount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
        }
        else if (other.gameObject.tag == "Heal")
        {
            health++;
        }
    }

}
