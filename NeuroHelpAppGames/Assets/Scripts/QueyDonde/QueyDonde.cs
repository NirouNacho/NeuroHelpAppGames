using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QueyDonde : MonoBehaviour
{

    private static QueyDonde sharedInstance;

    public GameObject SearchObjPhrase;
    public GameObject correctoImage;
    public GameObject incorrectoImage;

    public int randPosition;

    GameObject[] tarjetas;
    GameObject[] nombres;
    GameObject[] nombresPool;
    GameObject[] tarjetaVacia;

    public GameObject tarjetaRndm;
    public GameObject nombreRndm;
    GameObject[] vacios;


    public Canvas canvas;
    public GameObject pool;
    public GameObject buttonSiguiente;
    public Text topText;
    //posiciones de tarjetas

    Vector3 pos1 = new Vector3(-584, 190, 0);
    Vector3 pos2 = new Vector3(0, 32, 0);
    Vector3 pos3 = new Vector3(605, 190, 0);

    Vector3[] posiciones = new[]{ new Vector3(-584, 190, 0),
        new Vector3(0, 32, 0), new Vector3(605, 190, 0) };

    private void Awake()
    {
        tarjetaVacia = new GameObject[4];
        nombres = new GameObject[4];
        nombresPool = new GameObject[4];
        vacios = new GameObject[4];

        correctoImage.SetActive(false);
        incorrectoImage.SetActive(false);


        sharedInstance = this;

        tarjetas = LlenarArrayObj("Prefabs/QueyDonde/Tarjetas");
        tarjetaVacia = LlenarArrayObj("Prefabs/QueyDonde/TarjetaVacia");
        nombres = LlenarArrayObj("Prefabs/QueyDonde/Nombres");
        for (int i = 0; i <= 2; i++)
        {
            vacios[i] = tarjetaVacia[0];
        }

    }


    public static QueyDonde GetInstance()
    {
        return sharedInstance;
    }


    public void StartQueyDonde()
    {
        topText.text = "Fijate qué objetos hay y en que lugar se encuentran, luego tendrás que recordarlos.";
        tarjetaRndm = GetRandomSelected(tarjetas);
        imprimir1parte();
        llenarPool();

        for (int i = 0; i <= 2; i++)
        {
            Debug.Log("Array nombres pool:  [" + i + "]" + nombresPool[i]);
        }

    }

    public void StartQueyDondeDrag()
    {
        tarjetaRndm.SetActive(false);
        imprimirPool();
        buttonSiguiente.SetActive(false);
        topText.text = "Arrastra la palabra en el lugar que se encontraba su respectiva imagen.";
    }


    // Start is called before the first frame update
    void Start()
    {
        StartQueyDonde();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public GameObject[] LlenarArrayObj(string direccion)
    {
        GameObject[] lista;
        return lista = Resources.LoadAll<GameObject>(direccion);
    }

    public GameObject GetRandomSelected(GameObject[] array)
    {
        return array[UnityEngine.Random.Range(0, 5)];
    }

    private void imprimir1parte()
    {
        GameObject aux;
        aux = vacios[0];
        tarjetaRndm = Instantiate(tarjetaRndm);
        tarjetaRndm.transform.SetParent(canvas.transform);

        randPosition = UnityEngine.Random.Range(0, 3);
        tarjetaRndm.transform.localPosition = posiciones[randPosition];

        for (int i = 0; i <= 2; i++)
        {
            if (i == randPosition)
            {
                aux = Instantiate(aux);
                aux.transform.SetParent(canvas.transform);
                aux.transform.localPosition = posiciones[i];
                Debug.Log("Rand " + randPosition);
            }
            else
            {
                aux = Instantiate(aux);
                aux.transform.SetParent(canvas.transform);
                aux.transform.localPosition = posiciones[i];
            }
        }
    }

    private void llenarPool()
    {
        nombreRndm = tarjetaRndm.transform.GetChild(2).gameObject;
        nombreRndm.GetComponent<DragHandler>().enabled = false;
        print("nombre random " + nombreRndm);

        int a;
        GameObject auxObj;
        a = UnityEngine.Random.Range(0, 2);

        nombresPool[a] = nombreRndm;

        for (int y = 0; y <= 2; y++)
        {
            a = UnityEngine.Random.Range(0, 3);
            bool canIn = false;
            auxObj = nombres[a];

            for (int x = 0; x <= y; x++)
            {
                a = UnityEngine.Random.Range(0, 2);

                if (nombresPool[x] == null)
                {
                    canIn = true;
                    if (nombreRndm.name == auxObj.name)
                    {
                        canIn = false;
                        y--;
                        break;
                    }
                }
                else if (nombresPool[x].name == auxObj.name)
                {
                    canIn = false;
                    y--;
                    break;
                }
                else if (auxObj.name == nombreRndm.name)
                {
                    canIn = false;
                    y--;
                    break;
                }
            }
            if (canIn)
            {
                nombresPool[y] = auxObj;
            }
        }

        for (int i = 0; i <= 2; i++)
        {
            Debug.Log("Array nombres pool:  [" + i + "]" + nombresPool[i]);
        }
        Debug.Log("Fin a llenar");
    }

    private void imprimirPool()
    {
        nombreRndm.GetComponent<DragHandler>().enabled = true;
        for (int i = 0; i <= 2; i++)
        {
            nombresPool[i] = Instantiate(nombresPool[i]);
            nombresPool[i].transform.SetParent(pool.transform);

        }
    }

    public IEnumerator CorrectoWait()
    {
        correctoImage.SetActive(true);
        yield return new WaitForSeconds(3);
        correctoImage.SetActive(false);
        Debug.Log("salida de felicidades");
        
        
    }

    public IEnumerator InCorrectoWait()
    {
       
        incorrectoImage.SetActive(true);
        yield return new WaitForSeconds(3);
        incorrectoImage.SetActive(false);
        Debug.Log("salida de felicidades");
        
        
    }
}
