using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LOR;

namespace randomDefence
{
    public class TableLoader : SingleTonLazy<TableLoader>, IManager, ITable
    {
        private Dictionary<int, List<string>> list;
        private string file = "exp";

        public List<string> GetDicData(int idx)
        {
            if (list.TryGetValue(idx, out List<string> result))
                return result;
            return new List<string>();
        }

        public void Initialize()
        {
            list = MyCSVReader.Read(file);
        }
    }
}