using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Player player1 = Main.GetSingleton().Player1;
        Player player2 = Main.GetSingleton().Player2;
        if (player1.Avatar == null || player2.Avatar == null)
        {
            this.transform.position = new Vector3(0, 1.5f, -4);
            return;
        }

        float x = (player1.Avatar.transform.position.x + player2.Avatar.transform.position.x) / 2;
        float dis = Vector3.Distance(player1.Avatar.transform.position, player2.Avatar.transform.position);
        if (dis <= 6) //mim distance
        {
            this.transform.position = new Vector3(x, 1.5f, -4);
            return;
        }

        if (dis >= 12)  // max distance
        {
            this.transform.position = new Vector3(x, 1.5f, -7);
            return;
        }

        float rate = (dis - 6) / 6 * 3;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, 1.5f, -4 - rate), 0.1f);
    }
}
