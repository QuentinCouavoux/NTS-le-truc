using System;
using UnityEngine;
public class TerrainGeneration : MonoBehaviour
{
    public GameObject dirtFloor;
    public GameObject dirt;
    public GameObject startButton;
    public GameObject mainMenuCanvas;
    public GameObject mainMenuScreen;
    public GameObject leJoueur;
    public GameObject tree;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(true);
        startButton.SetActive(true);
        mainMenuScreen.SetActive(true);
        dirt.SetActive(true);
        leJoueur.SetActive(false);
        dirtFloor.SetActive(true);
    }

    public void Creation()
    {
        mainMenuCanvas.SetActive(true);
        startButton.SetActive(false);
        leJoueur.SetActive(true);
        mainMenuScreen.SetActive(false);
        
        System.Random rd = new System.Random();
        bool[,] map = new bool[200, 10];
        int randStart = rd.Next(0, 10);
        map[0, randStart] = true;
        for (int i = 1; i < 200; i++)
        {
            int randTemp = rd.Next(0, 10);
            while (Math.Abs(randStart - randTemp) > 1)
            {
                randTemp = rd.Next(0, 10);
            }

            map[i, randTemp] = true;
            randStart = randTemp;
        }

        int treeDelay = rd.Next(5, 10);
        
        for (int i = 0; i < 200; i++)
        {
            treeDelay -= 1;
            bool floorPlaced = true;
            for (int j = 0; j < 10; j++)
            {
                if (floorPlaced)
                {
                    Vector3 temp = new Vector3(i, j, 0);
                    Instantiate(dirt, temp, Quaternion.identity);
                }
                
                if (map[i, j])
                {
                    Vector3 temp = new Vector3(i, j, 0);
                    floorPlaced = false;
                    Instantiate(dirtFloor, temp, Quaternion.identity);
                    
                    if (treeDelay < 0)
                    {
                        Vector3 otherTemp = new Vector3(i, j, 1);
                        Instantiate(tree, otherTemp, Quaternion.identity);
                        treeDelay = rd.Next(5, 20);
                    }
                }
            }
        }

        for (int j = 0; j < 15; j++)
        {
            Vector3 temp = new Vector3(-1, j, 0);
            Instantiate(dirt, temp, Quaternion.identity);
        }
        Instantiate(dirtFloor, new Vector3(-1, 15, 0), Quaternion.identity);
    }
}