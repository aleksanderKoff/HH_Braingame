using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGrid : MonoBehaviour
{
    private int grid_id = 1;
    GameObject grid1;
    GameObject grid2;
    GameObject grid3;
    GameObject grid4;
    GameObject grid5;
    GameObject grid6;
    GameObject grid7;
    GameObject grid8;
    GameObject grid9;

    GameObject grid;
    public GameObject es_can;
    public float spawn_interval = 2.0f;

    void Start()
    {
        initGrid();
        InvokeRepeating("Spawn", 2.0f, spawn_interval);
    }
    void Spawn()
    {
        Quaternion spawnrotation = Quaternion.Euler(0,0,0); //prevents projectile from rotating during spawn

        //checks if BossGrid.cs is enabled and es_can exists
        if(es_can && gameObject.GetComponent<BossGrid>().enabled == true) 
        { 
            SetGridId();
            SetGridPosition();
            Instantiate(es_can, grid.transform.position, spawnrotation);
            Debug.Log($"Can spawned in ({grid}) position: {grid.transform.position}");
        }
        else
        {
            Debug.Log("Null can");
        }
    }

    public void SetGridId()
    {
        grid_id = Random.Range(1, 10);
    }

    public void SetGridPosition()
    {
        if (grid_id == 1)
        {
            grid = grid1;
        }
        if (grid_id == 2)
        {
            grid = grid2;
        }
        if (grid_id == 3)
        {
            grid = grid3;
        }
        if (grid_id == 4)
        {
            grid = grid4;
        }
        if (grid_id == 5)
        {
            grid = grid5;
        }
        if (grid_id == 6)
        {
            grid = grid6;
        }
        if (grid_id == 7)
        {
            grid = grid7;
        }
        if (grid_id == 8)
        {
            grid = grid8;
        }
        if (grid_id == 9)
        {
            grid = grid9;
        }
    }

    void initGrid()
    {
        grid1 = GameObject.Find("grid1");
        grid2 = GameObject.Find("grid2");
        grid3 = GameObject.Find("grid3");
        grid4 = GameObject.Find("grid4");
        grid5 = GameObject.Find("grid5");
        grid6 = GameObject.Find("grid6");
        grid7 = GameObject.Find("grid7");
        grid8 = GameObject.Find("grid8");
        grid9 = GameObject.Find("grid9");
    }
}
