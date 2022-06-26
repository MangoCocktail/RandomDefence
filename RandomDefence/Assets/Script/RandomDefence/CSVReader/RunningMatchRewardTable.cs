using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public class RunningMatchRewardTable : ITable
    {
        private Dictionary<int, List<string>> RunningMatchRewardDic;
        private string file = "RunningMatchRewardList";

        public List<RunningMatchRewardData> RunningMatchRewardTableList;
        public Dictionary<int, RunningMatchRewardData> RunningMatchRewardTableDic;

        public struct RunningMatchRewardData
        {
            public string interestRate;
        };
        public enum Key
        {
            interestRate = 0,
        };

        void SetRunningMatchRewardTableList()
        {
            List<int> keys = new List<int>(RunningMatchRewardDic.Keys);

            for (int i = 0; i < RunningMatchRewardDic.Count; i++)
            {
                RunningMatchRewardData data = new RunningMatchRewardData();
                data.interestRate = RunningMatchRewardDic[keys[i]][(int)Key.interestRate];

                RunningMatchRewardTableList.Add(data);
                if(int.TryParse(data.interestRate, out int result))
                {
                    RunningMatchRewardTableDic.Add(result, data);
                }
            }
        }

        public RunningMatchRewardData GetData(int key)
        {
            RunningMatchRewardTableDic.TryGetValue(key, out RunningMatchRewardData value);
            return value;
        }

        public RunningMatchRewardTable()
        {
            RunningMatchRewardDic = MyCSVReader.Read(file);
            RunningMatchRewardTableList = new List<RunningMatchRewardData>();
            SetRunningMatchRewardTableList();
        }

        public List<string> GetDicData(int idx)
        {
            if (RunningMatchRewardDic.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }
    }
}