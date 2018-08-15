using Pixie.GUI;
using Pixie.Helpers;
using Pixie.Rotation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PixelMagic.Rotation
{
    public class WLDestro : CombatRoutine
    {
        public override string Name
        {
            get
            {
                return "Destruction";
            }
        }

        public override string Class
        {
            get
            {
                return "Warlock";
            }
        }

        public override void Initialize()
        {
            Log.Write("Welcome to Destro", Color.Purple);
        }

        public override void Stop()
        {

        }
        public override void Pulse()
        {
            if (WoW.PlayerIsInCombat && WoW.TargetIsEnemy && WoW.IsSpellInRange("Incinerate") && !WoW.PlayerIsChanneling)
            {
                if (WoW.CanCast("UnendingResolve") && (WoW.PlayerHealthPercent <= 40) && WoW.PlayerHealthPercent != 0)
                    WoW.CastSpell("UnendingResolve");
                else if (WoW.CanCast("Healthstone") && (WoW.ItemCount("Healthstone") >= 1 && !WoW.IsItemOnCooldown("Healthstone")) && (WoW.PlayerHealthPercent <= 20 && WoW.PlayerHealthPercent != 0))
                    WoW.CastSpell("Healthstone");
                //else if (WoW.CanCast("DoomGuard") && (WoW.CurrentSoulShards >= 1 && (!WoW.IsSpellOnCooldown("DoomGuard") && WoW.Talent(6) != 1 && WoW.Buff("Lord of Flames")) && ((WoW.PlayerHasBuff("Soul Harvest") && WoW.Talent(4) == 3 || WoW.Talent(4) != 3) && WoW.UseCooldowns))
                //    WoW.CastSpell("DoomGuard");
                //else if (WoW.CanCast("Infernal") && WoW.Level >= 58 && (WoW.CurrentSoulShards >= 1 && DestroWLsmartie.ischeckHotkeysDestroBigPet) && (!WoW.IsSpellOnCooldown("Infernal") && WoW.Talent(6) != 1 && !WoW.PlayerHasDebuff("Lord of Flames")) && ((WoW.PlayerHasBuff("Soul Harvest") && WoW.Talent(4) == 3 || WoW.Talent(4) != 3) && this.UseCooldowns))
                //    WoW.CastSpell("Infernal");
                else if (WoW.CanCast("Soul Harvest") && WoW.UseCooldowns && (!WoW.IsSpellOnCooldown("Soul Harvest") && WoW.CurrentSoulShards >= 4 && WoW.Talent(4) == 3))
                    WoW.CastSpell("Soul Harvest");
                else if (WoW.CanCast("ServiceImp") && WoW.CurrentSoulShards >= 1 && WoW.Talent(6) == 2 && (WoW.UseCooldowns && WoW.PlayerHasBuff("Soul Harvest") && WoW.Talent(4) == 3 || WoW.Talent(4) != 3 && WoW.UseCooldowns))
                    WoW.CastSpell("ServiceImp");
                else if (WoW.CanCast("Berserking") && WoW.UseCooldowns && (!WoW.IsSpellOnCooldown("Berserking") && WoW.PlayerRace == "Troll"))
                    WoW.CastSpell("Berserking");
                else if (WoW.CanCast("Blood Fury") && WoW.UseCooldowns && (!WoW.IsSpellOnCooldown("Blood Fury") && WoW.PlayerRace == "Orc"))
                    WoW.CastSpell("Blood Fury");
                else if (WoW.CanCast("Havoc") && !WoW.IsSpellOnCooldown("Havoc") && WoW.GetAsyncKeyState(Keys.Q) < 0)
                    WoW.CastSpell("Havoc");

                if (combatRoutine.Type == RotationType.SingleTarget || combatRoutine.Type == RotationType.SingleTargetCleave)  // Do Single Target Stuff here
                {
                    if (!WoW.PlayerIsMoving || WoW.PlayerHasBuff("Norgannon's Foresight"))
                    {
                        if (WoW.CanCast("Life Tap") && (!WoW.PlayerHasBuff("Life Tap") && WoW.PlayerHealthPercent >= 40) && WoW.Talent(2) == 3)
                        {
                            WoW.CastSpell("Life Tap");
                            return;
                        }
                        if (WoW.CanCast("Life Tap") && (WoW.CurrentMana <= 40.0 && WoW.PlayerHealthPercent >= 40) && WoW.Talent(2) != 3)
                        {
                            WoW.CastSpell("Life Tap");
                            return;
                        }
                        if (!WoW.PlayerWasLastCastedSpell("Immolate") && WoW.CanPreCast("Immolate") && (!WoW.TargetHasDebuff("Immolate") || WoW.TargetDebuffTimeRemaining("Immolate") <= 4))
                        {
                            WoW.CastSpell("Immolate");
                            return;
                        }
                        if (WoW.CanCast("DimRift") && WoW.PlayerSpellCharges("DimRift") == 3)
                        {
                            WoW.CastSpell("DimRift");
                            return;
                        }
                        if (WoW.CanCast("DimRift") && WoW.PlayerSpellCharges("DimRift") >= 1 && WoW.GetAsyncKeyState(Keys.E) < 0)
                        {
                            WoW.CastSpell("DimRift");
                            return;
                        }
                        if (WoW.CanPreCast("Channel Demonfire") && (!WoW.IsSpellOnCooldown("Channel Demonfire") && WoW.TargetHasDebuff("Immolate")) && (WoW.TargetDebuffTimeRemaining("Immolate") >= 5 && WoW.Talent(7) == 2))
                        {
                            WoW.CastSpell("Channel Demonfire");
                            return;
                        }
                        if (WoW.CanCast("Rain of Fire") && WoW.GetAsyncKeyState(Keys.NumPad2) < 0 && WoW.CurrentSoulShards >= 3 && (WoW.Talent(4) != 3 || WoW.Talent(4) == 3 && WoW.IsSpellOnCooldown("Soul Harvest") && WoW.UseCooldowns || WoW.Talent(4) == 3 && !WoW.IsSpellOnCooldown("Soul Harvest") && !WoW.UseCooldowns))
                        {
                            WoW.CastSpell("Rain of Fire");
                            return;
                        }

                        if (WoW.TargetDebuffTimeRemaining("Immolate") >= 10 && WoW.CanPreCast("Conflagrate"))
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.TargetDebuffTimeRemaining("Immolate") >= 10 && WoW.PlayerSpellCharges("Conflagrate") == 1 && WoW.PlayerWasLastCastedSpell("Conflagrate") && WoW.CanPreCast("Conflagrate"))
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.PlayerHasBuff("Conflagrate") && (WoW.TargetHasDebuff("ChaosBolt") && WoW.CanCast("Conflagrate")) && (WoW.CurrentSoulShards <= 4 && WoW.CanCast("Conflagrate")))
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.CanCast("Conflagrate") && (WoW.PlayerSpellCharges("Conflagrate") == 2 && !WoW.PlayerWasLastCastedSpell("Immolate")) && WoW.CurrentSoulShards <= 4)
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.CanCast("ChaosBolt") && WoW.CurrentSoulShards > 3 && (WoW.UseCooldowns && WoW.PlayerCooldownTimeRemaining("Soul Harvest") >= 5 && WoW.Talent(4) == 3 || WoW.UseCooldowns && WoW.PlayerHasBuff("Soul Harvest") && WoW.Talent(4) == 3 || (!WoW.UseCooldowns || WoW.Talent(4) != 3 && WoW.UseCooldowns)))
                        {
                            WoW.CastSpell("ChaosBolt");
                            return;
                        }
                        //if (WoW.CanCast("DimRift") && !WoW.IsSpellOnCooldown("DimRift") && WoW.PlayerSpellCharges("DimRift") <= 2)
                        //{
                        //    WoW.CastSpell("DimRift");
                        //    return;
                        //}
                        if (WoW.CanCast("ChaosBolt") && WoW.CurrentSoulShards >= 2 && (WoW.UseCooldowns && WoW.PlayerCooldownTimeRemaining("Soul Harvest") >= 5 && WoW.Talent(4) == 3 || WoW.UseCooldowns && WoW.PlayerHasBuff("Soul Harvest") && WoW.Talent(4) == 3 || (!WoW.UseCooldowns || WoW.Talent(4) != 3 && WoW.UseCooldowns)))
                        {
                            WoW.CastSpell("ChaosBolt");
                            return;
                        }
                        if (WoW.CanCast("Incinerate") && WoW.CurrentSoulShards <= 1 || WoW.UseCooldowns && WoW.PlayerCooldownTimeRemaining("Soul Harvest") <= 5 && (WoW.CurrentSoulShards < 4 && WoW.Talent(4) == 3))
                        {
                            WoW.CastSpell("Incinerate");
                            return;
                        }
                        if (WoW.CanCast("Incinerate") && (WoW.TargetHasDebuff("ChaosBolt") && WoW.TargetDebuffTimeRemaining("ChaosBolt") >= 2) && WoW.CurrentSoulShards <= 3)
                        {
                            WoW.CastSpell("Incinerate");
                            return;
                        }

                    }
                }

                if (WoW.PlayerIsMoving || WoW.PlayerHasBuff("Norgannon's Foresight"))
                {
                    //if (WoW.CanCast("DimRift"))
                    //{
                    //    WoW.CastSpell("DimRift");
                    //    return;
                    //}
                    if (WoW.CanCast("Conflagrate"))
                    {
                        WoW.CastSpell("Conflagrate");
                        return;
                    }
                }

                if (combatRoutine.Type == RotationType.AOE)                // Do aoe stuff here     
                {
                    if (!WoW.PlayerIsMoving || WoW.PlayerHasBuff("Norgannon's Foresight"))
                    {
                        if (WoW.CanCast("Life Tap") && (!WoW.PlayerHasBuff("Life Tap") && WoW.PlayerHealthPercent >= 40) && WoW.Talent(2) == 3)
                        {
                            WoW.CastSpell("Life Tap");
                            return;
                        }
                        if (WoW.CanCast("Life Tap") && (WoW.CurrentMana <= 40.0 && WoW.PlayerHealthPercent >= 40) && WoW.Talent(2) != 3)
                        {
                            WoW.CastSpell("Life Tap");
                            return;
                        }
                        if ((!WoW.TargetHasDebuff("Immolate") || WoW.TargetDebuffTimeRemaining("Immolate") <= 4) && (!WoW.PlayerWasLastCastedSpell("Immolate")) && WoW.CanCast("Immolate"))
                        {
                            WoW.CastSpell("Immolate");
                            return;
                        }
                        if (WoW.CanCast("DimRift") && WoW.PlayerSpellCharges("DimRift") == 3)
                        {
                            WoW.CastSpell("DimRift");
                            return;
                        }
                        if (WoW.CanCast("DimRift") && WoW.PlayerSpellCharges("DimRift") >= 1 && !WoW.PlayerHasBuff("Lessons of Space-Time"))
                        {
                            WoW.CastSpell("DimRift");
                            return;
                        }
                        if (WoW.CanCast("Channel Demonfire") && (!WoW.IsSpellOnCooldown("Channel Demonfire") && WoW.TargetHasDebuff("Immolate")) && (WoW.TargetDebuffTimeRemaining("Immolate") >= 5 && WoW.Talent(7) == 2))
                        {
                            WoW.CastSpell("Channel Demonfire");
                            return;
                        }
                        if (WoW.CanCast("Rain of Fire") && WoW.CurrentSoulShards >= 3 && (WoW.Talent(4) != 3 || WoW.Talent(4) == 3 && WoW.IsSpellOnCooldown("Soul Harvest") && WoW.UseCooldowns || WoW.Talent(4) == 3 && !WoW.IsSpellOnCooldown("Soul Harvest") && !WoW.UseCooldowns))
                        {
                            WoW.CastSpell("Rain of Fire");
                            return;
                        }
                        if (WoW.TargetDebuffTimeRemaining("Immolate") >= 10 && WoW.CanCast("Conflagrate"))
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.TargetDebuffTimeRemaining("Immolate") >= 10 && WoW.PlayerSpellCharges("Conflagrate") == 1 && WoW.PlayerWasLastCastedSpell("Conflagrate") && WoW.CanCast("Conflagrate"))
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.CanCast("Conflagrate") && (WoW.PlayerSpellCharges("Conflagrate") == 2 && !WoW.PlayerWasLastCastedSpell("Immolate")) && WoW.CurrentSoulShards <= 4)
                        {
                            WoW.CastSpell("Conflagrate");
                            return;
                        }
                        if (WoW.CanCast("DimRift") && !WoW.IsSpellOnCooldown("DimRift") && WoW.PlayerSpellCharges("DimRift") <= 2)
                        {
                            WoW.CastSpell("DimRift");
                            return;
                        }
                        if (WoW.CanCast("Incinerate") && WoW.CurrentSoulShards <= 1 || WoW.UseCooldowns && WoW.PlayerCooldownTimeRemaining("Soul Harvest") <= 5 && (WoW.CurrentSoulShards < 4 && WoW.Talent(4) == 3))
                        {
                            WoW.CastSpell("Incinerate");
                            return;
                        }
                        if (WoW.CanCast("Incinerate") && WoW.CurrentSoulShards <= 3)
                        {
                            WoW.CastSpell("Incinerate");
                            return;
                        }
                    }
                    if (WoW.PlayerIsMoving || WoW.PlayerHasBuff("Norgannon's Foresight"))
                        return;
                    if (WoW.CanCast("Rain of Fire") && WoW.CurrentSoulShards >= 3 && (WoW.Talent(4) != 3 || WoW.Talent(4) == 3 && WoW.IsSpellOnCooldown("Soul Harvest") && WoW.UseCooldowns || WoW.Talent(4) == 3 && !WoW.IsSpellOnCooldown("Soul Harvest") && !WoW.UseCooldowns))
                        WoW.CastSpell("Rain of Fire");
                    else if (WoW.CanCast("DimRift"))
                    {
                        WoW.CastSpell("DimRift");
                    }
                    else
                    {
                        if (WoW.CanCast("Conflagrate"))
                            return;
                        WoW.CastSpell("Conflagrate");
                    }


                }
            }
        }

        public override Form SettingsForm { get; set; }
    }
}

/*
[AddonDetails.db]
AddonAuthor=zan
AddonName=blub
WoWVersion=Legion - 70000
[SpellBook.db]
Range,29722,Incinerate,

Spell,29722,Incinerate,
Spell,116858,ChaosBolt,
Spell,17962,Conflagrate,
Spell,348,Immolate,
Spell,42223,Rain of Fire,
Spell,80240,Havoc,
Spell,196586,DimRift,
Spell,1454,Life Tap,
Spell,111859,ServiceImp,
Spell,33702,Blood Fury,
Spell,26297,Berserking,
Spell,104773,UnendingResolve,
Spell,196098,Soul Harvest,
Spell,5512,Healthstone,
Spell,196447,Channel Demonfire,

Item,5512,Healthstone,

Charge,196586,DimRift
Charge,17962,Conflagrate

Buff,196546,Conflagrate
Buff,196098,Soul Harvest
Buff,1454,Life Tap
Buff,236174,Lessons of Space-Time
Buff,236373,Norgannon's Foresight

Debuff,253092,ChaosBolt
Debuff,348,Immolate
*/

