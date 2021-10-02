using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private float maxHealth = 100f;

    [SerializeField]
    private float Health;

    void Awake()
    {
        Health = maxHealth;
    }

    void Update()
    {
        
    }

    public void GetDamage(float damage)
    {

    }
}
