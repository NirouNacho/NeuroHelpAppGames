using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public Camera camera;
    public Sprite sprite;

    public GameObject[] imageObject;
    private GameObject randomSelected;
    string randomSelectedName;
    Sprite randomSelectedSprite;

    public int[,] Grid;
    int vertical, horizontal, rows, columns;
    
    public Text topText;
    public Image topImage;

    //private  

    // Start is called before the first frame update
    void Start()
    {
       

        vertical = (int)camera.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
       
        imageObject = Resources.LoadAll<GameObject>("Prefabs/Cancelacion/ImagesPrefabs");
        //imageObject[1].SetActive(false);
        Debug.Log(Screen.width + " w " + Screen.height + " h " + horizontal + " hori " + vertical + " verti ");
        
        randomSelected = Instantiate(imageObject[Random.Range(0, 5)]);
        randomSelected.SetActive(false);
        
        Debug.Log(randomSelectedName);

        SetRandomSelectedImgage(randomSelected);



        columns = horizontal ;
        rows = 4 ;

        Grid = new int[columns,rows];

        for (int i=0; i<columns;i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Grid[i, j] = Random.Range(0,5);
                Spawnfile(i, j, Grid[i, j]);
            }
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawnfile(int x, int y,int value)
    {
        
        GameObject g = Instantiate(imageObject[value]);
        //Vector3 objectPosition = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
        g.transform.position= new Vector3((x*2.5f)-(horizontal-0.5f), (y*2) - (vertical-1));
        //g = Instantiate(imageObject[value]);

        //var s = g.AddComponent<SpriteRenderer>();
        //s.sprite = sprite;
        //s.color = new Color(value,value,value);

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
}
