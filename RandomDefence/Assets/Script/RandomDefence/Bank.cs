using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{ 
    public class Bank : MonoBehaviour
    {
        enum Cost
        {
            plus_one = 1,
            plus_ten = 2,
            plus_all = 3,
            minus_one = 4,
            minus_ten = 5,
            minus_all = 6
        };

        void Deposit(int cost, int UserCost, Cost costUnit)
        {
            // 비용체크
            // 비용확인
        }

        void WithDrawal(int cost, int UserCost, Cost costUnit)
        {
            // 비용체크
            // 비용확인
        }

        int IncreaseInterest(int cost)
        {
            // 비용확인
            // 횟수 확인
            // 이율테이블 확인

            // 반환할 이율
            int increase = 0;
            return increase;
        }

        int GiveInterest(int UserCost, int increase)
        {
            return (UserCost * increase) + increase;
        }

        void Start()
        {
            BankTable bankTable = new BankTable();

            bankTable.GetDicData(1);
        }
    }
}
