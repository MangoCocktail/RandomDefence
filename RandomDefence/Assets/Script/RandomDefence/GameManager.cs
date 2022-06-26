using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace randomDefence
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Text UnitName;
        [SerializeField] Text UnitTribe;
        [SerializeField] Text UnitHP;
        [SerializeField] Text UnitPower;
        [SerializeField] Text HowToObtain;

        public InputField inputUnitName;
        public InputField inputUnitTribe;
        public InputField inputUnitHP;
        public InputField inputUnitPower;
        public InputField inputUnitHowToObtain;

        UnitTable unitTable;

        UnitTable.UnitData data;

        int key = 1;

        void Awake()
        {
            TableManager.Instance.Initialize();
            unitTable = TableManager.Instance.GetUnitTable();
            data = unitTable.unitTableList[0];
        }
        
        // Start is called before the first frame update
        void Start()
        {
            SetData(key);
        }

        private void OnApplicationQuit()
        {
            MyCSVWriter.Write("UnitList", unitTable.GetType().Name);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClickNext()
        {
            if (key + 1 >= 6)
                key = 1;
            else
                key++;

            SetData(key);
        }

        public void ClickBefore()
        {
            if (key - 1 <= 0)
                key = 5;
            else
                key--;

            SetData(key);
        }

        public void Save()
        {
            data = unitTable.GetData(key);

            if (UnitName.text != inputUnitName.text)    data.unitName = inputUnitName.text;
            if (UnitTribe.text != inputUnitTribe.text)  data.unitTribe = inputUnitTribe.text;
            if (UnitHP.text != inputUnitHP.text) data.unitHP = inputUnitHP.text;
            if (UnitPower.text != inputUnitPower.text) data.unitPower = inputUnitPower.text;
            if (HowToObtain.text != inputUnitHowToObtain.text) data.unitObtain = inputUnitHowToObtain.text;

            unitTable.unitTableList[key - 1] = data;
            unitTable.unitTableDic[key] = data;
        }

        public void SetData(int key)
        {
            data = unitTable.GetData(key);
            UnitName.text = data.unitName;
            UnitTribe.text = data.unitTribe;
            UnitHP.text = data.unitHP;
            UnitPower.text = data.unitPower;
            HowToObtain.text = data.unitObtain;

            inputUnitName.text = data.unitName;
            inputUnitTribe.text = data.unitTribe;
            inputUnitHP.text = data.unitHP;
            inputUnitPower.text = data.unitPower;
            inputUnitHowToObtain.text = data.unitObtain;
        }
    }
}