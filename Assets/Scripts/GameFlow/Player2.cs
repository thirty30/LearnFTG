using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    public override void InitBattle()
    {
        base.InitBattle();
        this.Avatar.transform.position = new Vector3(3, 0, 0);
        this.Avatar.transform.forward = new Vector3(-1, 0, 0);
    }

    protected override void SelectCharacter()
    {
        float h = Input.GetAxis("Joystick2Horizontal");
        
        if (h < 0)
        {
            this.CharacterID = 1;
        }
        if (h > 0)
        {
            this.CharacterID = 2;
        }

        if (Input.GetButtonDown("Joystick2Fire1") == true)
        {
            Main.GetSingleton().SetState(EGameState.BATTLE);
        }
    }

    protected override void BattleControl()
    {
        if (this.State == EPlayerState.STAND)
        {
            float h = Input.GetAxis("Joystick2Horizontal");
            this.Ani.SetFloat("horizontal", h);

            float v = Input.GetAxis("Joystick2Vertical");
            this.Ani.SetFloat("vertical", v);

            Vector3 oppoDir = Main.GetSingleton().Player1.Avatar.transform.forward.normalized;
            if (h > 0)
            {
                if (Vector3.left == oppoDir && this.CalcDis() >= ConstData.MaxDis)
                {
                    return;
                }
                if (this.Avatar.transform.position.x <= -ConstData.BorderLine)
                {
                    return;
                }
                this.Avatar.transform.position += Vector3.left * ConstData.MoveSpeed * Time.deltaTime;
            }
            if (h < 0)
            {
                if (Vector3.right == oppoDir && this.CalcDis() >= ConstData.MaxDis)
                {
                    return;
                }
                if (this.Avatar.transform.position.x >= ConstData.BorderLine)
                {
                    return;
                }
                this.Avatar.transform.position += Vector3.right * ConstData.MoveSpeed * Time.deltaTime;
            }

            if (Input.GetButtonDown("Joystick2Fire1") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("boxing1");
            }

            if (Input.GetButtonDown("Joystick2Fire2") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("kick1");
            }

            if (Input.GetButtonDown("Joystick2Fire3") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("fireball");
            }

            if (Input.GetButtonDown("Joystick2Taunt") == true)
            {
                Main.GetSingleton().PlaySound("atienza_laugh");
                this.Ani.SetTrigger("taunt");
            }

            if (Input.GetButtonDown("Joystick2Jump") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("jump");
            }
        }
    }

    public override void Reset()
    {
        base.Reset();
        this.Avatar.transform.position = new Vector3(3, 0, 0);
        this.Avatar.transform.forward = new Vector3(-1, 0, 0);
    }
}
