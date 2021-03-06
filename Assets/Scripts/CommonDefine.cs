﻿
public enum EGameState
{
    DEFAULT,

    WAIT,
    SPLASH,     // main ui
    SELECT,     // select player ui
    BATTLE,     // in game
    RESULT,     // win or lose ui
}


public static class ConstData
{
    public const float MoveSpeed = 1.5f;        //player move speed
    public const float MaxDis = 12.0f;          //max distance of 2 players
    public const float MinDis = 6.0f;           //min distance of 2 players
    public const float BorderLine = 12.0f;      //map border position
}

