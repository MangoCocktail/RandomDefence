using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LOR;

namespace randomDefence
{
    public class TableManager : SingleTonLazy<TableManager>, IManager
    {
        public enum TableName
        {
            UnitTable = 0,
            LottoTable = 1,
            RelicTable = 2,
            BankTable = 3,
            RunningMatchRewardTable = 4
        };
        
        private Dictionary<TableName, ITable> tableDic;
        
        public void Initialize()
        {
            tableDic = new Dictionary<TableName, ITable>();
            tableDic.Add(TableName.UnitTable, new UnitTable());
            /*tableDic.Add(TableName.LottoTable, new LottoTable());
            tableDic.Add(TableName.RelicTable, new RelicTable());
            tableDic.Add(TableName.BankTable, new BankTable());
            tableDic.Add(TableName.RunningMatchRewardTable, new RunningMatchRewardTable());*/
        }

        public ITable GetTable(TableName tableName)
        {
            tableDic.TryGetValue(tableName, out ITable table);
            return table;
        }


        public UnitTable GetUnitTable()
        {
            return (UnitTable)tableDic[TableName.UnitTable];
        }

        public void SetUnitTable(UnitTable unitTable)
        {
            tableDic[TableName.UnitTable] = unitTable;
        }

        public LottoTable GetLottoTable()
        {
            return (LottoTable)tableDic[TableName.LottoTable];
        }

        public RelicTable GetRelicTable()
        {
            return (RelicTable)tableDic[TableName.RelicTable];
        }

        public BankTable GetBankTable()
        {
            return (BankTable)tableDic[TableName.BankTable];
        }

        public RunningMatchRewardTable GetRunningMatchRewardTable()
        {
            return (RunningMatchRewardTable)tableDic[TableName.RunningMatchRewardTable];
        }
    }
}