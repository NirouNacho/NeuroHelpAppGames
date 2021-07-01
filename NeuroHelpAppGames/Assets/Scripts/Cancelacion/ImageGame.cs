using System.Collections;
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

   
    
    public Text topText;
    public Image topImage;

    //private  

    private void Awake()
    {
        sharedInstance = this;
    }

    public static ImageGame GetInstance()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {

        randomObjbuscados = 0;
        
        imageObject = Resources.LoadAll<GameObject>("Prefabs/Cancelacion/ImagesPrefabs");
        
        randomSelected = Instantiate(imageObject[Random.Range(0, 5)]);
        randomSelected.SetActive(false);
        SetRandomSelectedImgage(randomSelected);



        columns = 5 ;
        rows = 4 ;

        Grid = new int[columns,rows];
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

    }
    
    // Update is called once per frame
    void Update()
    {
        if (randomObjbuscados == 0)
        {
            Debug.Log("Felicitaciones todos los objetos han sido encontrados");
        }
    }

    private void Spawnfile(int x, int y,int value)
    {
        
        GameObject g = Instantiate(imageObject[value]);
        
        g.transform.position= new Vector3((x*2.5f)-(rows-0.5f), (y*2) - (columns-1));

        if (g.name == randomSelected.name)
        {
            randomObjbuscados++;
        }
    }


    private void SetRandomSelectedImgage(object randomObj)
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

    private void DestroyGrid()
    {
        
    }

}
