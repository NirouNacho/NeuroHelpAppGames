using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rep1 : MonoBehaviour
{
    //singleton
    private static Rep1 sharedInstance;

    public GameObject[] arrayObject;
    GameObject[] ObjfondoDeFila;
    
    public GameObject auxDestroy;

    public GameObject[] auxArray;
    public GameObject[,] auxVector;

    public GameObject objetoPrimerafila;
    public GameObject objetoSegindafila;
    public GameObject objetoTercerafila;
    public GameObject objetoCuartafila;

    public int contPrimFila=0;
    public int contSegFila = 0;
    public int contTerFila = 0;
    public int contCuarFila = 0;


    public GameObject[,] PrimeraFila;
    public GameObject[,] SegundaFila;
    public GameObject[,] TerceraFila;
    public GameObject[,] CuartaFila;

    //singelton
    private void Awake()
    {
        sharedInstance = this;

        contPrimFila = 0;
        contSegFila = 0;
        contTerFila = 0;
        contCuarFila = 0;


        ObjfondoDeFila = LlenarArrayObj("Prefabs/Repeticion/filas");




        auxVector = new GameObject[3,9]; //quiero dos arrays de 9 slots
        PrimeraFila = new GameObject[3, 9];
        SegundaFila = new GameObject[3, 9];
        TerceraFila = new GameObject[3, 9];
        CuartaFila = new GameObject[3, 9];

    }
    //singelton
    public static Rep1 GetInstance()
    {
        return sharedInstance;
    }


    public void StartRep1Game()
    {
        arrayObject = LlenarArrayObj("Prefabs/Repeticion/ImagesChilds");
        
        PrimeraFila=LlenarArrayFilas(PrimeraFila, "primerafila");
        ImprimirFila(PrimeraFila, 0);
        SegundaFila =LlenarArrayFilas(SegundaFila, "segundafila");
        ImprimirFila(SegundaFila, 1);
        TerceraFila = LlenarArrayFilas(TerceraFila, "tercerafila");
        ImprimirFila(TerceraFila, 2);
        CuartaFila = LlenarArrayFilas(CuartaFila, "cuartafila");
        ImprimirFila(CuartaFila, 3);


        //for(int i = 0; i <= 4; i ++)
        //{
        //    Debug.Log("Array 1: " + PrimeraFila[0, i]);
        //}

        //for (int i = 0; i <= 4; i++)
        //{
        //    Debug.Log("Array 2: " + SegundaFila[0, i]);
        //}




    }
    
    // Start is called before the first frame update
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

    //llena una fila con dos prefabas que se repiten y los otros y guarda el rabdom escogido
    //en [1][0]
    public GameObject[,] LlenarArrayFilas(GameObject[,] aLLenar,string tag)
    {
        aLLenar = new GameObject[2, 9];
        GameObject auxObj;
        auxObj = GetRandomSelected(arrayObject);
        Debug.Log("random select auxObj " + auxObj);
        aLLenar[1,0] = auxObj;
        //auxObj = auxVector[1,0];
        Debug.Log("Vector aLLenar[1,0] " + aLLenar[1, 0]);

        // lleno los dos que se repiten
      
            int randoma = UnityEngine.Random.Range(0, 5);
            int randomb = UnityEngine.Random.Range(0, 5);
            while(randoma == randomb)
            {
                randomb = UnityEngine.Random.Range(0, 5);
            }
            auxObj.tag = tag;
            aLLenar[0, randoma] = auxObj;
            aLLenar[0, randomb] = auxObj;
            
            Debug.Log("Vector aLLenar[0," + randoma + " ] randoma " + aLLenar[0, randoma]);
            Debug.Log("Vector aLLenar[0," + randomb + " ] randomb " + aLLenar[0, randomb]);




        //lleno los otros tres

        for (int y = 0; y <= 4; y ++) //hago 5 veces
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
                    else if(aLLenar[0, x].name == auxObj.name)
                    {
                        canIn = false;
                        y--;
                        break;
                    }
                    else if (auxObj.name== aLLenar[1, 0].name)
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

        for (int i = 0; i <= 4; i++)
        {
            Debug.Log("Array a llenar:  aLLenar[0,"+ i + " ]" + aLLenar[0, i] + " tag " + aLLenar[0, i].tag);
        }
        Debug.Log("Fin a llenar");
        return aLLenar;
    }


    private void ImprimirFila(GameObject[,] aImprimir,int posInicial)
    {
        GameObject filaObject=Instantiate( ObjfondoDeFila[0]);
        filaObject.transform.position= new Vector3(1.621f, (posInicial * 2)-4,1);
        for (int i = 0; i <= 4 ; i++)//5 colums
        {
            Spawnfile(i, posInicial, aImprimir);
        }

    }

    private void Spawnfile(int x, int y, GameObject[,] aImprimir)
    {
        int columns = 5;
        int rows = 4;

        GameObject g = Instantiate(aImprimir[0,x]);

        g.transform.position = new Vector3((x * 2.5f) - (rows - 0.5f), (y * 2) - (columns - 1));

       
    }

    public void resetSpritesInRow(GameObject[,] fila)
    {
        GameObject child;
        for (int i = 0; i <= 4; i++)
        {
            child = fila[0, i].transform.Find("Child").gameObject;
            child.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("fila[0," + i +"] "+ fila[0, i] );
            Debug.Log("child " + child.GetComponent<SpriteRenderer>().enabled + "  "+child.name);
        }
    }

    public void checkFila()
    {
        
    }

}
