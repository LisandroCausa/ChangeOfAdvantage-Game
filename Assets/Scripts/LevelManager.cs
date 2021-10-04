using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class LevelManager : MonoBehaviour
{

    public static int round = 1;
    private int enemies = 1;

    public EnemiesAmount enemiesManager;
    public Transform Player;

    [SerializeField]
    private GameEvent map_start;

    public static bool tutorial = true;

    public void NextLevel()
    {
        enemies++;
        if(Random.Range(1, round+5) < 5) enemies += round * Random.Range(1, 3);

        enemiesManager.NewMap(enemies+3);
        Player.transform.position = new Vector2(0, -4.5f);
        Player.GetComponent<PlayerMovement>().canMove = true;
        Player.GetComponent<PlayerAttack>().canAttack = true;

        // RESET WIN ZONE
        map_start.Raise();
        // CLOSE DOOR
    }

    public void RestartGame()
    {
        enemies = 0;
        NextLevel();
    }

}
