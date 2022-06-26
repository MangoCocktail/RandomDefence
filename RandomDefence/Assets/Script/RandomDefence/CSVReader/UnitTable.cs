using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class UnitTable : ITable
    {
        private Dictionary<int, List<string>> UnitDic;
        private string file = "UnitList";

        public List<UnitData> unitTableList;
        public Dictionary<int, UnitData> unitTableDic;

        public struct UnitData
        {
            public string unitID;
            public string unitName;
            public string unitTribe;
            public string unitHP;
            public string unitPower;
            public string unitObtain;
        };
        public enum Key
        { 
            unitID = 0,
            unitName = 1,
            unitTribe = 2,
            unitHP = 3,
            unitPower = 4,
            unitObtain = 5
        };

        void SetUnitTableList()
        {
            List<int> keys = new List<int>(UnitDic.Keys);

            for (int i = 0; i < UnitDic.Count; i++)
            {
                UnitData data = new UnitData();
                data.unitID = UnitDic[keys[i]][(int)Key.unitID];
                data.unitName = UnitDic[keys[i]][(int)Key.unitName];
                data.unitTribe = UnitDic[keys[i]][(int)Key.unitTribe];
                data.unitHP = UnitDic[keys[i]][(int)Key.unitHP];
                data.unitPower = UnitDic[keys[i]][(int)Key.unitPower];
                data.unitObtain = UnitDic[keys[i]][(int)Key.unitObtain];

                unitTableList.Add(data);
                if(int.TryParse(data.unitID, out int result))
                {
                    unitTableDic.Add(result, data);
                }
            }
        }

        public UnitData GetData(int key)
        {
            /*for(int i = 0; i < unitTableList.Count; i++)
            {
                if(unitID.ToString() == unitTableList[i].unitID)
                {
                    return unitTableList[i];
                }
            }*/

            unitTableDic.TryGetValue(key, out UnitData value);
            return value;
        }

        public UnitTable()
        {
            UnitDic = MyCSVReader.Read(file);
            unitTableList = new List<UnitData>();
            unitTableDic = new Dictionary<int, UnitData>();
            SetUnitTableList();
        }

        //  public Dictionary<int, UnitData> unitTableDic;

        public List<string> GetDicData(int idx)
        {
            if (UnitDic.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }
    }
}