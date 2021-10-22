using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTriggertRvisual : MonoBehaviour
{

    string objName;

    public SpriteRenderer checkSpriteRenderer;

    GameObject visto;
    Collider2D collider;

    private void Awake()
    {
        visto = gameObject.transform.Find("visto").gameObject;
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        collider = GetComponent<Collider2D>();
        objName = gameObject.name;
        objName = objName.Replace("(Clone)", "");
        
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

                    if (objName == RecoVisual1.GetInstance().tarjetaRndm1.name)
                    {
                        visto.SetActive(true);
                        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.Idle1)
                        {
                            StartCoroutine(DestroyWaitFor2(GameStateRV.InicioRV2));
                            RecoVisual1.GetInstance().SearchObjPhrase.SetActive(false);
                            StartCoroutine(GameManagerRecoVisual.GetInstance().FelicidadesWait(GameStateRV.Idle1));

                        }

                        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.Idle2)
                        {
                            StartCoroutine(DestroyWaitFor2(GameStateRV.InicioRV3));
                            RecoVisual1.GetInstance().SearchObjPhrase.SetActive(false);
                            StartCoroutine(GameManagerRecoVisual.GetInstance().FelicidadesWait(GameStateRV.Idle2));

                        }

                    }
                    

                    
                    if(GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.Idle3)
                    {
                        if ((objName == RecoVisual1.GetInstance().tarjetaRndm2L.name) || (objName == RecoVisual1.GetInstance().tarjetaRndm2R.name))
                        {
                            visto.SetActive(true);
                            collider.enabled = false;
                            RecoVisual1.GetInstance().isFounded++;
                            Debug.Log("haz tocado la pantalla en el obj: " + objName);
                            if (RecoVisual1.GetInstance().isFounded == 2)
                            {
                                StartCoroutine(DestroyWaitFor4(GameStateRV.InicioRV4));
                                RecoVisual1.GetInstance().SearchObjPhrase.SetActive(false);
                                StartCoroutine(GameManagerRecoVisual.GetInstance().FelicidadesWait(GameStateRV.Idle3));
                            }
                        }
                    }

                    if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.Idle4)
                    {
                        if ((objName == RecoVisual1.GetInstance().tarjetaRndm2L.name) || (objName == RecoVisual1.GetInstance().tarjetaRndm2R.name))
                        {
                            visto.SetActive(true);
                            collider.enabled = false;
                            RecoVisual1.GetInstance().isFounded++;
                            Debug.Log("haz tocado la pantalla en el obj: " + objName);
                            if (RecoVisual1.GetInstance().isFounded == 2)
                            {
                                StartCoroutine(DestroyWaitFor4(GameStateRV.FinalRV));
                                RecoVisual1.GetInstance().SearchObjPhrase.SetActive(false);
                                StartCoroutine(GameManagerRecoVisual.GetInstance().FelicidadesWait(GameStateRV.Idle4));
                                

                            }
                        }
                    }



                }
            }
        }
    }


    IEnumerator DestroyWaitFor2(GameStateRV newState)
    {

        yield return new WaitForSeconds(3);
        GameManagerRecoVisual.GetInstance().felicitacionesImage.SetActive(true);
        RecoVisual1.GetInstance().tarjetaRndm1.SetActive(true);
        Debug.Log("Destroy started : " + Time.time);
        RecoVisual1.GetInstance().DestroyObjects("primerafila");
        GameManagerRecoVisual.GetInstance().currentGameState = newState;
        //yield on a new YieldInstruction that waits for 5 seconds.
        //After we have waited 5 seconds print the time again.
        Debug.Log("Destroy Coroutine at timestamp : " + Time.time);
        
    }

    IEnumerator DestroyWaitFor4(GameStateRV newState)
    {

        yield return new WaitForSeconds(3);
        GameManagerRecoVisual.GetInstance().felicitacionesImage.SetActive(true);
        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.Idle4)
        {
            GameManagerRecoVisual.GetInstance().buttonsFinals.SetActive(true);
        }
        RecoVisual1.GetInstance().tarjetaRndm2L.SetActive(true);
        RecoVisual1.GetInstance().tarjetaRndm2R.SetActive(true);
        RecoVisual1.GetInstance().DestroyObjects("primerafila");
        GameManagerRecoVisual.GetInstance().currentGameState = newState;
       

    }

}
