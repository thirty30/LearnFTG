using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerState
{
    FREE,
    SELECT,
    BATTLE
}

public class Player
{
    public EPlayerState State;
    public int CharacterID;

    public GameObject Avatar;
    public float HP = 1.0f;

    public virtual void InitBattle()
    {
        this.State = EPlayerState.BATTLE;
        string path;
        if (this.CharacterID == 1)
        {
            path = "CharacterPrefab/Lola";
        }
        else
        {
            path = "CharacterPrefab/Atienza";
        }
        GameObject obj = Resources.Load<GameObject>(path);
        this.Avatar = GameObject.Instantiate(obj);
    }

    public void Update()
    {
        if (this.State == EPlayerState.SELECT)
        {
            this.SelectCharacter();
        }
        else if (this.State == EPlayerState.BATTLE)
        {
            this.BattleControl();
        }
    }

    protected virtual void SelectCharacter() { }
    protected virtual void BattleControl() { }

    public virtual void Reset()
    {
        this.HP = 1.0f;
    }

    public void Clear()
    {
        this.State = EPlayerState.FREE;
        GameObject.Destroy(this.Avatar);
    }

    protected float CalcDis()
    {
        Player player1 = Main.GetSingleton().Player1;
        Player player2 = Main.GetSingleton().Player2;
        return Vector3.Distance(player1.Avatar.transform.position, player2.Avatar.transform.position);
    }
}
