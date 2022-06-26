using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace randomDefence
{
    public interface ITable
    {
        List<string> GetDicData(int idx);
    }
}