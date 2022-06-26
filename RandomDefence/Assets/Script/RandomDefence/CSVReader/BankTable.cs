using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class BankTable : ITable
    {
        private Dictionary<int, List<string>> BankDic;
        private string file = "BankList";

        public List<BankData> bankTableList;
        public Dictionary<int, BankData> bankTableDic;

        public struct BankData
        {
            public string interestRate;
        };
        public enum Key
        {
            interestRate = 0,
        };

        void SetBankTableList()
        {
            List<int> keys = new List<int>(BankDic.Keys);

            for (int i = 0; i < BankDic.Count; i++)
            {
                BankData data = new BankData();
                data.interestRate = BankDic[keys[i]][(int)Key.interestRate];

                bankTableList.Add(data);
                if(int.TryParse(data.interestRate, out int result))
                {
                    bankTableDic.Add(result, data);
                }
            }
        }

        public BankData GetData(int key)
        {
            bankTableDic.TryGetValue(key, out BankData value);
            return value;
        }


        public BankTable()
        {
            BankDic = MyCSVReader.Read(file);
            bankTableList = new List<BankData>();
            SetBankTableList();
        }

        public List<string> GetDicData(int idx)
        {
            if (BankDic.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }
    }
}