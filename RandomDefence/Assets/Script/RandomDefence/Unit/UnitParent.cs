using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class UnitParent : MonoBehaviour
    {
        protected int idx;

        protected UnitTable.UnitData data;
        public virtual void Initialize(int idx, bool isEnemy = false)
        {
            this.idx = idx;
            UnitTable table = TableManager.Instance.GetUnitTable();
            data = table.GetData(this.idx);
        }

        int AttackCalculation()
        {
            return 0;
        }

        void UnitSkill()
        {

        }

        // FSM 만들기
    }
}