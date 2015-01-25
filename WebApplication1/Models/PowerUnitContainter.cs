using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;
using WebApplication1.Models;

// DI 이야기 참고
// 
//http://www.asp.net/mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-dependency-injection

namespace WebApplication1.Modules
{
    public class PowerUnitContainter
    {
        public static PowerUnitContainter Containter { get; set; }

        static PowerUnitContainter()
        {
            Containter = new PowerUnitContainter();
        }

        private List<PowerUnit> _components;

        public PowerUnitContainter()
        {
            _components = new List<PowerUnit>();
        }

        public List<PowerUnit> Components
        {
            get { return _components; }
        }

        public void Add(PowerUnit com)
        {
            Components.Add(com);
        }

        public PowerUnit GetRamdom()
        {
            if (Components.Count == 0)
                return null;

            var ram = new Random((int)DateTime.Now.Ticks);
            int ramInt = ram.Next(0, Components.Count - 1);
            return Components[ramInt];
        }

        //public virtual void Add(PowerUnit com, string name)
        //{
        //    //if (_components.Where(curObj => curObj.Site != null).Any(curObj => curObj.Site.Name.Equals(name)))
        //    //{
        //    //    throw new SystemException("컨테이너에 같은 이름이 존재합니다!");
        //    //}
        //    foreach (var component in _components)
        //    {
        //        var curObj = (PowerUnit)component;
        //        if (curObj.Site != null)
        //        {
        //            if (curObj.Site.Name.Equals(name))
        //                throw new SystemException("컨테이너에 같은 이름이 존재합니다!");
        //        }
        //    }
        //    _components.Add(com);
        //}

        public void Remove(PowerUnit com)
        {
            for (int i = 0; i < Components.Count; ++i)
            {
                if (com.Equals(Components[i]))
                {
                    Components.RemoveAt(i);
                    break;
                }
            }
        }


        public void Dispose()
        {
            foreach (var component in Components)
            {
                component.Dispose();
            }
            Components.Clear();
        }
    }
}