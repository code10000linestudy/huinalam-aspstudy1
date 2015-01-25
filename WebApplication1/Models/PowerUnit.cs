using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PowerUnit : IDisposable, ICloneable
    {
        private static Random random = new Random((int) DateTime.Now.Ticks);

        public string Name { get; set; }

        public int Power { get; set; }

        public int SetPower()
        {
            Power = random.Next(1, Int32.MaxValue / 100);
            return Power;
        }

        public object Clone()
        {
            return new PowerUnit
            {
                Name = Name,
                Power = Power
            };
        }

        public void Dispose()
        {
        }
    }
}