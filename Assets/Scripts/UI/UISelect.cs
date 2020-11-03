using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : MonoBehaviour
{
    public GameObject RedPlayer1;
    public GameObject BluePlayer1;
    public GameObject RedPlayer2;
    public GameObject BluePlayer2;

    // Start is called before the first frame update
    void Start()
    {
        this.RedPlayer1.SetActive(true);
        this.BluePlayer1.SetActive(false);
        this.RedPlayer2.SetActive(false);
        this.BluePlayer2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Main.GetSingleton().Player1.CharacterID == 1)
        {
            this.RedPlayer1.SetActive(true);
            this.BluePlayer1.SetActive(false);
        }
        else if (Main.GetSingleton().Player1.CharacterID == 2)
        {
            this.RedPlayer1.SetActive(false);
            this.BluePlayer1.SetActive(true);
        }

        if (Main.GetSingleton().Player2.CharacterID == 1)
        {
            this.RedPlayer2.SetActive(true);
            this.BluePlayer2.SetActive(false);
        }
        else if (Main.GetSingleton().Player2.CharacterID == 2)
        {
            this.RedPlayer2.SetActive(false);
            this.BluePlayer2.SetActive(true);
        }
    }
}
