using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinLose : MonoBehaviour
{
    public Animator KO;
    public Animator Winner;
    public Text TextWinner;

    public void ShowWinner(string aName)
    {
        this.gameObject.SetActive(true);
        this.TextWinner.gameObject.SetActive(true);
        this.KO.Play("KOAnimation");
        this.Winner.Play("WinnerAnimation");
        this.TextWinner.text = "Winner:" + aName;
    }

    public void ShowKO()
    {
        this.gameObject.SetActive(true);
        this.TextWinner.gameObject.SetActive(false);
        this.KO.Play("KOAnimation");
    }

    public void HideSelf(float aTime)
    {
        IEnumerator doHide()
        {
            yield return new WaitForSeconds(aTime);
            this.gameObject.SetActive(false);
        }
        StartCoroutine(doHide());
    }
}



