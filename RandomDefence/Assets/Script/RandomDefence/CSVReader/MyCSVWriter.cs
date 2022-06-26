using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace randomDefence
{
    public class MyCSVWriter : MonoBehaviour
    {
        public static void Write(string file, string tableName)
        {
            switch (tableName)
            {
                case "UnitTable":
                    string inputString = "UnitID,UnitName,UnitTribe,UnitHP,UnitPower,UnitObtain\n";

                    UnitTable unitTable = TableManager.Instance.GetUnitTable();

                    for (int i = 1; i <= unitTable.unitTableDic.Count; i++)
                    {
                        UnitTable.UnitData dataByLine = unitTable.GetData(i);

                        inputString = inputString + dataByLine.unitID + ","
                                    + dataByLine.unitName + ","
                                      + dataByLine.unitTribe + ","
                                       + dataByLine.unitHP + ","
                                        + dataByLine.unitPower + ","
                                         + dataByLine.unitObtain + "\n";
                    }
                    File.WriteAllText(Application.dataPath + "/" + "Tables/" + file + ".csv", inputString);

                    break;
                case "LottoTable":
                    break;
                case "RelicTable":
                    break;
                case "BankTable":
                    break;
                case "RunningMatchRewardTable":
                    break;

            }
        }
    }
}