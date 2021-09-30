using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//addressable extension
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class FilasObjectTrigger : MonoBehaviour
{

    string objName;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {

        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // obj = GetComponent<>
        objName = gameObject.name;


        //addressables

        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/BirdHeroSprite.png");
        spriteHandle.Completed += LoadSpritesWhenReady;

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
                    //que es lo que debe hacer al tocar
                    spriteRenderer.sprite = spriteArray[0];

                }
            }

        }
    }


    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
        }
    }

    void ChangeSprite()
    {

    }
}
