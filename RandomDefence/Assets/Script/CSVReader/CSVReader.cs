using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text.RegularExpressions;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    // Read?
    public static List<Dictionary<string, object>> Read(string file)
    {
        var list = new List<Dictionary<string, object>>();

        // TextAsset에 text파일을 담아둘 수 있다.
        TextAsset data = Resources.Load(file) as TextAsset;

        // Regex생성자에의해 정규식 패턴으로 정의된 위치에서 입력 문자열을 부분 문자열의 배열로 분할
        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "")
                continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];

                // TrimStart(char) : 현재 문자열에서 지정된 문자의 선행 항목을 모두제거
                // TrimEnd(char) : 현재 문자열에서 문자의 후행 인스턴스를 모두제거
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;

                // 숫자의 문자열 표현에 해당하는 32비트 부호 있는 정수로 변환
                // 반환 값은 성공여부를 반환
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }

                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}
