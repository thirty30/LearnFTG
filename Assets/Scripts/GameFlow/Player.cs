using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerPhase
{
    FREE,
    SELECT,
    BATTLE
}

public enum EPlayerState
{
    STAND,
    JUMP,
    BOXING,
    KICK,
    FIREBALL,
    DEATH,
    TAUNT,
    CROUCH,
}

public class Player
{
    public EPlayerPhase Phase;
    public EPlayerState State;
    public int CharacterID;

    public GameObject Avatar;
    public float HP = 1.0f;
    public Animator Ani;

    public virtual void InitBattle()
    {
        this.Phase = EPlayerPhase.BATTLE;
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
        this.Ani = this.Avatar.GetComponentInChildren<Animator>();
        this.Avatar.GetComponentInChildren<AnimationEvent>().PlayerData = this;
    }

    public virtual void Update()
    {
        if (this.Phase == EPlayerPhase.SELECT)
        {
            this.SelectCharacter();
        }
        else if (this.Phase == EPlayerPhase.BATTLE)
        {
            this.Avatar.transform.GetChild(0).transform.localRotation = Quaternion.Euler(Vector3.zero);
            Vector3 pos = this.Avatar.transform.GetChild(0).transform.localPosition;
            pos.x = 0;
            pos.z = 0;
            this.Avatar.transform.GetChild(0).transform.localPosition = pos;
            this.BattleUpdate();
            this.BattleControl();
        }
    }

    protected virtual void SelectCharacter() { }
    protected virtual void BattleControl() { }
    protected virtual void BattleUpdate() { }

    public virtual void Reset()
    {
        this.State = EPlayerState.STAND;
        this.Ani.Play("idle");
        this.HP = 1.0f;
    }

    public void Clear()
    {
        this.Phase = EPlayerPhase.FREE;
        GameObject.Destroy(this.Avatar);
    }

    protected float CalcDis()
    {
        Player player1 = Main.GetSingleton().Player1;
        Player player2 = Main.GetSingleton().Player2;
        return Vector3.Distance(player1.Avatar.transform.position, player2.Avatar.transform.position);
    }

    public void Hurt(float aHP)
    {
        this.HP -= aHP;
        if (this.HP > 0)
        {
            Main.GetSingleton().PlaySound("hurt");
            this.Ani.Play("block");
        }
        else
        {
            Main.GetSingleton().PlaySound("die");
            this.Ani.Play("death");
        }
    }
}
