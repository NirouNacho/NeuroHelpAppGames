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

    //llena una fila con dos prefabas que se repiten y los otros 3 no
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
        
           
            
            
           
                
    for (int y = 0; y <= 4; y ++)
    {
            int a = Random.Range(0, 9);
            auxObj = arrayObject[a];
            bool different = false;
            auxVector[0][y] = arrayObject[a];
            if (arrayObject[a].Equals(auxVector[0][y]))
            {
                break;
            }
            else
            {
                auxVector[0][i] = arrayObject[a];
            }
                    
    }
                
                
            

        
        
        return auxVector;
    }

}
