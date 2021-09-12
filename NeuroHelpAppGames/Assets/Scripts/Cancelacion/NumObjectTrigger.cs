using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumObjectTrigger : MonoBehaviour
{
    string objName;
    Collider2D collider;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        // obj = GetComponent<>
        objName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if (touch.phase == TouchPhase.Ended)
            {

                //para que el se de al finalizar el toque con la pantalla


                if (collider == touchedCollider)
                {

                    Debug.Log("haz tocado la pantalla en el obj: " + objName);
                    if (NumberGame.GetInstance().randomSelectedName == objName)
                    {
                        NumberGame.GetInstance().randomObjbuscados--;
                        gameObject.transform.SetParent(NumberGame.GetInstance().auxDestroy.transform);
                        gameObject.SetActive(false);
                    }

                }
            }

        }
    }
}
