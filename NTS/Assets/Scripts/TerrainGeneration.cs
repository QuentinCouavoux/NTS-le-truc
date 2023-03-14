using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject dirtFloor;
    void Start()
    {
        Random rd = new Random();
        bool[,] Map = new bool[50, 10];
        int randStart = rd.Next(0, 10);
        Map[0, randStart] = true;
        for (int i = 1; i < 50; i++)
        {
            int randTemp = rd.Next(0, 10);
            while (Math.Abs(randStart - randTemp) > 1)
            {
                randTemp = rd.Next(0, 10);
            }

            Map[i, randTemp] = true;
            randStart = randTemp;
        }

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Map[i, j])
                {
                    Vector3 temp = new Vector3(i, j, 0);
                    Instantiate(dirtFloor, temp, Quaternion.Identity);
                }
            }
        }
    }
}