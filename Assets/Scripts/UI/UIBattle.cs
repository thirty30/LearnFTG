using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    public Text TextRound;
    public Text TextTime;
    public Slider Player1HP;
    public Slider Player2HP;
    public Text Player1Name;
    public Text Player2Name;


    private float mTime;
    private int mRound;
    private int[] mScore;
    private bool mIsStarted;


    public void Init()
    {
        this.mTime = 99.0f;
        this.mRound = 1;
        this.mScore = new int[2] { 0, 0 };
        this.mIsStarted = true;
    }

    public void NextRound()
    {
        this.mTime = 99.0f;
        this.mRound++;
        this.mIsStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.ReFreshPlayer1Info();
        this.ReFreshPlayer2Info();
        this.UpdateTimeAndRound();
        this.CheckDead();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Main.GetSingleton().Player1.HP -= 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Main.GetSingleton().Player2.HP -= 0.3f;
        }
    }

    private void ReFreshPlayer1Info()
    {
        Player player = Main.GetSingleton().Player1;
        if (player.CharacterID == 1)
        {
            Player1Name.text = "Lola";
        }
        else
        {
            Player1Name.text = "Atienza";
        }
        Player1HP.value = player.HP;
    }

    private void ReFreshPlayer2Info()
    {
        Player player = Main.GetSingleton().Player2;
        if (player.CharacterID == 1)
        {
            Player2Name.text = "Lola";
        }
        else
        {
            Player2Name.text = "Atienza";
        }
        Player2HP.value = player.HP;
    }

    private void UpdateTimeAndRound()
    {
        if (this.mIsStarted == false)
        {
            return;
        }

        this.mTime -= Time.deltaTime;
        this.TextTime.text = ((int)this.mTime).ToString();
        this.TextRound.text = "Round" + this.mRound.ToString();
        if (this.mTime > 0)
        {
            return;
        }

        //check win or lose
        Player player1 = Main.GetSingleton().Player1;
        Player player2 = Main.GetSingleton().Player2;
        if (player1.HP >= player2.HP)
        {
            this.mScore[0]++;
        }
        else
        {
            this.mScore[1]++;
        }
        StartCoroutine(this.BattleResult());
    }

    private void CheckDead()
    {
        if (this.mIsStarted == false)
        {
            return;
        }

        if (Main.GetSingleton().Player2.HP <= 0)
        {
            this.mScore[0]++;
            StartCoroutine(this.BattleResult());
            return;
        }

        if (Main.GetSingleton().Player1.HP <= 0)
        {
            this.mScore[1]++;
            StartCoroutine(this.BattleResult());
            return;
        }
    }

    IEnumerator BattleResult()
    {
        this.mIsStarted = false;
        UIWinLose ui = Main.GetSingleton().UIMgr.WinLoseNode.GetComponent<UIWinLose>();
        ui.ShowKO();
        ui.HideSelf(2);

        bool isEnd = false;
        if (this.mScore[0] == 2)
        {
            ui.ShowWinner("Player1");
            isEnd = true;
        }

        if (this.mScore[1] == 2)
        {
            ui.ShowWinner("Player2");
            isEnd = true;
        }

        yield return new WaitForSeconds(2.0f);
        Main.GetSingleton().Player1.Reset();
        Main.GetSingleton().Player2.Reset();

        if (isEnd == true)
        {
            Main.GetSingleton().Player1.Clear();
            Main.GetSingleton().Player2.Clear();
            Main.GetSingleton().SetState(EGameState.SPLASH);
        }
        else
        {
            this.NextRound();
        }
    }
}
