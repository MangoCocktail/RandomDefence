using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class RelicTable : ITable
    {
        private Dictionary<int, List<string>> RelicDic;
        private string file = "RelicList";

        public List<RelicData> relicTableList;
        public Dictionary<int, RelicData> relicTableDic;

        
        public struct RelicData
        {
            public string relicID;
            public string relicName;
        };

        public enum Key
        {
            relicID = 0,
            relicName = 1
        };

        void SetRelicTableList()
        {
            List<int> keys = new List<int>(RelicDic.Keys);

            for (int i = 0; i < RelicDic.Count; i++)
            {
                RelicData data = new RelicData();
                data.relicID = RelicDic[keys[i]][(int)Key.relicID];
                data.relicName = RelicDic[keys[i]][(int)Key.relicName];

                relicTableList.Add(data);
                if(int.TryParse(data.relicID, out int result))
                {
                    relicTableDic.Add(result, data);
                }
            }
        }

        public RelicData GetData(int key)
        {
            relicTableDic.TryGetValue(key, out RelicData value);
            return value;
        }

        public RelicTable()
        {
            RelicDic = MyCSVReader.Read(file);
            relicTableList = new List<RelicData>();
            SetRelicTableList();
        }

        public List<string> GetDicData(int idx)
        {
            if (RelicDic.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }
    }
}
