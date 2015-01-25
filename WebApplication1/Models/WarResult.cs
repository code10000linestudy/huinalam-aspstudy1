using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WarResult
    {
        public PowerUnit Self { get; set; }
        public PowerUnit Target { get; set; }
        public List<string> Message { get; set; }
        public string Result { get; set; }

        public bool IsSelfWin { get; set; }

        public void NormalDamageToTarget()
        {
            Self.SetPower();
            Target.SetPower();

            var self = Self.Clone() as PowerUnit;
            var target = Target.Clone() as PowerUnit;

            Message = new List<string>();
            while (true)
            {
                FIght(self, target);
                Message.Add(PrintPowerStatus(self));
                Message.Add(PrintPowerStatus(target));
                if (self.Power <= 0 || target.Power <= 0) break;
                FIght(target, self);
                Message.Add(PrintPowerStatus(self));
                Message.Add(PrintPowerStatus(target));
                if (self.Power <= 0 || target.Power <= 0) break;
            }

            SetResult(self, target);
        }

        private void SetResult(PowerUnit self, PowerUnit target)
        {
            if (self.Power <= 0)
            {
                Result = String.Format("{0} 쥬금 ㅠㅠ", self.Name);
                IsSelfWin = false;
                return;
            }
            if (target.Power <= 0)
            {
                Result = String.Format("{0} 쥬금 ㅠㅠ", target.Name);
                IsSelfWin = true;
                return;
            }
            if (self.Power <= 0 || target.Power <= 0)
            {
                Result = "공동 패배!";
                IsSelfWin = false;
                return;
            }
        }

        private void FIght(PowerUnit self, PowerUnit target)
        {
            DamageToTarget(self, target);
        }

        private void DamageToTarget(PowerUnit self, PowerUnit target)
        {
            if (self.Power < target.Power / 3)
            {
                int damage = CriticalDamageToTarget(self, target);
                Message.Add(String.Format("{0}가 분노했다~~~!!!! {1}에게 {2}의 치명적인 피해를 입었다.", self.Name, target.Name, damage));
            }
            else
            {
                int damage = NormalDamageToTarget(self, target);
                Message.Add(String.Format("{0}의 공격! {1}이(가) {2}의 피해를 입었다.", self.Name, target.Name, damage));
            }
            
        }

        private string PrintPowerStatus(PowerUnit unit)
        {
            return String.Format("{0}의 체력 : {1}", unit.Name, unit.Power);
        }

        private static Random random = new Random((int) DateTime.Now.Ticks);

        private int NormalDamageToTarget(PowerUnit self, PowerUnit target)
        {
            int damage = random.Next(0, self.Power / 10);
            target.Power -= damage;
            return damage;
        }

        private int CriticalDamageToTarget(PowerUnit self, PowerUnit target)
        {
            int damage = random.Next(0, self.Power * 5);
            target.Power -= damage;
            return damage;
        }
    }
}