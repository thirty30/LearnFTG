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
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            this.CharacterID = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            this.CharacterID = 2;
        }
    }

    protected override void BattleControl()
    {
        Vector3 oppoDir = Main.GetSingleton().Player1.Avatar.transform.forward.normalized;
        if (Input.GetKey(KeyCode.LeftArrow) == true)
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
        if (Input.GetKey(KeyCode.RightArrow) == true)
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
    }

    public override void Reset()
    {
        base.Reset();
        this.Avatar.transform.position = new Vector3(3, 0, 0);
        this.Avatar.transform.forward = new Vector3(-1, 0, 0);
    }
}
