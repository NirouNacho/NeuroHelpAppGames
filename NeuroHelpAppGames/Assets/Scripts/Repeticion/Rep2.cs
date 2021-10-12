using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rep2 : MonoBehaviour
{

    //singleton
    private static Rep2 sharedInstance;

    // Start is called before the first frame update

    public GameObject[] arrayObject;
    GameObject[] ObjfondoDeFila;

    public GameObject auxDestroy;

    public GameObject[] auxArray;
    public GameObject[,] auxVector;

    public int contPrimCol = 0;
    public int contSegCol = 0;
    public int contTerCol = 0;
    public int contCuarCol = 0;
    public int contQuinCol = 0;

    public GameObject[,] PrimeraCol;
    public GameObject[,] SegundaCol;
    public GameObject[,] TerceraCol;
    public GameObject[,] CuartaCol;
    public GameObject[,] QuintaCol;

    public GameObject SearchObjPhrase;
    public GameObject felicitacionesImage;

    private enum Columnas
    {
        primeracolumna, segundacolumna, terceracolumna, cuartacolumna, quintacolumna

    }

    private void Awake()
    {
        sharedInstance = this;

        contPrimCol = 0;
        contSegCol = 0;
        contTerCol = 0;
        contCuarCol = 0;
        contQuinCol = 0;


        ObjfondoDeFila = LlenarArrayObj("Prefabs/Repeticion/filas");




        auxVector = new GameObject[3, 9]; //quiero dos arrays de 9 slots
        PrimeraCol = new GameObject[3, 9];
        SegundaCol = new GameObject[3, 9];
        TerceraCol = new GameObject[3, 9];
        CuartaCol = new GameObject[3, 9];
        QuintaCol = new GameObject[3, 9];
    }

    //singelton
    public static Rep2 GetInstance()
    {
        return sharedInstance;
    }


    public void StartRep2Game()
    {
        arrayObject = LlenarArrayObj("Prefabs/Repeticion/ImagesChilds");

        PrimeraCol = LlenarArrayColumnas(PrimeraCol, "primerafila");
        ImprimirFila(PrimeraCol, 0);
        SegundaCol = LlenarArrayColumnas(SegundaCol, "segundafila");
        for (int i = 0; i >= 3; i++)
        {
            Debug.Log("SegundaCol [0," + i + "]" + SegundaCol[0, i]);
        }
        ImprimirFila(SegundaCol, 1);
        TerceraCol = LlenarArrayColumnas(TerceraCol, "tercerafila");
        ImprimirFila(TerceraCol, 2);
        CuartaCol = LlenarArrayColumnas(CuartaCol, "cuartafila");
        ImprimirFila(CuartaCol, 3);
        QuintaCol = LlenarArrayColumnas(QuintaCol, "quintafila");
        ImprimirFila(QuintaCol, 4);



    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //llena el array de prefabs desde una direccion
    public GameObject[] LlenarArrayObj(string direccion)
    {
        return arrayObject = Resources.LoadAll<GameObject>(direccion);
    }

    public GameObject GetRandomSelected(GameObject[] array)
    {
        return array[UnityEngine.Random.Range(0, 9)];

    }

    public GameObject[,] LlenarArrayColumnas(GameObject[,] aLLenar, string tag)
    {
        aLLenar = new GameObject[2, 9];
        GameObject auxObj;
        auxObj = GetRandomSelected(arrayObject);
        Debug.Log("random select auxObj " + auxObj);
        aLLenar[1, 0] = auxObj;
        //auxObj = auxVector[1,0];
        Debug.Log("Vector aLLenar[1,0] " + aLLenar[1, 0]);

        // lleno los dos que se repiten

        int randoma = UnityEngine.Random.Range(0, 4);
        int randomb = UnityEngine.Random.Range(0, 4);
        while (randoma == randomb)
        {
            randomb = UnityEngine.Random.Range(0, 4);
        }
        auxObj.tag = tag;
        aLLenar[0, randoma] = auxObj;
        aLLenar[0, randomb] = auxObj;

        Debug.Log("Vector aLLenar[0," + randoma + " ] randoma " + aLLenar[0, randoma]);
        Debug.Log("Vector aLLenar[0," + randomb + " ] randomb " + aLLenar[0, randomb]);




        //lleno los otros tres

        for (int y = 0; y <= 3; y++) //hago 4 veces
        {
            int a = UnityEngine.Random.Range(0, 9);
            auxObj = arrayObject[a];
            bool canIn = false;


            for (int x = 0; x <= y; x++) //pregunto hasta la posicion que voy  colocar
            {


                if (aLLenar[0, x] == null)
                {
                    canIn = true;
                    if (auxObj.name == aLLenar[1, 0].name)
                    {
                        canIn = false;
                        y--;
                        break;
                    }

                }
                else if (aLLenar[0, x].name == auxObj.name)
                {
                    canIn = false;
                    y--;
                    break;
                }
                else if (auxObj.name == aLLenar[1, 0].name)
                {
                    canIn = false;
                    y--;
                    break;
                }


            }
            if (canIn)
            {
                auxObj.tag = tag;
                aLLenar[0, y] = auxObj;

            }

        }

        for (int i = 0; i <= 3; i++)
        {
            Debug.Log("Array a llenar:  aLLenar[0," + i + " ]" + aLLenar[0, i] + " tag " + aLLenar[0, i].tag);
        }
        Debug.Log("Fin a llenar");
        return aLLenar;
    }

    private void ImprimirFila(GameObject[,] aImprimir, int posInicial)
    {
        //GameObject filaObject = Instantiate(ObjfondoDeFila[0]);
        //filaObject.transform.position = new Vector3(1.621f, (posInicial * 2) - 4, 1);
        for (int i = 0; i <= 3; i++)//4 colums
        {
            Spawnfile(i, posInicial, aImprimir);
        }

    }

    private void Spawnfile(int x, int y, GameObject[,] aImprimir)
    {
        int columns = 5;
        int rows = 4;

        GameObject g = Instantiate(aImprimir[0, x]);

        g.transform.position = new Vector3( (y * 2) - (columns - 1), (x * 2.0f) - (rows - 0.5f));


    }

    private void DestroyObjects(string tag)
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);


        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }



    }



}
