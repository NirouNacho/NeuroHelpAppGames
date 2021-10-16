using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorLineas : MonoBehaviour
{

    public GameObject lineaGenerar;

    Linea linea;

    GameObject primerTocado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            Vector3 dondeGenerar = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
            GameObject lineaActual = Instantiate(lineaGenerar, dondeGenerar, transform.rotation);
            linea = lineaActual.GetComponent<Linea>();

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                primerTocado = hit.transform.gameObject;
                Debug.Log("Primer Tocado " + hit.transform.name);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            linea = null;
        }

        if (linea!=null)
        {
            Vector2 ratonPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            linea.DibujarLinea(ratonPos);
        }


    }
}
