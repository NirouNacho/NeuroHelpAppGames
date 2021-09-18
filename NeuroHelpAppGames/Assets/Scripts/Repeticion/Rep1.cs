using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rep1 : MonoBehaviour
{

    public GameObject[] arrayObject;
    private GameObject randomSelected;
    public GameObject auxDestroy;
    
    public GameObject[] auxArray;
    GameObject[][] auxVector;
    GameObject[][] PrimeraFila;
    GameObject[][] SegundaFila;
    GameObject[][] TerceraFila;
    GameObject[][] CuartaFila;


    public void StartRep1Game()
    {
        arrayObject = LlenarArrayObj("Prefabs/Repeticion");
        randomSelected = GetRandomSelected(arrayObject);
        PrimeraFila = LlenarArrayFilas();

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
        return Instantiate(array[Random.Range(0, 9)]);

    }

    //llena una fila con dos prefabas que se repiten y los otros y guarda el rabdom escogido
    //en [1][0]
    public GameObject[][] LlenarArrayFilas()
    {
        GameObject auxObj;
        auxVector[1][0] = GetRandomSelected(auxArray);
        auxObj = auxVector[1][0];
        bool aux = true;

        // lleno los dos que se repiten
        for (int i = 0; i <= 1; i++)
        {

            int a = Random.Range(0, 4);
            if(!auxVector[0][a].Equals(auxVector[1][0]))
            {
                auxVector[0][a] = auxVector[1][0];
            }
         
        }

        //lleno los otros tres
      
        for (int y = 0; y <= 4; y ++) //hago 5 veces
        {
                int a = Random.Range(0, 9);
                auxObj = arrayObject[a];
                bool canIn = false;
               for(int x= 0;x<= 4; x++)//pregunto 5 veces 
               {
                    if (auxObj.Equals(auxVector[0][x]))
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
                    auxVector[0][y] = auxObj;
                }
            
        }

        return auxVector;
    }


    private void ImprimirFila(GameObject[][] aImprimir)
    {

    }

    private void Spawnfile(int x, int y, int value, GameObject[][] aImprimir)
    {
        int columns = 5;
        int rows = 4;

        GameObject g = Instantiate(aImprimir[0][value]);

        g.transform.position = new Vector3((x * 2.5f) - (rows - 0.5f), (y * 2) - (columns - 1));

        if (g.name == randomSelected.name)
        {
            randomObjbuscados++;
        }
    }


}
