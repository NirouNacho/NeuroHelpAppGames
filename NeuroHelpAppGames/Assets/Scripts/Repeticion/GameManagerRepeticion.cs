using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRepeticion : MonoBehaviour
{

    public enum GameState
    {
        InicioImgGame, ImgGame, InicioVowelGame, VowelGame, InicioNumberGame, NumberGame, Final//, FinalScore
    }

    // Start is called before the first frame update
    void Start()
    {
        Rep1.GetInstance().StartRep1Game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
