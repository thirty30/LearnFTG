using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject SplashNode;
    public GameObject SelectNode;
    public GameObject BattleNode;
    public GameObject WinLoseNode;

    public void HideAllNodes()
    {
        this.SplashNode.SetActive(false);
        this.SelectNode.SetActive(false);
        this.BattleNode.SetActive(false);
        this.WinLoseNode.SetActive(false);
    }
}
