using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] float lifetime = 0.5f;
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
