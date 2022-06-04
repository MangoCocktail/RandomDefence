using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomDefence.AttackScript.interfaces;

public class AttackInfoBase : IAttackInfo
{
    public System.Action OnAttack { get; set; }
    public System.Action<IAttackData> OnAttacked { get; set; }
}
