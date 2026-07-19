using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Interfaces
{
    public interface IAttackable
    {
        int Damage { get;  }
        void Attack(IDamageable target);
    }
}
