using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintScript : MonoBehaviour
{
    public int health = 3;
    private Renderer objectRenderer;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        checkHealth(health);
    }

    public void checkHealth(int health)
    {
        if (health <= 0)
        {
            objectRenderer.material.color = Color.yellow;
        }
    }
}
