using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rep1 : MonoBehaviour
{
    //singleton
    private static Rep1 sharedInstance;

    public GameObject[] arrayObject;
    private GameObject randomSelected;
    public GameObject auxDestroy;

    public GameObject[] auxArray;
    GameObject[,] auxVector;
    GameObject[,] PrimeraFila;
    GameObject[,] SegundaFila;
    GameObject[,] TerceraFila;
    GameObject[,] CuartaFila;

    //singelton
    private void Awake()
    {
        sharedInstance = this;

        auxVector = new GameObject[2,9]; //quiero dos arrays de 9 slots



    }
    //singelton
    public static Rep1 GetInstance()
    {
        return sharedInstance;
    }


    public void StartRep1Game()
    {
        arrayObject = LlenarArrayObj("Prefabs/Repeticion");
        
        
        Debug.Log("Entramos al random select");
        randomSelected = GetRandomSelected(arrayObject);
      


        PrimeraFila = LlenarArrayFilas();
        Debug.Log("primera fila");
        ImprimirFila(PrimeraFila);
        Debug.Log("impresos");
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
        return Instantiate(array[UnityEngine.Random.Range(0, 9)]);
        
    }

    //llena una fila con dos prefabas que se repiten y los otros y guarda el rabdom escogido
    //en [1][0]
    public GameObject[,] LlenarArrayFilas()
    {
        GameObject auxObj;
        auxObj = GetRandomSelected(arrayObject);
        Debug.Log("random select auxObj " + auxObj);
        auxVector[1,0] = auxObj;
        //auxObj = auxVector[1,0];
        Debug.Log("Vector auxVector[1,0] "+ auxVector[1, 0]);

        // lleno los dos que se repiten
        for (int i = 0; i <= 1; i++)
        {

            int a = UnityEngine.Random.Range(0, 5);
            Debug.Log("Random a] " + a);
            try
            {
                if ((!auxVector[0, a].Equals(auxVector[1, 0])))
                {
                    auxVector[0, i] = auxVector[1, 0];
                    Debug.Log("Vector auxVector[0,a] " + auxVector[0, i]);
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("entra al null "+ ex);
            }
            
         
        }

        //lleno los otros tres
      
        for (int y = 0; y <= 4; y ++) //hago 5 veces
        {
                int a = UnityEngine.Random.Range(0, 9);
                auxObj = arrayObject[a];
                bool canIn = false;
               for(int x= 0;x<= 4; x++)//pregunto 5 veces 
               {
                    if (auxObj.Equals(auxVector[0,x]))
                    {
                        canIn = false;
                        break;
                    }
                    else
                    {
                        canIn = true;
                    }
               }
           
               if (canIn)
                {
                    auxVector[0,y] = auxObj;
                }
            
        }

        return auxVector;
    }


    private void ImprimirFila(GameObject[,] aImprimir)
    {

        for (int i = 0; i <= 4 ; i++)//5 colums
        {
            Spawnfile(i, 0, aImprimir);
        }
    }

    private void Spawnfile(int x, int y, GameObject[,] aImprimir)
    {
        int columns = 5;
        int rows = 4;

        GameObject g = Instantiate(aImprimir[0,x]);

        g.transform.position = new Vector3((x * 2.5f) - (rows - 0.5f), (y * 2) - (columns - 1));

       
    }


}
