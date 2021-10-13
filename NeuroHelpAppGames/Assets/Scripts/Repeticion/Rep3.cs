using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rep3 : MonoBehaviour
{

    //singleton
    private static Rep3 sharedInstance;

    public GameObject[] arrayObject;
    GameObject[] ObjfondoDeFila;

    public GameObject auxDestroy;

    public GameObject[] auxArray;
    public GameObject[,] auxVector;

    public int contTabla = 0;
    

    public GameObject[,] ArrayTabla;
   

    public GameObject SearchObjPhrase;
    public GameObject felicitacionesImage;


    private void Awake()
    {

        sharedInstance = this;
        contTabla = 0;
       


        ObjfondoDeFila = LlenarArrayObj("Prefabs/Repeticion/tabla");




        auxVector = new GameObject[3, 9]; //quiero dos arrays de 9 slots
        ArrayTabla = new GameObject[3, 9];
        
    }
    
    //singelton
    public static Rep3 GetInstance()
    {
        return sharedInstance;
    }

    public void StartRep3Game()
    {
        arrayObject = LlenarArrayObj("Prefabs/Repeticion/ImagesChilds");

        ArrayTabla = LlenarArray(ArrayTabla, "primerafila");
        ImprimirTabla(ArrayTabla, 0);
      
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((contPrimCol == 3) && (contSegCol == 3) && (contTerCol == 3) && (contCuarCol == 3) && (contQuinCol == 3))
        {
            felicitacionesImage.SetActive(true);
            DestroyObjects("primerafila");  
            SearchObjPhrase.gameObject.SetActive(false);
            Debug.Log("Fin Rep3");

            /*
            StartCoroutine(GameManager.GetInstance().FelicidadesWait(GameState.InicioVowelGame));
            GameManager.GetInstance().GetComponent<ImageGame>().enabled = false;
            */
        }
    }

    public GameObject[] LlenarArrayObj(string direccion)
    {
        return arrayObject = Resources.LoadAll<GameObject>(direccion);
    }

    public GameObject GetRandomSelected(GameObject[] array)
    {
        return array[UnityEngine.Random.Range(0, 9)];

    }

    public GameObject[,] LlenarArray(GameObject[,] aLLenar, string tag)
    {
        aLLenar = new GameObject[2, 9];
        GameObject auxObj;
        auxObj = GetRandomSelected(arrayObject);
        Debug.Log("random select auxObj " + auxObj);
        aLLenar[1, 0] = auxObj;
        //auxObj = auxVector[1,0];
        Debug.Log("Vector aLLenar[1,0] " + aLLenar[1, 0]);

        // lleno los dos que se repiten

        int randoma = UnityEngine.Random.Range(0, 8);
        int randomb = UnityEngine.Random.Range(0, 8);
        while (randoma == randomb)
        {
            randomb = UnityEngine.Random.Range(0, 8);
        }
        auxObj.tag = tag;
        aLLenar[0, randoma] = auxObj;
        aLLenar[0, randomb] = auxObj;

        Debug.Log("Vector aLLenar[0," + randoma + " ] randoma " + aLLenar[0, randoma]);
        Debug.Log("Vector aLLenar[0," + randomb + " ] randomb " + aLLenar[0, randomb]);




        //lleno el resto

        for (int y = 0; y <= 8; y++) //hago 9 veces
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

        for (int i = 0; i <= 8; i++)
        {
            Debug.Log("Array a llenar:  aLLenar[0," + i + " ]" + aLLenar[0, i] + " tag " + aLLenar[0, i].tag);
        }
        Debug.Log("Fin a llenar");
        return aLLenar;
    }

    private void ImprimirTabla(GameObject[,] aImprimir, int posInicial)
    {
        GameObject filaObject = Instantiate(ObjfondoDeFila[0]);
        GameObject g;
        int j = 0;
        int x = 1;
        for (int i = 0; i <= 8; i++)
        {
            g = Instantiate(aImprimir[0,i]);
            
            if (i % 3 == 0)
            {
                j++;
                x = 1;
            }
                g.transform.position = new Vector3((x * 2.0f)-3, (j * 2) - 4.5f);
            x ++;

        }
            

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
