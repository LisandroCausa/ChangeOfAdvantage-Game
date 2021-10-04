using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EnemiesAmount : MonoBehaviour
{
    [SerializeField]
    private GameEvent LevelEnd;


    private bool eventWasSended;

    public GameObject slime;

    void Start()
    {
        NewMap(4);
    }

    public void NewMap(int enemies)
    {
        foreach(Transform t in this.transform)
        {
            Destroy(t.gameObject);
        }

        for(int i = 0; i < enemies; i++)
        {
            Instantiate(slime, new Vector2(Random.Range(-7.5f, 7.5f),Random.Range(-5.5f, 7f)), Quaternion.identity).transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        if(transform.childCount == 0 && eventWasSended == false)
        {
            eventWasSended = true;
            LevelEnd.Raise();
        }
        else if(transform.childCount > 0)
        {
            eventWasSended = false;
        }
    }
}
