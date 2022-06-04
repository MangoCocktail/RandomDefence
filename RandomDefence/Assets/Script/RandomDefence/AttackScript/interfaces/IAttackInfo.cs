using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDefence.AttackScript.interfaces
{
    interface IAttackInfo
    {
        System.Action OnAttack { get; set; }
        System.Action OnAttacked { get; set; }
    }
    interface IAttackData
    {

    }

}
