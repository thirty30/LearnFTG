using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    public override void InitBattle()
    {
        base.InitBattle();
        this.Avatar.transform.position = new Vector3(-3, 0, 0);
        this.Avatar.transform.forward = new Vector3(1, 0, 0);
    }

    protected override void BattleUpdate()
    {
        this.Avatar.transform.LookAt(Main.GetSingleton().Player2.Avatar.transform.position);
    }

    protected override void SelectCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            this.CharacterID = 1;
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            this.CharacterID = 2;
        }
    }

    protected override void BattleControl()
    {
        if (this.State == EPlayerState.STAND)
        {
            float v = Input.GetAxis("Vertical");
            this.Ani.SetFloat("vertical", v);
            float h = Input.GetAxis("Horizontal");
            this.Ani.SetFloat("horizontal", h);

            Vector3 oppoDir = Main.GetSingleton().Player2.Avatar.transform.forward.normalized;
            //if (Input.GetKey(KeyCode.A) == true)
            if (h < 0)
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
            if (h > 0)
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

            if (Input.GetButtonDown("Fire1") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("boxing1");
            }
            if (Input.GetButtonDown("Fire2") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("kick1");
            }
            if (Input.GetButtonDown("Fire3") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("fireball");
            }
            if (Input.GetKeyDown(KeyCode.J) == true)
            {
                Main.GetSingleton().PlaySound("lola_laugh");
                this.Ani.SetTrigger("taunt");
            }
            if (Input.GetButtonDown("Jump") == true)
            {
                Main.GetSingleton().PlaySound("hitvoice");
                this.Ani.SetTrigger("jump");
            }
        }
    }

    public override void Reset()
    {
        base.Reset();
        this.Avatar.transform.position = new Vector3(-3, 0, 0);
        this.Avatar.transform.forward = new Vector3(1, 0, 0);
    }
}
