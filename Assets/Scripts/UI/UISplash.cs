using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISplash : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown == true)
        {
            Main.GetSingleton().SetState(EGameState.SELECT);
        }
    }
}
