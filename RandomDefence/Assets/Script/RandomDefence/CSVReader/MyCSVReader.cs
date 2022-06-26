using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace randomDefence
{
    public class MyCSVReader : MonoBehaviour
    {
        public static Dictionary<int, List<string>> Read(string file)
        {
            var tmp = new Dictionary<int, List<string>>();

            //Debug.Log(Application.dataPath + "/" + "Tables/" + file);

            StreamReader sr = new StreamReader(Application.dataPath + "/" + "Tables/" + file + ".csv");

            //StreamWriter

            bool endOfFile = false;

            while (!endOfFile)
            {
                string data_String = sr.ReadLine();
                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }

                string[] data_values = data_String.Split(',');

                List<string> data_list = new List<string>();

                foreach (var item in data_values)
                {
                    data_list.Add(item);
                }

                if (!int.TryParse(data_values[0], out int result))
                    continue;

                tmp.Add(result, data_list);
            }

            return tmp;
        }
    }
}
