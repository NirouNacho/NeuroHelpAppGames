using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRecorrido : MonoBehaviour
{
    public enum GameStateRep
    {
        InicioRec1, Rec1, InicioRec2, Rec2, InicioRec3, Recp3, FinalRec//, FinalScore
    }

    // Start is called before the first frame update
    void Start()
    {
        Reco1.GetInstance().StartReco1Game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
