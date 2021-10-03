using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EnemiesAmount : MonoBehaviour
{
    [SerializeField]
    private GameEvent LevelEnd;

    public GameObject slime;
    

    void Start()
    {
        NewMap(4);
    }

    public void NewMap(int enemies)
    {
        for(int i = 0; i < enemies; i++)
        {
            Instantiate(slime, new Vector2(Random.Range(-7.5f,7.5f),Random.Range(-7f,6.5f)), Quaternion.identity).transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("WIN");
            LevelEnd.Raise();
        }
    }
}
