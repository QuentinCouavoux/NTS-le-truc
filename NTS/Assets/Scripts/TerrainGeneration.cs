using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject dirtFloor;
    public GameObject dirt;
    public GameObject startButton;
    public GameObject mainMenuCanvas;
    public GameObject mainMenuScreen;
    public GameObject mainMenuSizeInput;
    public GameObject leJoueur;
    public GameObject tree;

    private int InputQuantity;
    private bool OkInput;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(true);
        startButton.SetActive(true);
        mainMenuScreen.SetActive(true);
        mainMenuSizeInput.SetActive(true);
        dirt.SetActive(true);
        leJoueur.SetActive(false);
        dirtFloor.SetActive(true);
        OkInput = false;
        InputQuantity = 0;
    }
    
    public bool VerifyInt(string a)
    {
        foreach (char c in a)
        {
            if (c < '0' || c > '9')
            {
                return false;
            }
        }

        return true;
    }
    
    public void ReadInput(string a)
    {
        OkInput = false;
        if (a == "")
        {
            return;
        }

        if (VerifyInt(a))
        {
            InputQuantity = Int32.Parse(a);
            OkInput = true;
        }
    }

    public void Creation()
    {
        if (OkInput)
        {
            mainMenuCanvas.SetActive(true);
            startButton.SetActive(false);
            leJoueur.SetActive(true);
            mainMenuScreen.SetActive(false);
            mainMenuSizeInput.SetActive(false);

            System.Random rd = new System.Random();
            bool[,] map = new bool[InputQuantity, 50];
            int randStart = rd.Next(30, 40);
            map[0, randStart] = true;
            for (int i = 1; i < InputQuantity; i++)
            {
                int randTemp = rd.Next(0, 50);
                while (Math.Abs(randStart - randTemp) > 1)
                {
                    randTemp = rd.Next(0, 50);
                }

                map[i, randTemp] = true;
                if (i + 1 < InputQuantity)
                {
                    map[i + 1, randTemp] = true;
                    i += 1;
                }
                randStart = randTemp;
            }

            int treeDelay = rd.Next(5, 10);

            for (int i = 0; i < InputQuantity; i++)
            {
                treeDelay -= 1;
                bool floorPlaced = true;
                for (int j = 0; j < 50; j++)
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

            for (int j = 0; j < 50; j++)
            {
                Vector3 temp = new Vector3(-1, j, 0);
                Instantiate(dirt, temp, Quaternion.identity);
            }

            Instantiate(dirtFloor, new Vector3(-1, 50, 0), Quaternion.identity);
        }
    }
}