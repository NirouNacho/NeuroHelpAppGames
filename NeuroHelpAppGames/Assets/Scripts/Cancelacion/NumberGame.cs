using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGame : MonoBehaviour
{

    public Camera camera;
    public Sprite sprite;

    private static NumberGame sharedInstance;

    public GameObject[] numberObject;
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

    private void Awake()
    {
        sharedInstance = this;
    }

    public static NumberGame GetInstance()
    {
        return sharedInstance;
    }

    public void StartNumberGame()
    {

        randomObjbuscados = 0;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);
        Debug.Log("si llega");
        numberObject = Resources.LoadAll<GameObject>("Prefabs/Cancelacion/NumberPrefabs");

        randomSelected = Instantiate(numberObject[Random.Range(0, 5)]);
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
        Debug.Log("este es el random de voweels" + randomObjbuscados);
        GameManager.GetInstance().StartNumberGame();
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
            //felicitacionesImage.SetActive(true);
            DestroyObjects("cancelationObject");
            SearchObjPhrase.gameObject.SetActive(false);
            randomObjbuscados = -1;

            Debug.Log("Felicitaciones todos los objetos han sido encontrados");
            //GameManager.GetInstance().StartVowelGame();
            StartCoroutine(GameManager.GetInstance().FelicidadesWait(GameState.Final));
            GameManager.GetInstance().GetComponent<NumberGame>().enabled = false;
        }
    }

    private void Spawnfile(int x, int y, int value)
    {

        GameObject g = Instantiate(numberObject[value]);

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
            case "Numero1(Clone)":

                topText.text = "  Toca todos las números 1 que encuentres: ";

                break;
            case "Numero2(Clone)":

                topText.text = "  Toca todos las números 2 que encuentres: ";

                break;

            case "Numero3(Clone)":

                topText.text = "  Toca todos las números 3 que encuentres: ";

                break;
            case "Numero4(Clone)":

                topText.text = "  Toca todos las números 4 que encuentres: ";

                break;

            case "Numero5(Clone)":

                topText.text = "  Toca todos las números 5 que encuentres: ";

                break;
            case "Numero6(Clone)":

                topText.text = "  Toca todos las números 6 que encuentres: ";

                break;

            case "Numero7(Clone)":

                topText.text = "  Toca todos las números 7 que encuentres: ";

                break;
            case "Numero8(Clone)":

                topText.text = "  Toca todos las números 8 que encuentres: ";

                break;

            case "Numero9(Clone)":

                topText.text = "  Toca todos las números 9 que encuentres: ";

                break;
            case "Numero0(Clone)":

                topText.text = "  Toca todos las números 0 que encuentres: ";

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
