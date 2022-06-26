using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMatch : MonoBehaviour
{
    enum BattingType
    {

    };
    enum BattingSize
    {

    };

    bool CheckMatchStart(int nowRound)
    {
        string Round = nowRound.ToString();

        if (Round.Contains("3") || Round.Contains("7"))
            return true;
        else
            return false;
    }

    void EnterGame(User user, BattingType battingType, BattingSize battingSize)
    {

    }

    void StartGame()
    {

    }

    void EndGame()
    {

    }

    int GiveCompensation(int rate, BattingType battingType, BattingSize battingSize)
    {
        int cost = 0;
        // 등스와 배팅종류, 배팅크기에 맞게 보상을 반환
        return cost;
    }
}
