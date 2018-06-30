using Pixie.Helpers;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Pixie.Rotation
{
    public class MageFrost : CombatRoutine
    {
        static Stopwatch icyveinsTimer = new Stopwatch();

        public override string Name
        {
            get
            {
                return "Icicle";
            }
        }

        public override string Class
        {
           get
          {
               return "Mage";
            }
        }

        public static void IcyVeinsTimer()
        {
            if (WoW.IsSpellOnCooldown("Icy Veins"))
            {
                icyveinsTimer.Start();
            }

            if (!WoW.IsSpellOnCooldown("Icy Veins"))
            {
                icyveinsTimer.Reset();
            }
            // Log.Write("Current Timer");
            //Log.Write(IcyVeinsTimer.ElapsedMilliseconds.ToString());
        }

        public override void Initialize()
        {
            Log.Write("Welcome to Icicle!", Color.Blue);
        }

        public override void Stop()
        {

        }
        public override void Pulse()
        {
            IcyVeinsTimer();
            // CHECK FOR CHANNELING ON ALL CASTS FOR RAY OF FROST
            if (combatRoutine.Type == RotationType.SingleTarget)  // Do Single Target Stuff here
            {
                /*if ((WoW.PlayerHasTarget || WoW.TargetIsBoss) && WoW.TargetIsEnemy)
                {
                    if (WoW.CanCast("Summon Water Elemental") && !WoW.PlayerHasPet)
                    {
                       WoW.CastSpell("Summon Water Elemental");
                        return;
                    }
                }*/

                if ((WoW.PlayerHasTarget || WoW.TargetIsBoss) && WoW.TargetIsEnemy && WoW.PlayerIsInCombat && WoW.IsSpellInRange("Frostbolt"))
                {

                    //ice_lance,if=buff.fingers_of_frost.react=0&prev_gcd.flurry
                    if (WoW.CanCast("Ice Lance") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerHasBuff("Fingers of Frost") && WoW.PreviousCast == "Flurry" && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Ice Lance");
                        return;
                    }

                    if (WoW.CanCast("Ice Floes") && WoW.PlayerIsMoving && WoW.Talent(2) == 2 && !WoW.PlayerHasBuff("Ice Floes"))
                    {
                        WoW.CastSpell("Ice Floes");
                        return;
                    }

                    if (WoW.CanCast("Ice Barrier") && !WoW.PlayerHasBuff("Ice Barrier") && WoW.PlayerHealthPercent <= 99)
                    {
                        WoW.CastSpell("Ice Barrier");
                        return;
                    }

                    //rune_of_power,if=cooldown.icy_veins.remains<cast_time|charges_fractional>1.9&cooldown.icy_veins.remains>10|buff.icy_veins.up|target.time_to_die.remains+5<charges_fractional*10
                    //if (WoW.Cooldown && WoW.CanCast("Rune of Power") && !WoW.IsMoving && !WoW.PlayerIsChanneling && (!WoW.IsSpellOnCooldown("Icy Veins") || WoW.GetSpellCharges("Rune of Power") >= 1 && WoW.GetPlayerCooldownTimeRemaining("Icy Veins") > 10 && !WoW.IsSpellOnCooldown("Ray of Frost") || WoW.HasBuff("Icy Veins")))
                    //{
                    //    WoW.CastSpellByName("Rune of Power");
                    //    return;
                    // }

                    //icy_veins,if=buff.icy_veins.down
                    if (WoW.UseCooldowns && WoW.CanCast("Icy Veins") && !WoW.PlayerHasBuff("Icy Veins") && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Icy Veins");
                        return;
                    }

                    //frostbolt,if=prev_off_gcd.water_jet
                    if (WoW.CanCast("Frostbolt") && WoW.IsSpellInRange("Frostbolt") && WoW.TargetHasDebuff("Water Jet") && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Frostbolt");
                        return;
                    }

                    //water_jet,if=prev_gcd.frostbolt&buff.fingers_of_frost.stack<(2+artifact.icy_hand.enabled)&buff.brain_freeze.react=0
                    //&& WoW.PreviousCast == "Frostbolt" 
                    /*if (WoW.CanCast("Water Jet") && !WoW.PlayerIsChanneling && WoW.IsSpellInRange("Frostbolt") && WoW.PlayerBuffStacks("Fingers of Frost") < 2 && !WoW.PlayerHasBuff("Brain Freeze"))
                    {
                        WoW.KeyPressRelease(WoW.Keys.G);
                        return;
                    }*/

                    //ray_of_frost,if=buff.icy_veins.up|(cooldown.icy_veins.remains>action.ray_of_frost.cooldown&buff.rune_of_power.down)
                    //if (WoW.CanCast("Ray of Frost") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerIsChanneling && (WoW.HasBuff("Icy Veins") && WoW.HasBuff("Rune of Power") || WoW.GetPlayerCooldownTimeRemaining("Icy Veins") > 60 && WoW.HasBuff("Rune of Power")))
                    // {
                    //     WoW.CastSpellByName("Ray of Frost");
                    //     return;
                    //  }

                    //flurry,if=buff.brain_freeze.react&buff.fingers_of_frost.react=0&prev_gcd.frostbolt
                    //&& WoW.PreviousCast == "Frostbolt" 
                    if (WoW.CanCast("Flurry") && WoW.IsSpellInRange("Frostbolt") && WoW.PlayerHasBuff("Brain Freeze") && !WoW.PlayerHasBuff("Fingers of Frost") && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Flurry");
                        return;
                    }

                    //	frost_bomb,if=debuff.frost_bomb.remains<action.ice_lance.travel_time&buff.fingers_of_frost.react>0
                    if (WoW.CanCast("Frost Bomb") && !WoW.PlayerIsChanneling && WoW.IsSpellInRange("Frostbolt") && WoW.Talent(6) == 1 && WoW.PlayerHasBuff("Fingers of Frost") && (!WoW.TargetHasDebuff("Frost Bomb") || WoW.TargetDebuffTimeRemaining("Frost Bomb") < 2) && WoW.PreviousCast != "Frost Bomb")
                    {
                        WoW.CastSpell("Frost Bomb");
                        return;
                    }

                    //ice_lance,if=buff.fingers_of_frost.react>0&cooldown.icy_veins.remains>10|buff.fingers_of_frost.react>2
                    if (WoW.CanCast("Ice Lance") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerIsChanneling && (WoW.PlayerHasBuff("Fingers of Frost") && (WoW.PlayerCooldownTimeRemaining("Icy Veins") > 10 || !WoW.IsSpellOnCooldown("Icy Veins")) || WoW.PlayerBuffStacks("Fingers of Frost") > 2))
                    {
                        WoW.CastSpell("Ice Lance");
                        return;
                    }

                    if (WoW.CanCast("Frozen Orb") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerIsMoving && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Frozen Orb");
                        return;
                    }

                    if (WoW.CanCast("Ebonbolt") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerHasBuff("Fingers of Frost") && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Ebonbolt");
                        return;
                    }

                    if (WoW.CanCast("Frostbolt") && WoW.IsSpellInRange("Frostbolt") && !WoW.PlayerIsChanneling)
                    {
                        WoW.CastSpell("Frostbolt");
                        return;
                    }
                }
            }
            if (combatRoutine.Type == RotationType.SingleTargetCleave)                // Do Cleave Stuff here     
            {
                if (WoW.PlayerHasTarget && WoW.TargetIsEnemy) //GlobalGCD + spellinrange SPELL!WoW.CanCast("Furious Slash"))
                {

                }
            }
            if (combatRoutine.Type == RotationType.AOE)                // Do AOE Stuff here     
            {
                if (WoW.PlayerHasTarget && WoW.TargetIsEnemy) //GlobalGCD + spellinrange SPELL! &&  WoW.CanCast("Furious Slash"))
                {
                }
            }
        }

        public override Form SettingsForm { get; set; }
    }
}

/*
[AddonDetails.db]
AddonAuthor=ThomasTrain
AddonName=Potato
WoWVersion=Legion - 70000
[SpellBook.db]
Spell,135029,Water Jet,G
Spell,116,Frostbolt,D2
Range,116,Frostbolt
Spell,30455,Ice Lance,D5
Spell,214634,Ebonbolt,D4
Spell,44614,Flurry,D1
Spell,205030,Frozen Touch,none
Spell,205021,Ray of Frost,D7
Spell,112948,Frost Bomb,D8
Spell,31687,Summon Water Elemental,
Spell,84714,Frozen Orb,D3
Spell,12472,Icy Veins,F4
Spell,116011,Rune of Power,S
Spell,108839,Ice Floes,S
Spell,11426,Ice Barrier,X
Buff,44544,Fingers of Frost
Buff,190446,Brain Freeze
Buff,195418,Chain Reaction
Buff,205473,Icicles
Buff,108839,Ice Floes
Buff,12472,Icy Veins
Buff,11426,Ice Barrier
Buff,116011,Rune of Power
Debuff,112948,Frost Bomb
Debuff,135029,Water Jet

*/
