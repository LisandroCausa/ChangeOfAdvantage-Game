using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class WinZone : MonoBehaviour
{

    [SerializeField]
    private GameEvent Transition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().canMove = false;
            other.gameObject.GetComponent<PlayerAttack>().canAttack = false;
            Transition.Raise();
        }
    }

}
