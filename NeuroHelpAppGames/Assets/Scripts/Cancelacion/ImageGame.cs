﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGame : MonoBehaviour
{
    public Camera camera;
    public Sprite sprite;

    private static ImageGame sharedInstance;

    public GameObject[] imageObject;
    private GameObject randomSelected;
    public string randomSelectedName;
    Sprite randomSelectedSprite;
    public int randomObjbuscados;
    public int[,] Grid;
    int rows, columns;

    public GameObject auxDestroy;
    
    public GameObject SearchObjPhrase;
    public Text topText;
    public Image topImage;

    public GameObject felicitacionesImage;

    //private  

    

    private void Awake()
    {
        sharedInstance = this;
    }

    public static ImageGame GetInstance()
    {
        return sharedInstance;
    }


    public void StartImageGame()
    {
        randomObjbuscados = 0;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);
        imageObject = Resources.LoadAll<GameObject>("Prefabs/Cancelacion/ImagesPrefabs");

        randomSelected = Instantiate(imageObject[Random.Range(0, 5)]);
        randomSelected.transform.SetParent(auxDestroy.transform);
        randomSelected.SetActive(false);
        SetRandomSelectedImage(randomSelected);



        columns = 5;
        rows = 4;

        Grid = new int[columns, rows];
        while (randomObjbuscados <= 0)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Grid[i, j] = Random.Range(0, 5);
                    Spawnfile(i, j, Grid[i, j]);
                }
            }
        }
        Debug.Log(randomObjbuscados);
        GameManager.GetInstance().StartImageGame();
    }


    // Start is called before the first frame update
    void Start()
    {

       
    }
    
    // Update is called once per frame
    void Update()
    {
        if (randomObjbuscados == 0)
        {
            felicitacionesImage.SetActive(true);
            DestroyObjects("cancelationObject");
            SearchObjPhrase.gameObject.SetActive(false);
            randomObjbuscados = -1;
            
            Debug.Log("Felicitaciones todos los objetos han sido encontrados");
            
            StartCoroutine( GameManager.GetInstance().FelicidadesWait(GameState.InicioVowelGame));
            GameManager.GetInstance().GetComponent<ImageGame>().enabled = false;
        }


    }

    private void Spawnfile(int x, int y, int value)
    {

        GameObject g = Instantiate(imageObject[value]);

        g.transform.position = new Vector3((x * 2.5f) - (rows - 0.5f), (y * 2) - (columns - 1));

        if (g.name == randomSelected.name)
        {
            randomObjbuscados++;
        }
    }


    private void SetRandomSelectedImage(object randomObj)
    {
        
        randomSelectedName = randomSelected.name;
        randomSelectedSprite = randomSelected.GetComponent<SpriteRenderer>().sprite;
        switch (randomSelectedName)
        {
            case "Banana(Clone)":

                topText.text = "  Toca todos los plátanos que encuentres como este:";
                
                break;
            case "Butterfly(Clone)":

                topText.text = "  Toca todas las mariposas que encuentres como esta:";
                break;

            case "Key(Clone)":

                topText.text = "  Toca todas las llaves que encuentres como esta:";
                break;

            case "Pear(Clone)":
                topText.text = "  Toca todas las peras que encuentres como esta:";
                break;
            case "Shoe(Clone)":
                topText.text = "  Toca todos los zapatos que encuentres como este:";
                break;
            default:
                
                break;
        }
        topImage.sprite = randomSelectedSprite;

    }

    private void DestroyObjects(string tag)
    {
        ActivateInactiveObjects();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            Debug.Log(target.name);
        }

        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }


        
    }

    private void ActivateInactiveObjects()
    {
        
        for (int i = 0; i < auxDestroy.transform.childCount; i++)
        {
            auxDestroy.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
