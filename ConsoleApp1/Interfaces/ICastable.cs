using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp1.Interfaces
{
    public interface ICastable
    {
        public void Use(Mage mage, Character character);
    }
}
