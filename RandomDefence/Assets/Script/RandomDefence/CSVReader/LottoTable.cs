using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class LottoTable : ITable
    {
        private Dictionary<int, List<string>> LottoDic;
        private string file = "LottoList";

        public List<LottoData> lottoTableList;
        public Dictionary<int, LottoData> lottoTableDic;

        public struct LottoData
        {
            public string LottoTypeID;
            public string LottoName;
            public string minPercent;
            public string maxPercent;
        };

        public enum Key
        {
            LottoTypeID = 0,
            LottoName = 1,
            minPercent = 2,
            maxPercent = 3
        };

        void SetLottoTableList()
        {
            List<int> keys = new List<int>(LottoDic.Keys);

            for (int i = 0; i < LottoDic.Count; i++)
            {
                LottoData data = new LottoData();
                data.LottoTypeID = LottoDic[keys[i]][(int)Key.LottoTypeID];
                data.LottoName = LottoDic[keys[i]][(int)Key.LottoName];
                data.minPercent = LottoDic[keys[i]][(int)Key.minPercent];
                data.maxPercent = LottoDic[keys[i]][(int)Key.maxPercent];

                lottoTableList.Add(data);
                if(int.TryParse(data.LottoTypeID, out int result))
                {
                    lottoTableDic.Add(result, data);
                }
            }
        }

        public LottoData GetData(int key)
        {
            lottoTableDic.TryGetValue(key, out LottoData value);
            return value;
        }


        public LottoTable()
        {
            LottoDic = MyCSVReader.Read(file);
            lottoTableList = new List<LottoData>();
            SetLottoTableList();
        }

        public List<string> GetDicData(int idx)
        {
            if (LottoDic.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }
    }
}
