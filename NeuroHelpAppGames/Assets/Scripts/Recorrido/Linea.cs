using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    LineRenderer linea;

    List<Vector2> puntos;

    Vector2 ultimoPunto;

    private void Awake()
    {
        linea = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)
        {
            Reco1.GetInstance().medioTocado = Reco1.GetInstance().raycastToObject();
           
            Debug.Log("Medio tocado transmitido por linea  " + Reco1.GetInstance().medioTocado.name);

        }
    }
    public void DibujarLinea(Vector2 ratonPos)
    {
        if(puntos == null)
        {
            puntos = new List<Vector2>();
            DibujarPunto(ratonPos);
            return;
        }

        if (Vector2.Distance(ultimoPunto,ratonPos)>= .05f)
        {
            DibujarPunto(ratonPos);
        }


    }

 

void DibujarPunto(Vector2 punto)
    {
        puntos.Add(punto);
        linea.positionCount = puntos.Count;
        linea.SetPosition(puntos.Count - 1, punto);
        ultimoPunto = punto;
    }

}
