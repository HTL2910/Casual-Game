using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] model;
    [HideInInspector]
    public GameObject[] modelPrefabs = new GameObject[4];
    public GameObject winPrefabs;

    private GameObject temp1, temp2;

    public int level = 1, addOn = 7;
    float i = 0;

    private void Start()
    {
       if(level>9)
       {
            addOn = 0;
       }
        ModelSelection();
        for(i = 0; i>-level-addOn;i-=0.5f)
        {
            if(level<=20)
            {
                temp1 = Instantiate(modelPrefabs[Random.Range(0, 2)]);
            }    
            else if(level<=50)
            {
                temp1 = Instantiate(modelPrefabs[Random.Range(1, 3)]);
            }
            else if(level<=100)
            {
                temp1 = Instantiate(modelPrefabs[Random.Range(2, 4)]);
            }
            else
            {
                temp1 = Instantiate(modelPrefabs[Random.Range(3, 4)]);
            }
            temp1.transform.position=new Vector3(0,i-0.01f,0);
            temp1.transform.eulerAngles = new Vector3(0, i *8, 0);
        }
        temp2 = Instantiate(winPrefabs);
        temp2.transform.position=new Vector3(0,i-0.01f,0);
    }
    private void ModelSelection()
    {
        int randomModel = Random.Range(0, 5);
        switch(randomModel)
        {
            case 0:
                for(int i=0;i<4;i++)
                {
                    modelPrefabs[i] = model[i];
                }
                break;
            case 1:

                for (int i = 0; i < 4; i++)
                {
                    modelPrefabs[i] = model[i+4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    modelPrefabs[i] = model[i+8];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    modelPrefabs[i] = model[i+12];
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    modelPrefabs[i] = model[i+16];
                }
                break;

        }
    }
    //https://www.youtube.com/watch?v=SLqF-Xsfbd0
}
