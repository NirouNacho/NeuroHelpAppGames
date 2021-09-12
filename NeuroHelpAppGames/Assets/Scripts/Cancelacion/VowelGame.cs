using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VowelGame : MonoBehaviour
{
    public Camera camera;
    public Sprite sprite;

    private static VowelGame sharedInstance;

    public GameObject[] vowelObject;
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

    public static VowelGame GetInstance()
    {
        return sharedInstance;
    }

    public void StartVowelGame()
    {
        
        randomObjbuscados = 0;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);
        Debug.Log("si llega");
        vowelObject = Resources.LoadAll<GameObject>("Prefabs/Cancelacion/VowelPrefabs");

        randomSelected = Instantiate(vowelObject[Random.Range(0, 5)]);
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
        GameManager.GetInstance().StartVowelGame();
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
            StartCoroutine(GameManager.GetInstance().FelicidadesWait(GameState.InicioNumberGame));
            GameManager.GetInstance().GetComponent<ImageGame>().enabled = false;
        }
    }

    private void Spawnfile(int x, int y, int value)
    {

        GameObject g = Instantiate(vowelObject[value]);

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
            case "VocalA(Clone)":

                topText.text = "  Toca todos las vocales 'a' que encuentres como esta:";

                break;
            case "VocalE(Clone)":

                topText.text = "  Toca todas las vocales 'e' que encuentres como esta:";
                break;

            case "VocalI(Clone)":

                topText.text = "  Toca todas las vocales 'i' que encuentres como esta:";
                break;

            case "VocalO(Clone)":
                topText.text = "  Toca todas las vocales 'o' que encuentres como esta:";
                break;

            case "VocalU(Clone)":
                topText.text = "  Toca todos las vocales 'u' que encuentres como esta:";
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
