using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int round = 1;

    public EnemiesAmount enemiesManager;
    public Transform Player;


    public void NextLevel()
    {
        enemiesManager.NewMap(round+3);
        Player.transform.position = new Vector2(0, -4.5f);
        Player.GetComponent<PlayerMovement>().canMove = true;
        Player.GetComponent<PlayerAttack>().canAttack = true;
    }

}
