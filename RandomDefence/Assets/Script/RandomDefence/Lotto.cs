using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class Lotto : MonoBehaviour
    {
        enum UnitLottoType
        {
            Cheap = 1,
            Advanced = 2,
            Luxury = 3,
            LifeReversal = 4
        };

        enum GasLottoType
        {
            Small = 1,
            Middle = 2,
            Large = 3
        };

        enum ReinforceType
        {
            ThirtyPercent = 1,
            SixtyPercent = 2,
            EightyPercent = 3
        };

        void LottoConditionCheck()
        {
            // 해금조건과 복권타입 일치확인
            // 비용확인
        }

        int UnitLottoReturn(User user, UnitLottoType unitLottoType)
        {
            // 만약 유물획득 시 유물획득 event 실행

            LottoConditionCheck();
            // User 비용차감

            // 유닛테이블의 랜덤한 인덱스 반환
            int idx = 0;
            return idx;
        }

        int GasLottoReturn(User user, GasLottoType gasLottoType)
        {
            LottoConditionCheck();
            // User 비용차감

            // 가스복권테이블에서 가스복권타입에 맞는 확률에 따라 가스량 반환
            int gas = 0;

            return gas;
        }

        bool ReinforceUnit(User user, ReinforceType reinforceType)
        {
            // 비용차감

            // 해당 확률 bool값으로 성공, 실패 반환
            bool isClear = true;
            return isClear;
        }

        int UnitRankReset()
        {
            // 비용차감

            //유닛랭크테이블 중 랜덤하게 1가지 int값 반환
            int idx = 0;
            return idx;
        }


        void Start()
        {
            LottoTable lottoTable = new LottoTable();

            lottoTable.GetData(1);
        }
    }
}
