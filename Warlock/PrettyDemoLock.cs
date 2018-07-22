﻿using Nerdz.Helpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nerdz.Rotation
{
    public class PrettyDemoLock : CombatRoutine
    {
        #region Startup

        #region Initialization

        public override string Name
        {
            get { return "PrettyDemolock - version:" + _versionnumber; }
        }

        // Please set correct class here!
        public override string Class
        {
            get { return "Warlock"; }
        }

        public override Form SettingsForm { get; set; }

        public override void Initialize()
        {
            WriteLogging();

            Interface = new PrettyDemoLockInterface();
            SettingsForm = Interface;

            BuildInterface();
        }

        int _ImpOrder;
        private static bool _ForceImp2DC;
        private static bool _ForceImp;
        private static bool _lynxdebugger;
        private static string _lynxdebuggerstring = "None";
        private static bool _isOpenerDone;
        private static bool _ForceAoE;
        private static readonly string _versionnumber = "4.0.2 (7.3.0) Return to CS";
        private PrettyDemoLockInterface Interface { get; set; }


        #endregion

        #region Logging

        private static void WriteLogging()
        {
            _lynxdebugger = true;

            WriteLog("PrettyDemoLock profile by zan - v" + _versionnumber);
            WriteLog("Make sure to properly enable all required settings!");
          
        }

        private void LogWrite(string spell)
        {
            switch (spell)
            {
                case "Spell": Log.Write(String.Format("Example Stuff, HP is at : {0}%", WoW.PlayerHealthPercent), Color.DarkViolet); return;
                default: return;
            }
        }

        private static void WriteLog(string message)
        {
            Log.Write("lynx: " + message, Color.SaddleBrown);
        }

        #endregion

        #region Build Interface

        private void BuildInterface()
        {
            //Save Button & Picture Box
            Interface.PictureBox1.Image = Interface.ExampleLogo;
            Interface.buttonsaveandclose.Click += SaveAndClose_click;

            //Combobox Example
            Interface.ExampleCombo.Text = ExampleCombo;
            Interface.ExampleCombo.SelectedIndexChanged += ExampleCombo_SelectedIndexChanged;

            //Number Box Up Down Example
            Interface.ExampleNum.Text = ExampleNum;
            Interface.ExampleNum.ValueChanged += ExampleNum_ValueChanged;

            //CheckBox Example
            Interface.AutoAoECheck.Checked = AutoAoECheck;
            Interface.AutoAoECheck.CheckedChanged += AutoAoECheck_CheckedChanged;
        }

        #endregion

        #endregion

        #region Enums

        private enum Auras
        {
            DemonicCore,                   
            DemonicCalling,
            DemonicPower,
            Doom,
            NetherPortal
        }

        private enum Spells
        {
            DemonicStrength,
            BilescourgeBombers,
            CallDreadstalkers,
            ShadowBolt,
            Demonbolt,
            PowerSiphon,
            SoulStrike,
            SummonVilefiend,
            GrimoireFelguard,
            UnendingResolve,
            Healthstone,
            SummonDemonicTyrant,
            HandofGuldan,
            Implosion,
            DemonicCore,
            DrainLife,
            Doom,
            DarkPact,
            NetherPortal,
            BloodFury

        }

        private enum Item
        {
            Healthstone
        }

        private enum Talent
        {
            Dreadlash,
            DemonicStrength,
            BilescourgeBombers,
            DemonicCalling,
            PowerSiphon,
            Doom,
            DemonSkin,
            BurningRush,
            DarkPact,
            FromTheShadows,
            SoulStrike,
            SummonVilefiend,
            Darkfury,
            MortalCoil,
            DemonicCircle,
            SoulConduit,
            InnerDemons,
            GrimoireFelguard,
            SacrificedSouls,
            DemonicComsumption,
            NetherPortal
        }

        private enum Unit
        {
            Astral,
            Chi,
            ComboPoints,
            Energy,
            Focus,
            Holy,
            Maelstrom,
            Mana,
            Pain,
            Power,
            Rage,
            Runes,
            Runic,
            SoulShards,
            TargetHP,
            PlayerHP,
            EnemyCount
        }

        private enum Race
        {
            Tauren,
            Troll,
            Human,
            Dwarf,
            NightElf,
            Gnome,
            Draenei,
            Pandaren,
            Orc,
            Scourge,
            BloodElf,
            Goblin,
            Worgen
        }

        private enum Status
        {
            HasTarget,
            InCombat,
            TargetEnemy,
            TargetBoss,
            HasPet,
            IsCasting,
            IsChanneling,
            IsMoving,
            TargetFriend,
            TargetVisible
        }

        private enum Bonus
        {
            T19Two,
            T19Four,
            T20Two,
            T20Four,
            T21Two,
            T21Four
        }

        private enum Precheck
        {
            Combat,
            SoulStrike
        }

        #endregion

        #region Wrappers

        #region Item

        private static bool HasItem(Item item)
        {
            switch (item)
            {
                
                default: return false;
            }
        }

        #endregion

        #region Talents

        private static bool HasTalent(Talent talent)
        {
            switch (talent)
            {
                case Talent.Dreadlash: return WoW.IsTalentAvailable("Dreadlash");
                case Talent.DemonicStrength: return WoW.IsTalentAvailable("Demonic Strength");
                case Talent.BilescourgeBombers: return WoW.IsTalentAvailable("Bilescourge Bombers");
                case Talent.DemonicCalling: return WoW.IsTalentAvailable("Demonic Calling");
                case Talent.PowerSiphon: return WoW.IsTalentAvailable("Power Siphon");
                case Talent.Doom: return WoW.IsTalentAvailable("Doom");
                case Talent.DemonSkin: return WoW.IsTalentAvailable("Demon Skin");
                case Talent.BurningRush: return WoW.IsTalentAvailable("Burning Rush");
                case Talent.DarkPact: return WoW.IsTalentAvailable("Dark Pact");
                case Talent.FromTheShadows: return WoW.IsTalentAvailable("From the Shadows");
                case Talent.SoulStrike: return WoW.IsTalentAvailable("Soul Strike");
                case Talent.SummonVilefiend: return WoW.IsTalentAvailable("Summon Vilefiend");
                case Talent.Darkfury: return WoW.IsTalentAvailable("Dark Fury");
                case Talent.MortalCoil: return WoW.IsTalentAvailable("Mortal Coil");
                case Talent.DemonicCircle: return WoW.IsTalentAvailable("Demonic Circle");
                case Talent.SoulConduit: return WoW.IsTalentAvailable("Soul Conduit");
                case Talent.InnerDemons: return WoW.IsTalentAvailable("Inner Demons");
                case Talent.GrimoireFelguard: return WoW.IsTalentAvailable("Grimoire: Felguard");
                case Talent.SacrificedSouls: return WoW.IsTalentAvailable("Sacrificed Souls");
                case Talent.DemonicComsumption: return WoW.IsTalentAvailable("Demonic Consumption");
                case Talent.NetherPortal: return WoW.IsTalentAvailable("Nether Portal");
               
                default: return false;
            }
        }

        #endregion

        #region Auras

        private static bool HasAura(Auras aura)
        {
            switch (aura)
            {
                case Auras.DemonicCore: return WoW.PlayerHasBuff("Demonic Core");
                case Auras.DemonicCalling: return WoW.PlayerHasBuff("Demonic Calling");               
                case Auras.DemonicPower: return WoW.PlayerHasBuff("Demonic Power");
                case Auras.Doom: return WoW.TargetHasDebuff("Doom");
                case Auras.NetherPortal: return WoW.PlayerHasBuff("Nether Portal");
                default: return false;
            }
        }

        private static int AuraRemaining(Auras aura)
        {
            switch (aura)
            {
                case Auras.DemonicCore: return WoW.PlayerBuffTimeRemaining("Demonic Core");
                case Auras.DemonicCalling: return WoW.PlayerBuffTimeRemaining("Demonic Calling");
                case Auras.DemonicPower: return WoW.PlayerBuffTimeRemaining("Demonic Power");
                case Auras.Doom: return WoW.TargetDebuffTimeRemaining("Doom");
                case Auras.NetherPortal: return WoW.PlayerBuffTimeRemaining("Nether Portal");
                //case Auras.ExampleCooldown: return WoW.PlayerCooldownTimeRemaining("SpellName");
                default: return 0;
            }
        }

        private static int AuraStacks(Auras aura)
        {
            switch (aura)
            {
               case Auras.DemonicCore: return WoW.PlayerBuffStacks("Demonic Core");
                default: return 0;
            }
        }

        private static int SpellCD(Spells spell)
        {
            switch (spell)
            {
                case Spells.DemonicStrength: return WoW.PlayerCooldownTimeRemaining("Demonic Strength");
                case Spells.BilescourgeBombers: return WoW.PlayerCooldownTimeRemaining("Bilescourge Bombers");
                case Spells.CallDreadstalkers: return WoW.PlayerCooldownTimeRemaining("Call Dreadstalkers");
                case Spells.SoulStrike: return WoW.PlayerCooldownTimeRemaining("Soul Strike");
                case Spells.PowerSiphon: return WoW.PlayerCooldownTimeRemaining("Power Siphon");
                case Spells.SummonVilefiend: return WoW.PlayerCooldownTimeRemaining("Grimoire: Felguard");
                case Spells.GrimoireFelguard: return WoW.PlayerCooldownTimeRemaining("Power Siphon");
                case Spells.UnendingResolve: return WoW.PlayerCooldownTimeRemaining("UnendingResolve");
                case Spells.SummonDemonicTyrant: return WoW.PlayerCooldownTimeRemaining("Summon Demonic Tyrant");
                case Spells.DarkPact: return WoW.PlayerCooldownTimeRemaining("Dark Pact");
                case Spells.NetherPortal: return WoW.PlayerCooldownTimeRemaining("Nether Portal");

                default: return 0;
            }
        }

        private static bool OnCooldown(Spells spellsCd)
        {
            switch (spellsCd)
            {
                case Spells.DemonicStrength: return WoW.IsSpellOnCooldown("Demonic Strength");
                case Spells.BilescourgeBombers: return WoW.IsSpellOnCooldown("Bilescourge Bombers");
                case Spells.CallDreadstalkers: return WoW.IsSpellOnCooldown("Call Dreadstalkers");
                case Spells.SoulStrike: return WoW.IsSpellOnCooldown("Soul Strike");
                case Spells.PowerSiphon: return WoW.IsSpellOnCooldown("Power Siphon");
                case Spells.SummonVilefiend: return WoW.IsSpellOnCooldown("Summon Vilefiend");
                case Spells.GrimoireFelguard: return WoW.IsSpellOnCooldown("Grimoire: Felguard");
                case Spells.UnendingResolve: return WoW.IsSpellOnCooldown("UnendingResolve");
                case Spells.SummonDemonicTyrant: return WoW.IsSpellOnCooldown("Summon Demonic Tyrant");
                case Spells.DarkPact: return WoW.IsSpellOnCooldown("Dark Pact");
                case Spells.NetherPortal: return WoW.IsSpellOnCooldown("Nether Portal");
                case Spells.BloodFury: return WoW.IsSpellOnCooldown("Blood Fury");
                default: return false;
            }
        }


        private static int SpellCharges(Spells spell)
        {
            switch (spell)
            {
                //case Spells.LifeTap: return WoW.PlayerSpellCharges("LifeTap");
                
                default: return 0;
            }
        }

        #endregion

        #region Settings

        private static string ExampleCombo
        {
            get { var ExampleCombo = ConfigFile.ReadValue("RoutineName", "ExampleCombo"); try { return ExampleCombo; } catch (FormatException) { return ""; } }
            set { ConfigFile.WriteValue("RoutineName", "ExampleCombo", value); }
        }

        private void ExampleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExampleCombo = Convert.ToString(Interface.ExampleCombo.SelectedItem);
        }

        private static string ExampleNum
        {
            get { var ExampleNum = ConfigFile.ReadValue("RoutineName", "ExampleNum"); try { return ExampleNum; } catch (FormatException) { return ""; } }
            set { ConfigFile.WriteValue("RoutineName", "ExampleNum", value); }
        }

        private void ExampleNum_ValueChanged(object sender, EventArgs e)
        {
            ExampleNum = Convert.ToString(Interface.ExampleNum.Value);
        }

        private static bool AutoAoECheck
        {
            get { var AutoAoECheck = ConfigFile.ReadValue("RoutineName", "AutoAoECheck").Trim(); return AutoAoECheck != "" && Convert.ToBoolean(AutoAoECheck); }
            set { ConfigFile.WriteValue("DestroLock", "AutoAoECheck", value.ToString()); }
        }

        private void AutoAoECheck_CheckedChanged(object sender, EventArgs e)
        {
            AutoAoECheck = Interface.AutoAoECheck.Checked;
        }

        private void SaveAndClose_click(object sender, EventArgs e)
        {
            SettingsForm.Close();
        }

        private static string ExampleComboConfig
        {
            get { return ConfigFile.ReadValue<string>("RoutineName", "ExampleCombo"); }
        }
        private static int ExampleNumConfig
        {
            get { return ConfigFile.ReadValue<int>("RoutineName", "ExampleNum"); }
        }
        private static bool AutoAoECheckConfig
        {
            get { return ConfigFile.ReadValue<bool>("DestroLock", "AutoAoECheck"); }
        }

        #endregion

        #region PreChecks

        //You can Use PreChecks for Spells with Long conditions to keep the rotation part of your routine Clean
        private static bool PreCheck(Precheck ability)
        {
            switch (ability)
            {
                case Precheck.Combat: return (WoW.PlayerHasTarget || WoW.TargetIsBoss) && WoW.PlayerIsInCombat && WoW.TargetIsEnemy && WoW.IsSpellInRange("Shadow Bolt") && WoW.PlayerHealthPercent > 0 && !WoW.PlayerIsChanneling;
                case Precheck.SoulStrike: return (HasTalent(Talent.SoulStrike) && !OnCooldown(Spells.SoulStrike) && Power(Unit.SoulShards) < 5);

                default:
                    return false;
            }
        }

        #endregion

        #region System

        private bool SpellCast(string spell, bool condition = true)
        {
            if (!condition) { return false; }

            if (WoW.CanCast(spell))
            {
                WoW.CastSpell(spell);
                LogWrite(spell);
                return true;
            }

            return false;
        }

        //private bool SpellCastGCD(string spell, bool condition = true)
        //{
        //    if (!condition) { return false; }

        //    //if (WoW.CanCast(spell))
        //    if (WoW.CanCast(spell, true, true, false, false, false, true) && !WoW.IsSpellOnGCD("Immolate") && WoW.IsSpellInRange("Immolate"))
        //    {
        //        WoW.CastSpell(spell);
        //        LogWrite(spell);
        //        return true;
        //    }

        //    return false;
        //}

        private static float CurrentGlobalCooldown
        {
            get { return Convert.ToSingle(150f / (1 + (WoW.PlayerHastePercent / 100f))) > 75f ? Convert.ToSingle(150f / (1 + (WoW.PlayerHastePercent / 100f))) : 75f; }
        }

        private static int Power(Unit unit)
        {
            switch (unit)
            {
                case Unit.Astral: return WoW.CurrentAstralPower;
                case Unit.Chi: return WoW.CurrentChi;
                case Unit.ComboPoints: return WoW.CurrentComboPoints;
                case Unit.Energy: return WoW.CurrentEnergy;
                case Unit.Focus: return WoW.CurrentFocus;
                case Unit.Holy: return WoW.CurrentHolyPower;
                case Unit.Maelstrom: return WoW.CurrentMaelstrom;
                case Unit.Mana: return WoW.CurrentMana;
                case Unit.Pain: return WoW.CurrentPain;
                case Unit.Power: return WoW.CurrentPower;
                case Unit.Rage: return WoW.CurrentRage;
                case Unit.Runes: return WoW.CurrentRunes;
                case Unit.Runic: return WoW.CurrentRunicPower;
                case Unit.SoulShards: return WoW.CurrentSoulShards;
                case Unit.TargetHP: return WoW.TargetHealthPercent;
                case Unit.PlayerHP: return WoW.PlayerHealthPercent;
                case Unit.EnemyCount: return WoW.CurrentEnemyUnitCount;
                default: return 0;
            }
        }

        private static bool PlayerRace(Race race)
        {
            switch (race)
            {
                case Race.Tauren: return WoW.PlayerRace == "Tauren";
                case Race.Troll: return WoW.PlayerRace == "Troll";
                case Race.Human: return WoW.PlayerRace == "Human";
                case Race.Dwarf: return WoW.PlayerRace == "Dwarf";
                case Race.NightElf: return WoW.PlayerRace == "NightElf";
                case Race.Gnome: return WoW.PlayerRace == "Gnome";
                case Race.Draenei: return WoW.PlayerRace == "Draenei";
                case Race.Pandaren: return WoW.PlayerRace == "Pandaren";
                case Race.Orc: return WoW.PlayerRace == "Orc";
                case Race.Scourge: return WoW.PlayerRace == "Scourge";
                case Race.BloodElf: return WoW.PlayerRace == "BloodElf";
                case Race.Goblin: return WoW.PlayerRace == "Goblin";
                case Race.Worgen: return WoW.PlayerRace == "Worgen";
                default: return false;
            }
        }

        private static bool Player(Status player)
        {
            switch (player)
            {
                case Status.HasTarget: return WoW.PlayerHasTarget;
                case Status.InCombat: return WoW.PlayerIsInCombat;
                case Status.TargetEnemy: return WoW.TargetIsEnemy;
                case Status.TargetBoss: return WoW.TargetIsBoss;
                case Status.HasPet: return WoW.PlayerHasPet;
                case Status.IsCasting: return WoW.PlayerIsCasting;
                case Status.IsChanneling: return WoW.PlayerIsChanneling;
                case Status.IsMoving: return WoW.PlayerIsMoving;
                case Status.TargetFriend: return WoW.TargetIsFriend;
                case Status.TargetVisible: return WoW.TargetIsVisible;
                default: return false;
            }
        }

        private static bool HasSet(Bonus set)
        {
            switch (set)
            {
                //case Bonus.T19Two: return WoW.SetBonus(19) >= 2;
                //case Bonus.T19Four: return WoW.SetBonus(19) >= 4;
                //case Bonus.T20Two: return WoW.SetBonus(20) >= 2;
                //case Bonus.T20Four: return WoW.SetBonus(20) >= 4;
                //case Bonus.T21Two: return WoW.SetBonus(21) >= 2;
                //case Bonus.T21Four: return WoW.SetBonus(21) >= 4;

                default:
                    return false;
            }
        }

        //private static int EnergyMax
        //{
        //    get
        //    {
        //        if (HasTalent(Talent.Vigor))
        //        {
        //            return 150;
        //        }
        //        return 100;
        //    }
        //}
        //private static int ComboPointsMax
        //{
        //    get
        //    {
        //        if (HasTalent(Talent.DeeperStratagem))
        //        { return 6; }                
        //        return 5;
        //    }
        //}
        //private static int ComboPointsDeficit
        //{
        //    get { return ComboPointsMax - Power(Unit.ComboPoints); }
        //}
        //private static int ComboPointsSpend
        //{
        //    get
        //    {
        //        if (HasTalent(Talent.DeeperStratagem))
        //        { return 6; }
        //        return 5;
        //    }
        //}
        //actions.precombat +=/ variable,name = stealth_threshold,value = (65 + talent.vigor.enabled * 35 + talent.master_of_shadows.enabled * 10 + variable.ssw_refund)
      
        //private static int EnergyDeficit
        //{
        //    get
        //    {
        //        return EnergyMax - Power(Unit.Energy);
        //    }
        //}
               
     
        private static readonly Stopwatch CombatTimer = new Stopwatch();
       
        //private static TimeSpan CombatTS = CombatTimer.Elapsed;
       
        private static double CombatSec
        {
            get { return CombatTimer.Elapsed.TotalSeconds; }
        }

        private static double tick_time
        {
            get { return (2 * (1 - (WoW.PlayerHastePercent / 100))); }
        }


        public static void AoECheck()
        {
            short key = WoW.GetAsyncKeyState(Keys.NumPad2);
            if ((key & 0x8000) != 0)
            {
                _ForceAoE = true;
            }

            else
            {
                _ForceAoE = false;
            }
        }

        #endregion

        #endregion

        #region Rotation

        #region Default

        public void Default()
        {
            #region Logging

            const string msg = "Default rotation running.";

            if (_lynxdebugger && msg != _lynxdebuggerstring)
            {
                Log.Write(msg, Color.Blue);
                _lynxdebuggerstring = msg;
            }

            #endregion

            //Log.Write(String.Format("Bilescourge Bombers : " + WoW.IsSpellAvailable("Bilescourge Bombers")), Color.Blue);
            //Log.Write(String.Format("Doom : " + WoW.IsSpellAvailable("Doom")), Color.Blue);
            //Log.Write(String.Format("Soul Strike : " + WoW.IsSpellAvailable("Soul Strike")), Color.Blue);
            //Log.Write(String.Format("Summon Vilefiend Available: " + WoW.IsSpellAvailable("Summon Vilefiend")), Color.Blue);
            //Log.Write(String.Format("Summon Vilefiend OnCooldown: " + WoW.IsSpellOnCooldown("Summon Vilefiend")), Color.Blue);
            //Log.Write(String.Format("Summon Vilefiend CD Remaining: " + WoW.PlayerCooldownTimeRemaining("Summon Vilefiend")), Color.Blue);
           // Log.Write(String.Format("IsSpellOnCooldown Soul Strike : " + WoW.IsSpellOnCooldown("Soul Strike")), Color.Blue);
            Log.Write(String.Format("Current Soulshards : " + WoW.CurrentSoulShards), Color.Blue);
            //def->add_action("summon_vilefiend,if=cooldown.summon_demonic_tyrant.remains>30|(cooldown.summon_demonic_tyrant.remains<10&cooldown.call_dreadstalkers.remains<10)");
            if (SpellCast("Summon Vilefiend", HasTalent(Talent.SummonVilefiend) && !OnCooldown(Spells.SummonVilefiend) &&
               (SpellCD(Spells.SummonDemonicTyrant) > 30 || (SpellCD(Spells.SummonDemonicTyrant) < 10 && SpellCD(Spells.CallDreadstalkers) < 10)))) return;
            //def->add_action("grimoire_felguard");
            if (SpellCast("Grimoire: Felguard", HasTalent(Talent.GrimoireFelguard) && !OnCooldown(Spells.GrimoireFelguard) && WoW.UseCooldowns && Power(Unit.SoulShards) >= 1)) return;
            //def->add_action("hand_of_guldan,if=soul_shard>=5");
            if (SpellCast("Hand of Gul'dan", Power(Unit.SoulShards) >= 5 && OnCooldown(Spells.CallDreadstalkers))) return;
            //def->add_action("hand_of_guldan,if=soul_shard>=3&cooldown.call_dreadstalkers.remains>4&(!talent.summon_vilefiend.enabled|cooldown.summon_vilefiend.remains>4)");
            if (SpellCast("Hand of Gul'dan", Power(Unit.SoulShards) >= 3 && SpellCD(Spells.CallDreadstalkers) > 4 && (!HasTalent(Talent.SummonVilefiend) || SpellCD(Spells.SummonVilefiend) > 4))) return;
            //def->add_action("call_dreadstalkers");
            if (SpellCast("Call Dreadstalkers", !OnCooldown(Spells.CallDreadstalkers) && (Power(Unit.SoulShards) >= 2 || (Power(Unit.SoulShards) >= 1 && HasAura(Auras.DemonicCalling))))) return;
            //def->add_action("bilescourge_bombers");
            if (SpellCast("Bilescourge Bombers", HasTalent(Talent.BilescourgeBombers) && !OnCooldown(Spells.BilescourgeBombers) && Power(Unit.SoulShards) >= 2)) return;
            // Cast Implosion on 5+ stacked Targets
            if (SpellCast("Implosion", WoW.GetAsyncKeyState(Keys.NumPad5) < 0)) return;
            //def->add_action("summon_demonic_tyrant,if=talent.summon_vilefiend.enabled&buff.dreadstalkers.remains>action.summon_demonic_tyrant.cast_time&buff.vilefiend.remains>action.summon_demonic_tyrant.cast_time");
            //def->add_action("summon_demonic_tyrant,if=!talent.summon_vilefiend.enabled&buff.dreadstalkers.remains>action.summon_demonic_tyrant.cast_time&soul_shard=0");
            if (SpellCast("Summon Demonic Tyrant", !OnCooldown(Spells.SummonDemonicTyrant) && WoW.UseCooldowns && WoW.GetAsyncKeyState(Keys.NumPad3) < 0)) return;
            //def->add_action("power_siphon,if=buff.wild_imps.stack>=2&buff.demonic_core.stack<=2&buff.demonic_power.down");
            if (SpellCast("Power Siphon", HasTalent(Talent.PowerSiphon) && !OnCooldown(Spells.PowerSiphon) /*&& ImpCount >= 2*/ && AuraStacks(Auras.DemonicCore) <= 2 && !HasAura(Auras.DemonicPower))) return;
            //def->add_action("demonbolt,if=soul_shard<=3&buff.demonic_core.up");
            if (SpellCast("Demonbolt", Power(Unit.SoulShards) <= 3 && AuraStacks(Auras.DemonicCore) >= 1)) return;
            //def->add_action("doom,cycle_targets=1,if=(talent.doom.enabled&target.time_to_die>duration&(!ticking|remains<duration*0.3))");
            if (SpellCast("Doom", HasTalent(Talent.Doom) && (!HasAura(Auras.Doom) || AuraRemaining(Auras.Doom) <= 9))) return;
            // def->add_action("call_action_list,name=build_a_shard");
            //build_a_shard();
            if (SpellCast("Soul Strike", PreCheck(Precheck.SoulStrike))) return;
            //bas->add_action("shadow_bolt");
            if (SpellCast("Shadow Bolt", Power(Unit.SoulShards) < 5)) return;
        }
        #endregion

        #region Implosion
        public void Implosion()
        {
            #region Logging

            const string msg = "Throwing Imps.";

            if (_lynxdebugger && msg != _lynxdebuggerstring)
            {
                Log.Write(msg, Color.Blue);
                _lynxdebuggerstring = msg;
            }

            #endregion
            //Build to 5  Soul Shards
            Log.Write(String.Format("Current Soulshards: " + WoW.CurrentSoulShards + "ImpOrder: " + _ImpOrder), Color.Blue);

            if (SpellCast("Shadow Bolt", Power(Unit.SoulShards) < 5 && _ImpOrder == 0)) return;

            if (Power(Unit.SoulShards) >= 5 && _ImpOrder == 0)
            {
                _ImpOrder = 1;
                return;
            }
            #region <= 1 Demonic Core
            if (AuraStacks(Auras.DemonicCore) <= 1 && !_ForceImp2DC)
            {                
                //Cast Hand of Gul'dan
                if (WoW.CanCast("Hand of Gul'dan") && Power(Unit.SoulShards) >= 5 && _ImpOrder == 1)
                {
                    Log.Write("1. Hand of Gul'dan 5 Soulshards", Color.DarkBlue);
                    WoW.CastSpell("Hand of Gul'dan");
                    _ImpOrder = 2;
                    _ForceImp = true;
                    return;
                }
                //Build to 3  Soul Shards
                if (WoW.CanCast("Shadow Bolt") && _ImpOrder == 2)
                {
                    Log.Write("2. Shadow Bolt to 3 Soulshards", Color.DarkBlue);
                    WoW.CastSpell("Shadow Bolt");
                    _ImpOrder = 3;
                    return;

                }
                //Cast Hand of Gul'dan
                if (WoW.CanCast("Hand of Gul'dan") && Power(Unit.SoulShards) >= 3 && ((_ImpOrder == 3 || (_ImpOrder == 2 && Power(Unit.SoulShards) > 3))))
                {
                    Log.Write("3. Hand of Gul'dan 3 Soulshards", Color.DarkBlue);
                    WoW.CastSpell("Hand of Gul'dan");
                    _ImpOrder = 4;
                    return;
                }
                //Cast Shadow Bolt or  Demonbolt if you have a stack of  Demonic Core
                if (WoW.CanCast("Demonbolt") && AuraStacks(Auras.DemonicCore) >= 1 && _ImpOrder == 4)
                {
                    Log.Write("4. Demonbolt", Color.DarkBlue);
                    WoW.CastSpell("Demonbolt");
                    _ImpOrder = 5;
                    return;
                }
                if (WoW.CanCast("Shadow Bolt") && _ImpOrder == 4)
                {
                    Log.Write("4. Shadow Bolt", Color.DarkBlue);
                    WoW.CastSpell("Shadow Bolt");
                    _ImpOrder = 5;
                    return;
                }
                //Cast Shadow Bolt
                if (WoW.CanCast("Shadow Bolt") && _ImpOrder == 5)
                {
                    Log.Write("5. Shadow Bolt (Almost there!)", Color.DarkBlue);
                    WoW.CastSpell("Shadow Bolt");
                    _ImpOrder = 6;
                    return;
                }
                //Cast  Implosion
                if (WoW.CanCast("Implosion") && _ImpOrder == 6)
                {
                    Log.Write("6. Throw those damn imps!", Color.DarkBlue);
                    WoW.CastSpell("Implosion");
                    _ImpOrder = 0;
                    _ForceImp = false;
                    return;
                }
            }
            #endregion
            #region >= 2 Demonic Core
            else if (AuraStacks(Auras.DemonicCore) >= 2 && !_ForceImp)
            {                
                //Cast Hand of Gul'dan
                if (WoW.CanCast("Hand of Gul'dan") && Power(Unit.SoulShards) == 5 && _ImpOrder == 1)
                {
                    Log.Write("1. Hand of Gul'dan 5 Soulshards", Color.DarkGreen);
                    WoW.CastSpell("Hand of Gul'dan");
                    _ForceImp2DC = true;
                    _ImpOrder = 2;
                    return;
                }
                //Build 4  Soul Shards using  Demonbolt
                if (WoW.CanCast("Demonbolt") && AuraStacks(Auras.DemonicCore) >= 2 && _ImpOrder == 2)
                {
                    Log.Write("2. Demonbolt to 4 SoulShards", Color.DarkGreen);
                    WoW.CastSpell("Demonbolt");
                    _ImpOrder = 3;
                    return;
                }
                //Cast  Hand of Gul'dan
                if (WoW.CanCast("Hand of Gul'dan") && Power(Unit.SoulShards) >= 4 && ((_ImpOrder == 3 || (_ImpOrder == 2 && Power(Unit.SoulShards) > 3))))
                {
                    Log.Write("3. Hand of Gul'dan 4 Soulshards", Color.DarkGreen);
                    WoW.CastSpell("Hand of Gul'dan");
                    _ImpOrder = 4;
                    return;
                }
                //Build to 3  Soul Shards using  Demonbolt
                if (WoW.CanCast("Demonbolt") && AuraStacks(Auras.DemonicCore) >= 1 && _ImpOrder == 4)
                {
                    Log.Write("4. Demonbolt to 3 SoulShards", Color.DarkGreen);
                    WoW.CastSpell("Demonbolt");
                    _ImpOrder = 5;
                    return;
                }

                //Cast  Hand of Gul'dan
                if (WoW.CanCast("Hand of Gul'dan") && Power(Unit.SoulShards) >= 3 && ((_ImpOrder == 5 || (_ImpOrder == 4 && Power(Unit.SoulShards) >= 3))))
                {
                    Log.Write("5. Hand of Gul'dan 3 Soulshards", Color.DarkGreen);
                    WoW.CastSpell("Hand of Gul'dan");
                    _ImpOrder = 6;
                    return;
                }
                //Cast Shadow Bolt
                if (WoW.CanCast("Shadow Bolt") && _ImpOrder == 6)
                {
                    Log.Write("6. Shadow Bolt", Color.DarkGreen);
                    WoW.CastSpell("Shadow Bolt");
                    _ImpOrder = 7;
                    return;
                }
                //Cast  Shadow Bolt
                if (WoW.CanCast("Shadow Bolt") && _ImpOrder == 7)
                {
                    Log.Write("7. Shadow Bolt, almost there!", Color.DarkGreen);
                    WoW.CastSpell("Shadow Bolt");
                    _ImpOrder = 8;
                    return;
                }
                //Cast Implosion
                if (WoW.CanCast("Implosion") && _ImpOrder == 8)
                {
                    Log.Write("8. Throw those damn imps!", Color.DarkGreen);
                    WoW.CastSpell("Implosion");
                    _ImpOrder = 0;
                    _ForceImp2DC = false;
                    return;
                }
            }
            #endregion
            
        }
        #endregion

        #region nether_portal
        public void nether_portal()
        {
            //np->add_action("call_action_list,name=nether_portal_building,if=cooldown.nether_portal.remains<20");
            if ((SpellCD(Spells.NetherPortal) < 20 && (OnCooldown(Spells.NetherPortal)) || !OnCooldown(Spells.NetherPortal))) { nether_portal_building(); }
            //np->add_action("call_action_list,name=nether_portal_active,if=cooldown.nether_portal.remains>160");
            if (SpellCD(Spells.NetherPortal) > 160 && OnCooldown(Spells.NetherPortal)) { nether_portal_active(); }
        }
        

        #region nether_portal_building
        public void nether_portal_building()
        {
            #region Logging

            const string msg = "Nether Portal building.";

            if (_lynxdebugger && msg != _lynxdebuggerstring)
            {
                Log.Write(msg, Color.Blue);
                _lynxdebuggerstring = msg;
            }

            #endregion
            // npb->add_action("nether_portal,if=soul_shard>=5&(!talent.power_siphon.enabled|buff.demonic_core.up)");
            if (SpellCast("Nether Portal", !OnCooldown(Spells.NetherPortal) && Power(Unit.SoulShards) >= 5 && (!HasTalent(Talent.PowerSiphon) || AuraStacks(Auras.DemonicCore) >= 1))) return;
            // npb->add_action("call_dreadstalkers");
            if (SpellCast("Call Dreadstalkers", !OnCooldown(Spells.CallDreadstalkers) && (Power(Unit.SoulShards) >= 2 || (Power(Unit.SoulShards) >= 1 && HasAura(Auras.DemonicCalling))))) return;
            // npb->add_action("hand_of_guldan,if=cooldown.call_dreadstalkers.remains>18&soul_shard>=3");
            if (SpellCast("Hand of Gul'dan", SpellCD(Spells.CallDreadstalkers) > 18 && Power(Unit.SoulShards) >= 3)) return;
            // npb->add_action("power_siphon,if=buff.wild_imps.stack>=2&buff.demonic_core.stack<=2&buff.demonic_power.down&soul_shard>=3");
            if (SpellCast("Power Siphon", /*ImpCount >= 2 &&*/HasTalent(Talent.PowerSiphon) && AuraStacks(Auras.DemonicCore) <= 2 && !HasAura(Auras.DemonicPower) && Power(Unit.SoulShards) >= 3)) return;
            // npb->add_action("hand_of_guldan,if=soul_shard>=5");
            if (SpellCast("Hand of Gul'dan", Power(Unit.SoulShards) >= 5 && OnCooldown(Spells.CallDreadstalkers))) return;
            // npb->add_action("call_action_list,name=build_a_shard");
            //build_a_shard();
            if (SpellCast("Soul Strike", PreCheck(Precheck.SoulStrike))) return;
            //bas->add_action("shadow_bolt");
            if (SpellCast("Shadow Bolt", Power(Unit.SoulShards) < 5)) return;

        }
        #endregion

        #region  nether_portal_active
        public void nether_portal_active()
        {
            #region Logging

            const string msg = "Nether Portal Active!";

            if (_lynxdebugger && msg != _lynxdebuggerstring)
            {
                Log.Write(msg, Color.Blue);
                _lynxdebuggerstring = msg;
            }

            #endregion
            //npa->add_action("call_dreadstalkers");
            if (SpellCast("Call Dreadstalkers", !OnCooldown(Spells.CallDreadstalkers) && (Power(Unit.SoulShards) >= 2 || (Power(Unit.SoulShards) >= 1 && HasAura(Auras.DemonicCalling))))) return;
            //npa->add_action("hand_of_guldan,if=prev_gcd.1.grimoire_felguard|prev_gcd.1.summon_vilefiend");
            if (SpellCast("Hand of Gul'dan", WoW.PlayerLastCast("Grimoire: Felguard") || WoW.PlayerLastCast("Summon Vilefiend"))) return;
            //npa->add_action("grimoire_felguard");
            if (SpellCast("Grimoire: Felguard", HasTalent(Talent.GrimoireFelguard) && !OnCooldown(Spells.GrimoireFelguard) && WoW.UseCooldowns && Power(Unit.SoulShards) >= 1)) return;
            //npa->add_action("summon_vilefiend");
            if (SpellCast("Summon Vilefiend", HasTalent(Talent.SummonVilefiend) && !OnCooldown(Spells.SummonVilefiend) && WoW.UseCooldowns)) return;
            //npa->add_action("bilescourge_bombers");
            if (SpellCast("Bilescourge Bombers", HasTalent(Talent.BilescourgeBombers) && !OnCooldown(Spells.BilescourgeBombers) && Power(Unit.SoulShards) >= 2)) return;
            //npa->add_action("call_action_list,name=build_a_shard,if=soul_shard=1&(cooldown.call_dreadstalkers.remains<action.shadow_bolt.cast_time|(talent.bilescourge_bombers.enabled&cooldown.bilescourge_bombers.remains<action.shadow_bolt.cast_time))");
            //if (Power(Unit.SoulShards) == 1 && (SpellCD(Spells.CallDreadstalkers) <= 2 || (HasTalent(Talent.BilescourgeBombers) && SpellCD(Spells.BilescourgeBombers) <= 2))) build_a_shard();
            //npa->add_action("hand_of_guldan,if=((cooldown.call_dreadstalkers.remains>action.demonbolt.cast_time)&(cooldown.call_dreadstalkers.remains>action.shadow_bolt.cast_time))&cooldown.nether_portal.remains>(160+action.hand_of_guldan.cast_time)");
            if (SpellCast("Hand of Gul'dan", (SpellCD(Spells.CallDreadstalkers) > 4) && (SpellCD(Spells.CallDreadstalkers) > 2) && SpellCD(Spells.NetherPortal) > 162)) return;
            //npa->add_action("summon_demonic_tyrant,if=buff.nether_portal.remains<10&soul_shard=0");
            if (SpellCast("Summon Demonic Tyrant", AuraRemaining(Auras.NetherPortal) < 10 && Power(Unit.SoulShards) == 0) && WoW.UseCooldowns) return;
            //npa->add_action("summon_demonic_tyrant,if=buff.nether_portal.remains<action.summon_demonic_tyrant.cast_time+5.5");
            if (SpellCast("Summon Demonic Tyrant", AuraRemaining(Auras.NetherPortal) < 10 && Power(Unit.SoulShards) == 0)) return;
            //npa->add_action("demonbolt,if=buff.demonic_core.up");
            if (SpellCast("Demonbolt", AuraStacks(Auras.DemonicCore) >= 1)) return;
            //npa->add_action("call_action_list,name=build_a_shard");
            //build_a_shard();
            if (SpellCast("Soul Strike", PreCheck(Precheck.SoulStrike))) return;
            //bas->add_action("shadow_bolt");
            if (SpellCast("Shadow Bolt", Power(Unit.SoulShards) < 5)) return;

        }
        #endregion
        #endregion

        #region  build_a_shard
        public void build_a_shard()
        {
            // bas->add_action("soul_strike");
            if (SpellCast("Soul Strike", PreCheck(Precheck.SoulStrike))) return;
            //bas->add_action("shadow_bolt");
            if (SpellCast("Shadow Bolt", Power(Unit.SoulShards) < 5)) return;

        }
        #endregion

        #region Combat Pulse

        public override void Pulse()
        {
            if (SpellCast("Shadow Fury", WoW.GetAsyncKeyState(Keys.Q) < 0)) return;
            #region CombatTimer
            if (!WoW.PlayerIsInCombat)
            {
                if (WoW.CurrentEnemyUnitCount < 2 && Player(Status.IsMoving) && AutoAoECheck  && WoW.PlayerHasBuff("Blade Flurry")) { WoW.CastSpell("Blade Flurry"); return; }

                if (CombatSec > 0.00)
                {
                    CombatTimer.Reset();

                }
                return;
            }
            if (WoW.PlayerIsInCombat)
            {
                if (CombatSec < 0.001)
                {
                    CombatTimer.Start();
                }
            }
            #endregion

            if (PreCheck(Precheck.Combat))
            {
                // Log.Write(String.Format("Demonic Strength : " + WoW.IsTalentAvailable("Demonic Strength")), Color.Blue);
                AoECheck();

                if (SpellCast("Blood Fury", !OnCooldown(Spells.BloodFury) && WoW.UseCooldowns)) return;
                // def->add_action("demonic_strength");
                if (SpellCast("Demonic Strength", HasTalent(Talent.DemonicStrength) && !OnCooldown(Spells.DemonicStrength))) return;
                // def->add_action("call_action_list,name=nether_portal,if=talent.nether_portal.enabled");            
                if (HasTalent(Talent.NetherPortal)) nether_portal();
                              
                if (!_ForceAoE || 
                        (!OnCooldown(Spells.CallDreadstalkers) || 
                        (HasTalent(Talent.SummonVilefiend) && !OnCooldown(Spells.SummonVilefiend)) ||
                        (HasTalent(Talent.GrimoireFelguard) && !OnCooldown(Spells.GrimoireFelguard)) ||
                        (HasTalent(Talent.BilescourgeBombers) && !OnCooldown(Spells.BilescourgeBombers)))) { _ImpOrder = 0; _ForceImp2DC = false; _ForceImp = false; Default(); }
                
                //if (AuraStacks(Auras.DemonicCore) >= 2 && _ForceAoE) { Implosion_2_DemonicCore(); }

                if (_ForceAoE && 
                    OnCooldown(Spells.CallDreadstalkers) && 
                    (!HasTalent(Talent.SummonVilefiend) || OnCooldown(Spells.SummonVilefiend)) && 
                    (!HasTalent(Talent.GrimoireFelguard) || OnCooldown(Spells.GrimoireFelguard)) &&
                    (!HasTalent(Talent.BilescourgeBombers) || OnCooldown(Spells.BilescourgeBombers))) { Implosion(); }
                                          
            }
        }
        #endregion
               
        public override void Stop()
        {
            WriteLog("Stopping already?");
        }

        #endregion

        #region Interface Settings

        //This is where you paste the code from the Interfacename.Designer.cs File,
        //that is automatically generated after you create your GUI in the Visual
        //designer, you can open the GUI with the ExampleInterface.cs file and there
        //is a small example of different forms and such.

        public class PrettyDemoLockInterface : Form
        {
            public Image ExampleLogo
            {
                get
                {
                    // You paste the string for your image below in the "", if you don't have a string in there the rotation will not error,
                    // if you don't want to add an image yet, Comment out the ExampleLogo function block and any relevant calls in setup.
                    var newbytearray = "71,73,70,56,57,97,16,3,95,0,247,0,0,0,0,0,0,0,51,0,0,102,0,0,153,0,0,204,0,0,255,0,43,0,0,43,51,0,43,102,0,43,153,0,43,204,0,43,255,0,85,0,0,85,51,0,85,102,0,85,153,0,85,204,0,85,255,0,128,0,0,128,51,0,128,102,0,128,153,0,128,204,0,128,255,0,170,0,0,170,51,0,170,102,0,170,153,0,170,204,0,170,255,0,213,0,0,213,51,0,213,102,0,213,153,0,213,204,0,213,255,0,255,0,0,255,51,0,255,102,0,255,153,0,255,204,0,255,255,51,0,0,51,0,51,51,0,102,51,0,153,51,0,204,51,0,255,51,43,0,51,43,51,51,43,102,51,43,153,51,43,204,51,43,255,51,85,0,51,85,51,51,85,102,51,85,153,51,85,204,51,85,255,51,128,0,51,128,51,51,128,102,51,128,153,51,128,204,51,128,255,51,170,0,51,170,51,51,170,102,51,170,153,51,170,204,51,170,255,51,213,0,51,213,51,51,213,102,51,213,153,51,213,204,51,213,255,51,255,0,51,255,51,51,255,102,51,255,153,51,255,204,51,255,255,102,0,0,102,0,51,102,0,102,102,0,153,102,0,204,102,0,255,102,43,0,102,43,51,102,43,102,102,43,153,102,43,204,102,43,255,102,85,0,102,85,51,102,85,102,102,85,153,102,85,204,102,85,255,102,128,0,102,128,51,102,128,102,102,128,153,102,128,204,102,128,255,102,170,0,102,170,51,102,170,102,102,170,153,102,170,204,102,170,255,102,213,0,102,213,51,102,213,102,102,213,153,102,213,204,102,213,255,102,255,0,102,255,51,102,255,102,102,255,153,102,255,204,102,255,255,153,0,0,153,0,51,153,0,102,153,0,153,153,0,204,153,0,255,153,43,0,153,43,51,153,43,102,153,43,153,153,43,204,153,43,255,153,85,0,153,85,51,153,85,102,153,85,153,153,85,204,153,85,255,153,128,0,153,128,51,153,128,102,153,128,153,153,128,204,153,128,255,153,170,0,153,170,51,153,170,102,153,170,153,153,170,204,153,170,255,153,213,0,153,213,51,153,213,102,153,213,153,153,213,204,153,213,255,153,255,0,153,255,51,153,255,102,153,255,153,153,255,204,153,255,255,204,0,0,204,0,51,204,0,102,204,0,153,204,0,204,204,0,255,204,43,0,204,43,51,204,43,102,204,43,153,204,43,204,204,43,255,204,85,0,204,85,51,204,85,102,204,85,153,204,85,204,204,85,255,204,128,0,204,128,51,204,128,102,204,128,153,204,128,204,204,128,255,204,170,0,204,170,51,204,170,102,204,170,153,204,170,204,204,170,255,204,213,0,204,213,51,204,213,102,204,213,153,204,213,204,204,213,255,204,255,0,204,255,51,204,255,102,204,255,153,204,255,204,204,255,255,255,0,0,255,0,51,255,0,102,255,0,153,255,0,204,255,0,255,255,43,0,255,43,51,255,43,102,255,43,153,255,43,204,255,43,255,255,85,0,255,85,51,255,85,102,255,85,153,255,85,204,255,85,255,255,128,0,255,128,51,255,128,102,255,128,153,255,128,204,255,128,255,255,170,0,255,170,51,255,170,102,255,170,153,255,170,204,255,170,255,255,213,0,255,213,51,255,213,102,255,213,153,255,213,204,255,213,255,255,255,0,255,255,51,255,255,102,255,255,153,255,255,204,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,33,249,4,1,0,0,252,0,44,0,0,0,0,16,3,95,0,0,8,207,0,1,8,28,72,176,160,193,131,8,19,42,92,200,176,161,195,135,16,35,74,156,72,177,162,197,139,24,51,106,220,200,177,163,199,143,32,67,138,28,73,178,164,201,147,40,83,170,92,201,178,165,203,151,48,99,202,156,73,179,166,205,155,56,115,234,220,201,179,167,207,159,64,131,10,29,74,180,168,209,163,72,147,42,93,202,180,169,211,167,80,163,74,157,202,81,5,213,171,88,179,106,221,202,181,107,84,171,94,195,138,29,75,182,172,217,179,16,193,162,93,203,182,173,219,183,112,119,170,141,75,183,174,221,187,120,243,34,156,171,183,175,223,191,128,3,63,229,43,184,176,225,195,136,19,167,228,75,88,177,227,199,144,35,71,158,75,69,154,228,203,152,51,107,182,59,87,133,52,105,84,6,54,222,76,186,180,233,211,72,249,162,250,140,186,181,235,215,176,117,242,245,243,25,116,236,219,255,184,17,143,206,29,179,243,231,213,168,120,11,31,30,116,55,113,174,170,127,179,54,173,194,248,241,231,114,145,43,110,78,189,186,245,235,18,61,75,3,110,187,181,115,232,224,107,130,85,225,167,188,249,243,232,211,171,95,175,126,113,120,209,5,201,171,160,178,250,246,247,247,248,87,130,245,163,98,245,246,255,255,249,199,93,128,202,9,8,224,128,171,249,17,218,73,140,37,118,223,68,15,50,71,80,132,249,85,136,18,119,24,18,152,225,134,26,18,72,33,70,31,10,54,31,21,243,149,72,34,69,33,162,150,162,133,44,122,212,95,135,28,198,8,227,127,43,66,72,144,101,153,105,135,224,70,53,78,119,80,143,45,6,89,145,103,2,162,130,158,145,72,250,129,202,146,76,54,233,228,146,126,152,52,151,146,151,129,69,5,127,220,241,87,163,149,254,1,233,216,137,19,10,41,166,73,168,120,217,146,90,149,73,163,150,153,112,85,86,38,147,27,41,185,36,155,133,169,181,228,130,99,230,233,81,101,229,25,57,161,156,79,38,105,36,123,128,226,9,210,154,76,26,122,25,255,125,115,6,23,231,127,138,222,182,164,52,81,134,169,231,165,19,49,186,221,154,4,118,8,96,129,159,250,183,169,66,86,53,7,128,169,168,58,228,230,114,12,117,118,29,117,167,198,39,144,169,105,197,90,170,173,184,54,116,235,174,184,210,137,16,125,219,69,138,162,64,74,6,187,160,154,123,189,170,236,173,162,45,91,93,172,101,209,71,36,112,190,98,218,226,180,193,225,56,171,165,9,173,121,209,136,84,132,43,44,183,167,194,138,82,181,15,161,139,226,118,168,224,89,30,70,133,86,218,110,111,82,226,68,27,146,77,162,203,236,182,252,242,234,47,124,67,214,42,229,191,123,133,169,238,152,154,6,55,39,75,156,38,202,111,193,195,66,251,175,179,6,221,231,170,117,2,191,122,46,187,11,66,25,48,0,114,170,233,40,178,16,247,154,107,201,188,46,148,114,85,240,17,204,108,202,47,91,132,102,177,112,178,252,209,120,226,134,235,16,206,57,67,60,94,191,64,75,28,116,118,15,87,108,109,70,216,146,219,210,188,18,233,44,17,205,79,178,27,232,164,126,10,44,16,172,163,14,71,216,95,147,90,50,152,232,214,85,91,132,117,127,2,49,93,48,213,104,47,73,42,0,77,82,218,237,172,78,86,187,223,212,192,49,41,117,218,192,141,171,171,209,35,205,71,117,128,117,67,57,168,163,10,61,25,17,160,97,39,20,181,147,119,7,158,182,113,136,59,158,54,127,124,31,157,238,213,249,110,231,146,85,239,126,104,85,130,17,161,89,119,227,116,55,169,55,169,205,161,189,51,177,255,241,247,238,98,159,51,89,169,141,87,135,235,153,64,36,51,68,183,174,74,206,222,109,220,69,107,212,103,233,196,51,217,35,88,97,35,185,160,151,92,22,255,164,235,107,159,42,251,131,227,109,231,59,66,237,58,239,252,218,145,107,111,36,97,167,255,91,30,31,112,10,150,105,51,245,32,19,94,107,205,208,170,76,144,156,229,229,172,160,122,109,155,189,55,0,39,22,250,16,163,90,186,221,18,160,215,195,72,153,250,115,186,41,201,206,120,111,27,72,248,6,114,183,0,130,72,122,245,75,210,145,122,39,184,133,201,76,122,154,123,159,3,43,210,189,10,50,110,78,210,138,30,4,237,39,66,182,185,47,130,178,75,143,160,4,183,65,248,96,141,107,7,44,221,193,130,196,168,25,202,170,96,244,33,200,2,183,213,59,83,169,111,33,78,91,83,170,26,132,191,124,9,108,94,99,115,31,219,230,36,167,151,112,173,35,106,234,207,119,20,100,59,5,214,140,48,86,1,214,206,160,68,165,224,93,112,137,223,115,162,199,252,103,194,111,17,139,107,227,25,98,185,74,69,194,31,197,170,134,171,27,145,67,100,7,38,23,21,177,76,36,122,22,172,74,117,37,195,121,81,124,2,1,3,33,192,128,69,122,229,80,122,45,148,21,156,82,183,183,173,85,10,108,197,3,35,251,34,226,39,172,53,4,128,106,123,9,0,59,210,46,255,2,174,13,129,149,218,100,66,24,245,16,46,170,139,141,153,108,150,179,172,35,174,143,193,41,74,132,83,80,70,176,214,49,46,94,233,72,193,233,34,169,154,72,202,213,193,145,123,169,44,34,5,225,135,175,231,49,132,81,11,234,160,147,180,132,184,29,66,69,11,208,212,2,12,162,73,77,24,128,165,154,72,209,194,32,9,161,8,48,64,211,134,68,179,213,157,226,120,34,18,253,80,33,200,140,18,36,37,55,184,91,66,112,69,106,179,164,27,239,56,60,112,222,176,32,162,220,72,187,66,184,144,43,162,210,130,178,234,37,192,14,50,206,145,220,105,74,243,187,146,66,229,183,208,42,218,8,142,124,36,86,34,31,2,191,89,61,200,124,42,243,152,64,91,149,190,115,98,15,163,87,195,78,170,132,214,190,146,190,209,130,131,58,207,45,17,167,78,211,121,101,144,221,132,169,22,186,169,136,153,198,212,155,49,85,132,34,6,169,5,123,118,68,5,53,237,230,76,97,218,77,107,138,39,126,20,33,209,68,255,164,78,10,73,177,108,109,84,98,13,43,170,184,239,21,255,84,147,178,51,233,234,12,98,36,250,44,208,60,92,205,234,175,234,195,81,143,41,237,139,119,82,144,79,17,2,86,209,36,19,164,225,196,159,187,126,202,203,196,185,111,163,10,209,37,229,64,114,75,173,245,50,137,91,209,130,32,103,58,83,48,44,34,18,146,16,134,48,22,65,88,69,8,67,155,222,20,36,24,104,170,133,159,224,52,19,147,200,4,97,9,161,77,202,86,150,97,241,161,21,71,223,71,158,116,149,72,180,28,197,147,51,71,249,164,52,218,169,81,118,45,201,231,12,5,191,165,82,178,124,78,125,159,75,77,138,215,194,197,246,167,5,181,45,95,185,4,178,5,209,71,184,37,188,89,239,138,88,171,222,178,85,125,171,205,142,211,14,23,165,62,2,20,43,208,188,41,49,232,161,15,238,210,67,25,250,80,70,36,134,161,133,238,134,65,24,132,72,44,121,183,217,77,123,26,71,5,130,85,193,52,97,176,77,201,14,114,18,153,157,196,77,131,170,5,253,218,148,176,242,245,86,169,14,208,28,2,199,0,0,48,88,129,1,20,172,2,2,19,120,193,255,16,110,176,132,33,28,0,24,0,32,6,42,128,240,133,17,92,225,10,111,248,192,38,133,30,0,24,236,96,14,195,160,194,19,14,128,1,36,124,98,107,62,152,196,223,177,202,129,15,220,98,15,207,184,125,152,132,235,25,115,153,202,21,152,216,198,27,174,177,133,29,156,225,14,15,57,197,45,222,240,25,15,114,165,88,25,249,195,0,128,176,130,149,220,152,174,130,52,201,55,150,240,134,231,82,193,198,244,22,203,4,25,39,63,45,124,99,41,27,0,202,102,134,114,152,101,217,197,0,100,216,199,39,126,51,135,223,124,102,6,163,24,200,52,86,49,140,9,188,101,62,15,100,94,91,155,21,158,163,172,224,41,223,24,90,141,90,147,135,23,109,97,32,91,37,193,11,38,51,149,151,91,199,83,153,89,194,124,206,98,24,225,131,97,63,51,87,162,2,57,176,150,69,205,103,82,203,248,84,165,54,177,157,27,109,97,24,247,249,212,159,147,79,159,102,39,233,3,167,185,204,133,62,51,174,53,188,107,67,179,132,191,138,208,71,120,233,17,13,239,114,119,31,90,56,255,108,121,195,48,222,69,216,87,178,53,165,102,52,173,41,223,105,202,183,154,219,140,166,55,179,107,211,200,242,116,167,58,213,233,80,237,43,88,206,6,21,179,152,157,68,24,36,33,89,194,74,34,12,144,133,41,180,5,171,133,24,24,21,0,7,16,72,137,111,204,111,40,247,187,211,13,246,55,148,137,252,224,217,148,150,208,102,206,181,145,43,156,235,134,75,185,196,86,82,39,65,14,32,228,133,11,217,211,248,90,174,14,185,168,75,4,19,28,211,152,22,248,191,69,78,229,244,229,177,98,143,182,184,202,79,124,102,236,97,9,79,14,87,176,131,107,140,168,36,49,57,152,2,89,184,16,201,147,73,21,4,96,228,64,39,185,42,155,24,229,3,83,188,194,51,71,58,166,91,156,244,138,59,93,233,71,135,129,159,149,148,186,189,158,56,232,253,86,96,236,104,253,115,8,207,216,204,251,22,248,25,29,24,131,133,167,89,211,231,36,120,152,144,57,171,3,120,253,194,111,143,65,220,227,190,225,166,39,125,238,10,206,178,184,204,183,233,21,228,27,235,36,7,60,224,255,81,210,88,45,236,67,25,222,237,46,52,232,1,141,97,44,66,31,139,120,124,178,189,41,140,118,3,251,166,208,126,246,78,39,251,108,206,115,147,220,246,101,108,77,189,25,134,110,46,66,17,165,63,125,24,190,59,12,200,27,54,191,153,88,4,38,24,1,108,193,210,62,12,162,143,183,230,57,63,237,24,220,32,12,98,8,3,14,130,63,124,225,19,31,248,56,48,254,13,196,144,252,226,15,95,12,203,103,62,242,167,223,124,12,227,243,224,98,144,190,243,161,31,252,236,39,159,249,196,207,254,242,139,47,125,232,131,24,100,176,36,92,246,185,223,124,246,11,95,249,32,118,164,88,33,88,41,167,197,64,252,248,231,190,251,179,111,252,247,151,255,251,0,72,125,230,199,92,14,180,32,91,16,128,255,231,127,98,16,3,231,87,16,86,53,16,6,16,126,227,7,124,250,183,124,55,160,22,195,195,52,243,49,43,93,180,129,17,40,129,22,166,65,230,19,3,239,215,126,253,231,124,211,151,128,208,55,62,93,212,127,224,55,129,237,23,125,50,8,126,202,167,125,18,24,255,126,41,136,3,214,7,54,68,199,125,22,152,127,51,120,3,214,167,16,220,119,130,248,183,125,199,87,126,66,152,62,1,228,123,62,200,127,213,167,105,123,5,22,37,24,6,13,40,76,161,1,3,207,7,131,238,183,125,237,7,128,69,184,125,53,24,126,49,168,125,241,247,61,26,71,130,221,55,131,21,8,132,248,199,134,112,232,131,12,168,107,6,192,128,37,1,77,222,68,8,194,16,94,195,182,120,221,5,6,202,128,9,139,48,12,142,39,108,90,64,94,244,192,88,134,69,88,134,229,108,132,16,9,144,37,9,163,71,8,235,86,83,146,160,15,195,48,88,194,176,15,146,48,83,146,128,120,152,248,120,250,32,89,195,32,12,220,5,94,251,32,108,251,48,89,184,183,8,153,240,88,146,128,110,104,160,5,153,0,111,181,7,6,96,144,89,157,56,122,120,88,110,133,119,83,133,144,6,196,160,12,202,48,140,197,72,140,198,152,140,200,184,140,199,216,140,202,232,140,202,144,9,98,96,112,11,194,140,207,168,9,214,152,141,208,40,141,23,200,85,161,166,141,207,56,255,140,196,64,12,153,192,37,195,84,75,123,53,59,203,24,142,204,136,141,208,248,142,236,88,140,153,176,5,229,82,70,248,36,16,147,0,142,214,152,9,87,248,103,252,129,39,49,144,141,202,40,142,153,144,6,107,134,36,200,131,74,229,162,78,203,56,12,105,112,133,26,135,6,250,8,143,217,168,9,146,208,128,253,209,69,226,120,140,27,73,12,153,213,145,235,72,145,20,185,145,199,200,143,101,67,65,96,33,6,19,153,140,196,128,6,124,225,80,0,160,146,3,9,141,36,57,144,181,200,132,110,21,147,35,41,141,89,68,117,205,17,37,1,89,146,98,80,16,199,21,26,1,57,147,195,152,9,153,0,146,32,57,146,28,25,146,79,153,140,104,112,96,199,85,82,18,73,12,160,32,146,241,184,149,33,89,147,83,105,104,11,54,18,140,168,5,136,231,135,245,192,135,132,160,12,130,53,12,201,32,88,202,192,11,134,5,13,167,103,120,163,200,83,250,160,8,146,64,15,222,4,138,139,16,6,194,134,137,138,128,120,243,0,77,195,176,120,144,8,6,222,229,135,139,7,255,77,151,200,120,222,133,120,136,39,9,201,224,108,219,70,139,176,39,9,147,48,151,244,230,139,139,144,89,220,198,95,60,181,109,209,6,109,103,48,12,160,48,12,202,160,9,201,128,149,168,137,141,196,240,9,195,136,154,196,176,154,202,96,154,179,201,154,181,9,10,179,137,141,178,89,140,11,120,125,3,81,140,180,105,155,180,25,155,185,185,155,185,41,155,171,121,154,220,136,60,142,66,43,153,80,140,176,89,155,194,105,156,226,152,12,242,56,30,43,4,88,179,19,157,178,9,10,180,25,157,175,105,157,195,169,155,169,121,156,201,192,155,186,153,158,212,73,142,97,80,54,158,228,128,2,113,149,167,153,154,203,217,155,170,57,9,55,192,86,215,115,148,199,136,154,199,169,12,211,89,155,239,9,55,54,135,63,10,217,28,213,136,149,197,152,6,244,40,130,86,33,6,32,73,156,234,57,140,170,137,155,23,170,12,83,233,128,93,180,148,176,249,161,187,137,9,11,56,9,203,185,156,179,185,158,246,73,158,188,121,158,88,105,162,233,57,12,67,137,63,20,68,16,195,208,255,145,245,121,161,55,106,146,179,114,37,124,145,9,176,73,156,209,40,156,245,25,164,88,121,162,228,56,148,25,121,70,86,113,3,227,57,158,209,249,164,211,136,72,27,88,41,28,41,141,68,169,36,70,185,155,53,58,157,195,96,145,250,41,157,194,25,166,227,217,158,197,8,158,12,218,154,202,192,158,0,186,166,242,72,143,241,73,16,76,186,142,211,41,158,115,42,157,73,201,145,117,58,166,3,42,158,81,121,3,62,38,119,253,200,17,132,5,77,194,112,150,224,5,138,184,71,15,194,128,123,168,169,15,208,180,8,236,166,5,137,5,111,147,87,15,229,165,150,123,104,94,143,247,93,244,64,150,250,128,123,221,197,93,97,48,72,124,120,138,223,53,83,139,112,120,221,5,94,221,21,94,121,41,9,162,231,138,176,7,123,190,56,154,130,21,6,153,96,171,189,168,77,131,58,88,121,40,169,76,73,140,0,106,161,202,160,155,89,185,145,238,200,160,36,137,141,176,153,9,46,121,143,193,201,162,199,184,158,198,90,147,203,168,154,216,232,172,11,232,99,69,180,60,223,136,255,172,197,202,160,216,168,154,213,26,141,6,57,16,195,52,40,203,3,22,249,88,164,180,153,172,211,170,172,230,57,155,212,249,148,52,185,158,153,32,3,80,213,59,178,84,54,2,33,9,77,105,140,25,106,145,129,138,126,5,17,148,209,57,174,255,121,140,174,153,9,220,42,163,125,50,46,243,65,165,212,153,9,23,73,148,85,243,137,99,106,158,208,72,155,239,168,154,99,112,133,102,133,6,104,32,6,105,128,6,248,245,6,98,128,6,201,7,0,75,201,145,197,41,173,229,26,175,216,217,155,195,170,161,32,134,36,5,65,174,168,233,177,207,56,12,86,122,71,232,74,16,98,48,9,111,160,148,196,224,154,28,57,175,49,11,180,231,215,147,35,56,9,40,59,181,82,43,181,208,231,90,74,117,97,96,122,147,27,39,75,48,112,178,104,112,178,153,69,178,208,199,5,48,176,180,45,170,180,231,137,173,30,139,166,189,89,164,213,138,175,56,112,53,248,115,176,194,9,175,236,104,173,211,137,148,37,217,183,195,184,167,147,16,150,5,139,52,187,26,6,196,208,170,220,117,255,136,139,183,15,152,80,94,140,69,140,209,150,12,176,186,109,139,32,151,209,48,152,219,5,94,145,231,135,171,136,157,134,7,94,139,137,136,195,86,108,250,192,11,97,48,12,126,201,120,103,121,138,152,120,136,194,166,12,184,138,110,179,106,177,155,233,139,201,134,89,239,38,9,22,217,151,161,185,171,149,233,77,74,25,188,194,171,9,194,11,180,198,43,188,153,0,180,201,187,188,197,187,148,74,25,165,239,67,163,154,160,188,193,11,180,211,203,188,200,43,188,228,88,178,67,216,173,6,65,12,212,187,188,199,107,188,215,107,189,64,91,160,99,167,60,10,20,106,206,219,165,153,64,188,216,171,148,199,27,191,196,11,191,217,219,188,154,160,110,18,37,40,67,11,0,104,112,191,213,75,188,64,139,6,15,106,16,77,70,16,49,64,142,228,56,191,74,9,191,212,27,163,18,213,71,88,68,34,11,66,142,196,219,146,87,40,193,49,137,180,213,123,191,246,155,189,93,138,6,33,232,143,207,121,97,205,97,77,12,72,43,255,139,188,31,172,188,12,220,193,245,219,192,239,27,255,188,15,122,92,115,129,171,22,60,195,30,28,180,237,243,84,58,164,134,104,32,9,43,220,193,58,220,192,105,128,190,87,67,117,167,146,96,76,188,2,77,156,96,157,65,193,8,54,189,211,59,9,115,219,181,48,215,28,78,172,2,12,184,2,86,113,0,228,24,192,93,26,190,228,235,190,239,11,180,57,44,191,226,187,188,196,11,189,7,76,43,57,28,190,0,156,189,97,60,199,28,236,161,201,184,183,196,136,6,126,90,135,131,107,17,211,68,111,145,197,8,209,169,5,231,133,154,143,7,169,96,208,152,228,165,5,143,249,168,195,128,9,167,218,122,174,26,9,134,74,15,142,23,9,155,202,93,153,0,6,200,134,184,138,119,136,153,248,152,195,22,94,109,105,200,152,136,95,178,139,110,152,169,89,208,20,9,153,73,122,134,188,202,176,199,8,219,150,135,183,76,77,43,55,98,20,102,0,110,246,119,117,23,112,122,38,101,248,198,97,7,225,59,42,38,112,30,6,204,55,214,112,252,41,44,190,92,99,190,236,203,197,108,107,29,182,98,0,16,0,37,53,107,222,50,255,16,67,134,96,63,6,101,42,118,205,185,54,106,27,22,115,209,204,67,237,210,67,28,56,16,232,236,99,249,118,98,217,60,26,175,67,16,103,54,205,10,246,100,70,231,115,22,54,37,19,235,81,173,36,16,253,124,102,47,25,54,182,166,112,18,214,97,114,118,96,133,134,111,85,86,207,13,225,112,32,7,204,204,204,203,64,150,100,90,182,102,215,163,98,176,70,96,22,167,100,167,130,165,60,183,87,243,100,209,96,38,106,21,179,105,161,147,181,2,113,102,218,92,49,74,252,16,101,22,106,14,93,98,15,198,203,197,188,98,102,54,206,20,22,197,22,69,107,27,166,115,31,247,113,53,61,209,33,151,97,217,12,3,55,208,174,68,90,146,106,214,17,129,44,109,209,132,9,146,208,122,135,152,12,91,48,202,152,160,150,100,73,169,231,69,213,173,151,137,149,203,93,142,7,94,167,72,152,135,90,186,140,240,169,224,53,140,126,232,169,91,16,94,173,199,186,100,29,6,140,176,138,179,59,9,152,160,110,152,181,200,97,16,6,153,21,6,219,214,202,121,77,187,183,139,255,187,218,102,200,36,91,178,36,43,9,38,75,182,66,220,8,139,205,8,144,77,182,82,235,216,39,187,178,104,192,8,153,221,141,209,59,16,66,140,217,100,187,216,99,16,196,143,205,216,140,109,126,221,75,30,253,74,180,104,32,217,163,109,218,161,93,178,105,224,216,163,93,219,37,187,38,16,77,16,66,156,6,98,32,196,99,32,9,153,61,181,37,27,218,43,107,219,180,157,220,97,171,217,201,205,220,43,107,125,178,52,40,97,22,106,139,141,218,154,45,218,104,16,6,163,113,192,3,177,178,156,109,219,181,173,217,165,141,220,153,61,37,33,173,40,35,82,41,194,189,220,191,169,67,45,88,180,214,45,196,141,189,178,96,235,219,213,109,219,97,240,210,6,108,59,121,100,34,78,195,220,227,109,223,197,141,218,148,141,218,155,157,217,195,141,224,220,139,57,215,115,3,156,173,220,225,77,182,195,221,24,179,22,63,182,131,90,167,146,125,36,43,224,11,254,35,123,100,43,202,178,163,27,184,2,83,235,216,251,249,35,226,114,90,254,173,111,200,61,9,240,77,178,5,126,52,220,202,45,181,148,45,181,165,77,178,193,189,217,48,190,216,56,192,24,255,189,220,65,156,217,242,173,217,68,126,219,67,46,220,206,29,196,37,171,131,73,173,205,17,24,157,196,216,140,129,155,119,255,30,17,213,185,156,108,169,168,150,97,128,108,152,188,122,141,156,136,219,118,186,96,208,122,196,0,77,251,192,120,101,174,120,137,11,3,137,183,12,145,144,9,152,200,93,179,183,170,142,140,137,221,133,9,245,176,120,196,246,93,146,24,94,150,137,89,123,141,89,179,60,9,146,202,8,180,104,232,208,164,148,133,157,95,147,224,77,98,192,202,134,140,135,248,53,233,105,80,181,152,89,233,84,59,9,149,174,233,156,46,220,194,61,9,152,169,233,158,46,181,61,14,173,248,136,233,160,62,233,152,249,233,40,27,234,147,222,225,59,170,210,161,182,234,181,61,233,248,85,233,184,142,153,40,187,233,85,187,220,79,187,65,187,126,233,158,94,235,181,141,235,156,110,236,248,181,234,169,174,236,201,158,234,183,78,234,116,203,54,173,125,112,43,96,235,214,94,236,151,30,6,15,27,31,13,46,234,149,62,236,201,158,235,189,14,193,209,78,210,196,226,52,150,126,196,140,17,70,75,141,178,148,206,233,162,190,236,206,110,236,37,219,114,46,68,40,106,37,16,69,155,234,153,126,236,255,239,110,235,216,238,236,202,62,181,5,202,218,115,17,3,150,206,239,157,174,240,104,176,237,19,18,46,230,193,66,249,46,16,97,80,235,161,238,219,39,206,237,130,146,174,21,228,147,255,136,143,187,62,149,88,132,239,78,3,3,157,30,240,200,142,234,186,94,181,1,223,235,254,222,234,98,96,239,209,174,239,43,79,236,240,110,237,182,158,233,45,255,236,22,47,141,230,103,104,12,40,132,66,47,119,84,254,83,211,86,77,140,208,184,141,44,77,152,48,12,146,16,200,202,208,120,219,166,89,195,64,15,109,121,182,220,229,168,153,192,186,146,64,5,139,231,135,167,203,186,182,124,168,100,249,245,244,0,231,244,176,15,171,7,121,171,183,120,128,77,203,138,46,232,184,74,139,211,4,6,251,30,232,133,93,139,208,68,200,158,201,8,148,90,236,74,222,235,216,14,248,158,30,248,84,75,220,130,207,8,158,221,191,243,233,242,97,251,248,142,15,248,4,47,26,131,194,23,49,48,181,128,47,181,97,59,219,142,47,196,227,110,111,33,133,16,128,125,248,142,111,233,65,30,218,255,184,141,249,170,175,233,36,43,181,39,139,219,46,222,141,10,5,209,78,99,0,235,45,223,39,235,249,37,142,3,35,204,237,5,129,3,186,95,250,37,62,248,193,55,33,86,130,79,232,142,237,76,254,39,142,2,252,184,141,219,186,63,236,155,255,250,168,47,9,56,224,240,151,19,147,27,62,236,133,127,217,155,223,250,141,61,248,65,62,253,72,62,30,173,221,248,152,223,253,233,143,219,127,12,211,220,60,43,211,111,218,237,191,210,165,245,181,133,63,255,111,163,2,131,207,253,208,79,250,0,129,102,146,64,130,3,13,22,68,35,41,141,194,27,43,0,60,124,72,5,34,0,49,104,22,94,84,40,41,97,154,132,22,59,90,204,136,81,100,199,131,3,197,132,49,16,3,64,12,150,45,93,174,4,176,34,229,68,154,53,109,218,132,161,69,167,150,156,58,147,209,11,3,35,76,50,157,91,180,132,137,196,115,152,206,156,146,22,193,192,180,47,147,22,42,202,244,89,21,3,70,31,189,171,244,96,72,218,106,85,75,166,173,250,246,29,229,74,76,203,86,174,202,84,88,255,29,22,70,159,190,48,97,148,209,83,54,118,82,166,189,125,251,98,18,154,73,69,152,157,60,13,107,65,195,87,241,94,49,134,195,240,149,148,19,140,78,145,37,67,102,156,116,49,243,101,140,150,209,196,112,56,209,143,196,135,153,56,75,154,116,186,164,65,49,42,32,82,65,229,167,230,36,131,152,5,134,44,89,16,163,152,24,48,30,170,136,45,155,166,138,52,185,141,235,86,88,178,243,237,133,2,107,231,230,18,17,182,31,215,175,73,175,64,110,176,114,195,155,42,132,67,12,83,28,161,113,145,10,91,223,252,14,96,52,196,146,220,39,122,23,190,69,123,242,242,11,45,139,55,121,83,191,77,49,180,199,143,215,12,179,250,106,219,237,134,137,80,161,41,6,242,46,155,15,13,49,246,211,207,15,9,133,195,78,187,207,32,196,112,56,234,92,11,0,53,129,196,48,48,67,253,14,200,228,63,229,78,171,15,197,203,88,162,137,180,135,250,67,145,192,212,138,179,207,196,130,146,19,232,6,149,84,58,96,133,24,110,0,81,140,147,132,20,146,197,24,12,16,49,73,255,0,12,131,33,39,39,181,80,70,25,162,134,25,6,134,97,192,200,73,153,156,160,25,70,5,38,143,210,103,41,21,160,161,135,171,42,233,89,166,172,48,192,72,147,43,24,120,177,234,174,45,233,33,234,46,50,37,81,97,43,73,228,162,211,75,171,96,200,100,177,55,246,58,138,47,24,24,145,4,177,200,14,211,66,140,64,39,169,43,140,138,246,236,233,73,38,125,123,8,211,76,1,8,0,73,0,12,112,200,83,36,85,64,50,128,79,31,50,192,84,223,58,229,212,166,216,170,51,21,128,3,126,155,245,161,89,73,109,213,0,215,60,173,137,10,225,92,60,53,213,83,89,85,129,216,86,73,53,21,215,154,38,180,137,85,136,116,69,53,52,104,77,29,213,83,149,62,221,53,86,36,67,213,150,83,101,171,123,40,61,0,80,1,119,85,104,97,194,54,214,253,124,173,169,58,104,111,245,20,211,105,117,229,85,5,23,125,149,48,92,154,120,5,0,220,223,252,32,119,162,115,207,165,54,86,110,251,133,144,10,133,149,252,84,91,105,109,221,117,87,78,161,29,181,86,255,115,251,21,246,61,123,247,141,201,211,98,61,117,54,166,223,24,142,72,66,23,207,245,23,162,209,82,230,149,95,127,237,245,55,99,155,86,86,210,221,135,146,109,21,83,153,142,141,85,226,108,149,133,65,221,101,193,69,210,226,103,179,61,21,219,164,67,75,55,233,164,85,56,128,37,32,167,22,50,12,28,112,176,250,6,92,175,37,25,66,166,48,25,70,24,194,156,196,132,41,70,42,37,44,12,42,160,76,52,167,179,181,200,179,74,76,184,34,83,25,42,48,217,138,204,73,180,88,36,78,45,192,226,170,49,40,233,169,114,46,174,148,210,39,167,48,134,217,39,209,69,50,161,66,49,73,22,19,12,50,52,154,154,234,73,197,15,235,201,203,47,53,223,130,72,209,29,20,189,116,211,171,62,29,135,33,65,228,90,101,4,1,128,129,72,73,79,167,125,116,247,34,250,141,180,217,75,159,93,117,34,73,63,253,118,9,3,166,105,247,218,75,63,227,116,227,105,95,190,116,173,223,123,143,58,136,82,63,189,117,154,76,6,55,6,211,155,63,254,218,133,213,155,144,217,255,233,69,127,62,122,225,184,23,18,13,227,209,0,242,247,244,65,76,121,248,137,100,146,169,165,137,218,71,127,117,222,197,240,93,121,231,153,238,151,10,192,37,59,209,113,79,125,5,100,137,107,52,133,158,234,72,143,34,68,210,81,77,98,35,17,237,117,239,101,223,81,65,233,172,7,31,23,249,38,104,44,129,1,215,84,0,60,247,85,132,123,97,32,29,9,249,119,60,29,185,70,128,225,250,14,234,106,151,191,138,28,79,116,88,35,160,144,128,132,195,35,209,143,95,93,187,137,97,238,82,22,122,68,2,6,84,80,155,230,114,66,5,39,193,64,108,77,228,73,85,154,162,39,58,125,5,47,152,32,70,50,154,164,133,125,120,69,11,49,80,198,82,156,164,143,169,152,134,24,85,226,73,80,120,162,2,52,54,41,118,148,83,204,154,8,227,165,216,141,237,115,112,187,163,230,152,36,41,172,169,110,135,86,3,36,14,169,54,200,32,241,79,82,84,227,99,24,98,144,50,239,144,38,6,135,212,97,144,8,57,201,66,134,8,97,213,121,29,0,252,120,146,62,26,146,255,147,129,4,228,212,98,112,128,234,224,75,34,254,250,163,32,13,217,71,80,170,174,149,171,148,100,44,89,57,75,171,45,82,63,236,130,8,45,113,8,202,27,148,111,89,38,3,207,38,83,25,36,93,102,13,126,48,132,97,248,38,50,59,32,177,232,53,222,169,142,246,138,185,73,64,122,114,146,208,203,215,139,60,25,201,147,168,132,106,177,4,146,213,86,25,72,79,178,146,106,157,12,231,181,192,245,157,71,170,110,150,65,170,230,14,137,41,206,21,138,206,122,210,243,87,59,173,198,72,96,30,0,146,149,4,17,41,163,247,44,120,70,16,34,174,89,207,167,132,228,202,78,178,78,147,226,12,231,59,205,57,206,119,66,114,146,182,4,31,50,95,36,78,116,202,178,149,31,165,165,53,35,73,201,35,65,13,106,64,196,144,147,134,168,140,125,88,165,30,90,218,98,78,232,24,83,60,238,99,108,76,4,157,84,84,32,211,191,117,41,138,77,146,68,94,154,120,68,24,168,160,136,59,229,73,81,127,106,24,193,128,197,40,122,161,220,64,144,234,36,156,50,17,110,50,255,125,210,76,175,138,199,156,248,14,127,174,44,103,34,11,41,78,178,226,112,151,194,108,200,15,189,3,145,24,120,53,146,146,250,103,89,71,202,27,239,137,38,62,237,195,223,39,25,42,86,172,53,164,58,192,89,207,90,31,162,61,184,214,19,175,156,228,102,251,84,89,214,194,170,114,72,139,29,229,45,211,83,181,189,50,84,135,43,72,153,202,128,249,144,112,174,80,174,244,116,44,32,185,150,77,124,1,108,34,214,44,31,246,38,210,206,133,138,149,175,124,125,236,104,71,3,172,120,122,20,0,161,3,168,88,229,249,85,216,194,211,178,83,107,160,190,170,227,88,28,2,20,156,115,5,37,111,52,116,80,109,98,205,122,224,163,160,72,203,90,212,129,142,111,106,161,193,23,194,30,178,130,66,158,245,144,220,205,109,101,17,11,91,136,110,243,176,173,155,208,247,96,231,201,106,110,115,119,138,253,100,107,195,27,223,77,158,68,6,65,251,32,74,51,180,83,21,204,237,42,101,177,138,62,152,180,211,38,169,32,81,131,9,138,147,102,90,37,2,79,53,169,110,76,170,255,97,84,0,134,6,71,88,40,91,156,170,230,118,58,71,55,190,113,47,147,219,11,10,113,250,224,45,36,184,46,74,116,227,136,155,180,133,136,90,116,188,150,165,231,31,195,42,73,28,232,72,71,45,9,64,202,212,123,131,106,154,21,68,190,99,165,36,107,105,191,224,2,0,95,213,9,235,38,45,11,80,16,106,182,129,49,60,231,63,21,11,73,198,122,118,175,43,244,113,121,187,235,75,35,219,245,180,45,182,50,92,113,128,209,95,38,20,0,50,62,172,111,255,217,80,131,194,39,119,217,228,44,98,65,147,204,4,93,217,199,157,172,242,31,157,185,217,92,242,113,155,136,237,40,71,253,92,88,223,190,216,207,243,212,161,247,132,35,27,215,132,225,176,228,172,242,234,58,11,75,209,190,38,189,47,164,8,112,127,73,193,195,186,181,133,215,251,114,162,75,38,46,3,196,87,158,85,246,49,162,59,253,218,33,77,173,153,55,22,232,191,26,201,86,196,78,25,150,55,48,235,154,123,252,98,196,194,83,185,59,66,151,126,83,42,148,46,134,133,45,100,34,106,26,161,255,36,12,60,213,165,74,42,246,18,165,184,74,96,38,226,116,167,214,206,234,26,11,76,84,12,23,213,219,10,198,240,85,19,211,23,67,37,152,191,73,197,83,236,248,235,109,171,82,59,118,83,227,194,13,226,61,75,30,223,64,6,142,238,107,95,167,86,75,69,222,184,37,42,88,164,45,227,71,26,56,107,111,223,53,118,52,136,122,201,226,31,225,24,6,43,160,238,5,233,188,146,131,39,188,222,250,86,184,67,157,172,81,0,88,109,11,8,199,181,197,179,102,76,92,179,184,143,23,199,247,200,121,12,242,190,102,124,225,49,16,218,245,210,67,242,190,6,178,228,231,42,179,139,120,67,114,87,255,56,229,189,244,184,189,21,249,100,7,194,57,211,125,197,168,248,216,234,104,87,171,92,180,249,14,131,12,154,25,117,217,2,171,227,32,143,122,47,219,202,226,80,250,124,229,23,199,117,47,189,14,245,144,139,157,199,82,215,158,108,213,179,177,76,79,205,156,80,175,241,143,106,252,227,122,43,28,7,31,111,221,11,211,211,71,103,106,87,66,46,108,121,189,155,41,134,255,28,131,122,122,162,84,52,6,251,53,247,144,63,82,232,33,71,56,200,211,254,163,158,159,157,199,13,247,55,75,86,64,74,129,51,87,61,25,29,108,217,21,62,242,200,147,254,235,54,255,57,212,95,66,74,214,195,238,33,251,16,246,126,248,59,12,122,144,137,76,255,229,202,35,243,52,22,3,87,73,40,139,139,41,129,155,212,165,14,115,123,219,73,205,176,240,155,100,213,2,107,251,115,83,197,105,96,142,50,16,133,192,45,40,204,247,82,133,245,248,109,111,11,52,199,179,18,104,104,28,242,253,98,185,198,33,231,23,153,77,50,123,19,92,194,57,0,65,235,151,169,198,111,254,155,49,119,253,94,134,207,95,227,191,93,111,229,216,255,229,239,153,146,177,180,191,202,49,80,17,25,244,235,191,242,19,153,160,81,64,244,115,64,145,249,63,255,139,63,0,252,161,235,1,22,149,40,150,9,52,149,194,59,169,238,48,58,132,33,165,194,19,191,244,19,191,255,35,37,153,1,159,245,192,37,136,145,192,191,82,175,145,33,65,254,75,150,78,201,192,143,41,151,247,160,255,130,204,162,191,247,19,25,147,138,21,156,25,63,132,249,191,244,171,193,25,164,63,135,40,22,223,80,167,81,131,153,223,136,64,14,1,64,40,196,25,132,9,194,242,243,152,95,250,171,88,123,141,112,33,154,249,139,192,5,82,153,213,226,191,137,80,47,23,65,194,126,153,149,194,43,188,253,203,192,80,217,65,14,153,136,152,211,63,245,19,14,132,42,151,8,236,65,60,68,66,17,132,192,35,60,192,254,11,26,80,17,196,157,137,189,253,218,34,34,202,155,182,16,48,43,105,170,200,64,42,226,251,182,165,90,62,227,227,42,231,107,62,158,154,41,111,67,62,109,59,183,109,155,196,254,8,131,17,58,177,200,152,132,6,115,163,177,217,182,117,3,184,149,56,169,35,233,33,80,193,175,3,128,1,89,148,197,247,163,197,89,196,197,19,12,32,32,130,166,181,251,13,65,116,197,92,60,169,251,107,23,237,202,40,7,178,21,87,116,197,148,96,198,101,36,196,127,57,40,100,172,197,88,204,197,16,106,198,102,92,137,102,188,197,109,172,70,110,140,154,107,4,160,46,83,255,25,171,11,198,91,116,69,45,164,67,171,139,154,108,84,9,36,41,41,81,201,70,92,124,191,247,147,137,117,250,187,21,68,67,92,52,70,50,28,153,90,113,154,125,172,137,78,41,60,127,108,17,136,136,185,144,217,20,91,57,26,91,132,129,153,40,149,132,108,152,106,12,128,87,172,159,104,148,13,217,112,164,107,92,198,141,132,150,12,68,21,33,188,25,101,145,185,234,96,61,223,176,151,108,202,39,141,100,198,53,84,24,137,72,15,96,172,192,45,148,24,117,193,21,144,225,23,36,217,22,152,208,148,23,194,180,36,113,51,149,1,23,134,148,197,35,241,198,134,28,165,106,84,73,142,60,18,252,250,199,66,20,17,55,18,131,255,178,19,122,104,169,179,225,175,157,218,2,76,120,139,162,10,10,58,186,42,225,139,190,171,132,150,162,226,175,0,114,33,215,51,201,76,225,73,207,251,43,175,156,42,2,131,148,212,104,146,147,208,28,72,185,182,2,115,202,12,161,73,76,35,70,251,35,56,146,17,160,190,68,72,35,251,192,174,105,75,209,232,203,188,204,75,96,121,255,65,159,244,64,171,19,145,196,108,151,9,249,201,36,1,22,253,59,203,225,208,174,204,92,23,245,131,16,201,28,153,191,98,52,199,36,76,133,17,44,97,99,36,207,19,71,113,193,193,194,76,18,102,65,198,253,122,25,24,180,191,75,178,205,56,4,200,154,49,37,209,80,204,222,244,205,131,34,170,69,24,134,40,193,139,51,10,197,14,11,3,176,33,176,227,108,34,83,236,201,223,244,73,111,115,183,157,194,19,158,176,74,77,196,48,232,196,16,23,50,77,193,122,78,75,51,70,214,148,189,126,249,187,200,132,33,200,228,69,237,84,79,205,220,66,148,98,187,146,1,77,141,233,154,239,113,77,11,60,165,223,112,161,179,196,76,253,20,32,244,108,160,28,228,203,192,228,79,253,52,203,38,212,15,29,139,207,201,188,200,239,84,18,211,204,205,104,52,178,28,140,205,214,20,79,17,1,166,250,180,180,251,52,75,219,12,204,205,44,80,244,140,158,252,132,193,253,44,45,51,163,205,245,68,81,37,121,48,233,92,183,227,163,163,117,99,62,110,75,208,20,237,14,55,50,224,197,14,251,74,26,109,208,100,154,173,210,178,186,25,101,66,146,41,79,29,37,210,34,245,23,95,177,71,16,221,175,7,133,30,153,195,16,202,116,141,18,13,159,41,165,82,12,61,79,130,75,175,42,173,82,95,81,82,244,208,47,36,149,136,46,245,76,233,208,82,42,237,208,9,45,70,32,82,152,139,172,80,75,219,16,242,148,82,147,209,82,46,37,70,23,186,71,242,44,83,57,165,153,34,229,211,148,202,62,8,139,41,236,187,68,228,139,184,62,117,79,61,98,80,67,125,205,209,48,83,253,202,172,198,132,16,19,173,25,246,84,212,223,20,151,251,211,49,148,84,186,241,28,14,32,221,24,43,189,82,132,98,84,46,101,212,81,53,85,234,0,81,162,59,37,61,53,85,82,61,85,113,52,79,97,99,151,247,156,84,245,112,85,61,37,85,126,236,142,118,1,82,205,58,208,8,189,80,57,189,85,82,117,85,0,253,76,241,105,213,100,149,212,74,255,101,214,126,9,84,165,106,81,233,36,84,1,162,174,102,53,204,245,195,71,107,141,212,82,21,211,154,41,165,110,189,158,94,29,14,112,213,214,117,185,207,101,165,84,207,27,210,217,178,204,0,141,213,1,220,86,7,10,204,150,164,215,122,165,87,242,220,85,91,173,67,123,229,215,28,244,215,40,237,210,212,140,61,234,104,211,72,205,157,122,109,213,231,84,210,245,139,207,40,125,161,108,237,149,33,181,23,126,157,216,137,253,87,132,218,78,70,61,216,81,237,78,208,20,215,114,229,69,82,225,175,142,84,63,48,4,217,216,43,173,147,221,206,143,245,204,94,140,208,37,37,207,14,157,79,197,83,217,95,29,181,55,69,211,39,237,23,36,229,184,12,129,179,68,245,217,130,13,23,114,221,143,156,21,13,162,245,64,134,97,89,112,1,90,155,133,216,197,52,179,25,245,87,208,147,44,150,133,198,95,109,36,161,173,217,173,229,90,26,61,201,167,237,90,20,109,218,49,229,179,207,180,14,210,64,218,147,181,88,140,204,193,246,148,189,108,50,51,116,181,204,154,81,65,163,255,13,67,148,197,144,180,245,82,35,245,84,183,253,205,182,85,77,179,61,218,190,212,91,245,147,204,70,178,218,176,85,220,197,5,76,127,209,90,198,45,210,89,157,205,132,145,91,200,77,218,127,65,210,0,61,73,141,253,60,235,128,89,167,156,181,124,21,91,203,77,87,210,141,76,132,18,211,196,53,221,213,101,93,67,165,213,214,133,92,151,109,221,58,93,39,83,10,31,31,197,167,22,81,221,237,236,149,194,101,221,221,133,221,244,148,91,224,253,220,224,53,222,227,205,88,228,101,86,208,132,84,229,181,137,53,229,82,98,141,222,189,213,78,70,114,88,231,197,94,144,245,221,236,229,222,238,141,189,215,245,94,208,101,63,76,29,90,193,117,222,175,21,214,81,173,89,226,13,223,246,109,210,52,117,223,248,149,95,186,229,210,131,218,222,249,221,175,46,181,219,248,133,94,245,229,90,246,197,223,0,30,219,0,38,224,240,69,95,222,44,96,232,236,201,82,234,222,25,21,80,0,254,205,1,78,224,9,182,89,10,182,224,6,246,223,157,189,96,197,60,205,19,221,224,173,85,213,193,15,22,225,17,38,225,6,238,79,4,46,97,247,76,225,21,102,225,22,118,225,23,230,93,252,124,153,251,133,225,26,182,225,27,198,225,28,150,223,168,125,92,29,158,95,8,110,86,32,246,225,33,38,226,22,166,225,34,70,98,245,20,226,36,6,217,37,102,98,24,22,216,153,121,98,15,158,226,62,117,226,42,198,126,226,44,54,222,43,214,226,46,246,98,247,229,226,47,134,225,30,22,227,50,54,227,51,70,227,15,6,223,52,102,227,54,118,227,55,14,223,253,133,227,57,166,227,58,182,227,38,14,227,59,214,227,61,230,227,62,102,82,63,6,228,64,22,228,65,46,93,66,54,228,67,70,228,68,86,228,69,102,228,70,118,228,71,134,228,72,150,228,73,166,228,74,182,228,75,198,228,76,214,228,77,230,228,78,246,228,79,6,229,80,22,229,81,14,228,60,38,229,83,70,229,84,86,229,85,102,33,229,86,118,229,87,134,229,88,150,229,89,166,229,90,182,229,91,198,229,92,214,229,93,230,229,94,246,229,95,190,225,128,0,0,59";
                    var len = newbytearray.Split(',').Length;
                    var arrbytes = new byte[len];

                    var c = 0;
                    foreach (var i in newbytearray.Split(','))
                    {
                        arrbytes[c] = byte.Parse(i);
                        c++;
                    }

                    return Image.FromStream(new MemoryStream(arrbytes));
                }
            }

            protected override void OnMouseDown(MouseEventArgs e)

            {
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Left)
                {
                    Capture = false;
                    Message msg = Message.Create(Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                    WndProc(ref msg);
                }
            }

            public PrettyDemoLockInterface()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrettyDemoLockInterface));
                buttonsaveandclose = new Button();
                _labelsurvinstincts = new Label();
                ExampleCombo = new ComboBox();
                ExampleNum = new NumericUpDown();
                PictureBox1 = new PictureBox();
                _groupBox1 = new GroupBox();
                AutoAoECheck = new CheckBox();
                ((System.ComponentModel.ISupportInitialize)(ExampleNum)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(PictureBox1)).BeginInit();
                _groupBox1.SuspendLayout();
                SuspendLayout();
                // 
                // buttonsaveandclose
                // 
                buttonsaveandclose.Location = new Point(638, 332);
                buttonsaveandclose.Name = "buttonsaveandclose";
                buttonsaveandclose.Size = new Size(117, 23);
                buttonsaveandclose.TabIndex = 17;
                buttonsaveandclose.Text = "Save and Close";
                buttonsaveandclose.UseVisualStyleBackColor = true;
                // 
                // 
                // labelsurvinstincts
                // 
                _labelsurvinstincts.AutoSize = true;
                _labelsurvinstincts.BackColor = Color.Transparent;
                _labelsurvinstincts.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                _labelsurvinstincts.ForeColor = SystemColors.Control;
                _labelsurvinstincts.Location = new Point(6, 27);
                _labelsurvinstincts.Name = "labelsurvinstincts";
                _labelsurvinstincts.Size = new Size(141, 15);
                _labelsurvinstincts.TabIndex = 12;
                _labelsurvinstincts.Text = "Survival Instincts Percent";
                // 
                // ExampleCombo
                // 
                ExampleCombo.FormattingEnabled = true;
                ExampleCombo.Items.AddRange(new object[]
                {
                    "Always",
                    "Never",
                    "OnBoss"
                });
                ExampleCombo.Location = new Point(163, 24);
                ExampleCombo.Name = "ExampleCombo";
                ExampleCombo.Size = new Size(80, 23);
                ExampleCombo.TabIndex = 19;
                // 
                // pictureBox1
                // 
                PictureBox1.BackColor = Color.Transparent;
                PictureBox1.Location = new Point(4, 6);
                PictureBox1.Name = "PictureBox1";
                PictureBox1.Size = new Size(765, 127);
                PictureBox1.TabIndex = 23;
                PictureBox1.TabStop = false;
                // 
                // groupBox1
                // 
                _groupBox1.Controls.Add(ExampleNum);
                _groupBox1.Controls.Add(_labelsurvinstincts);
                _groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                _groupBox1.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                _groupBox1.Location = new Point(262, 139);
                _groupBox1.Name = "groupBox1";
                _groupBox1.Size = new Size(249, 193);
                _groupBox1.TabIndex = 21;
                _groupBox1.TabStop = false;
                _groupBox1.Text = "Defensive Cooldowns";
                // 
                // ExampleCheck
                // 
                AutoAoECheck.AutoSize = true;
                AutoAoECheck.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                AutoAoECheck.ForeColor = SystemColors.Control;
                AutoAoECheck.Location = new Point(6, 25);
                AutoAoECheck.Name = "AutoAoECheck";
                AutoAoECheck.Size = new Size(238, 19);
                AutoAoECheck.TabIndex = 1;
                AutoAoECheck.Text = "Auto AoE (Blade Flurry)";
                AutoAoECheck.UseVisualStyleBackColor = true;
                // 
                // DestroLockInterface
                // 
                AutoScaleDimensions = new SizeF(6F, 13F);
                AutoScaleMode = AutoScaleMode.Font;
                BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                ClientSize = new Size(773, 370);
                Controls.Add(_groupBox1);
                Controls.Add(PictureBox1);
                Controls.Add(buttonsaveandclose);
                ForeColor = SystemColors.ControlText;
                FormBorderStyle = FormBorderStyle.None;
                Name = "PrettyDemoLockInterface";
                StartPosition = FormStartPosition.CenterParent;
                Text = "PrettyDemoLock";
                ((System.ComponentModel.ISupportInitialize)(ExampleNum)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(PictureBox1)).EndInit();
                _groupBox1.ResumeLayout(false);
                _groupBox1.PerformLayout();
                ResumeLayout(false);
            }

            public Button buttonsaveandclose;
            private Label _labelsurvinstincts;
            private GroupBox _groupBox1;
            public ComboBox ExampleCombo;
            public CheckBox AutoAoECheck;
            public PictureBox PictureBox1;
            public NumericUpDown ExampleNum;

        }

        #endregion
    }
}

/*
[AddonDetails.db]
AddonAuthor=zan
AddonName=blub
WoWVersion=Legion - 70000
[SpellBook.db]
Range,686,Shadow Bolt,

Spell,267171,Demonic Strength,
Spell,267211,Bilescourge Bombers,
Spell,104316,Call Dreadstalkers,
Spell,686,Shadow Bolt,
Spell,264178,Demonbolt,
Spell,264130,Power Siphon,
Spell,264057,Soul Strike,
Spell,264119,Summon Vilefiend,
Spell,111898,Grimoire: Felguard,
Spell,104773,UnendingResolve,
Spell,5512,Healthstone,
Spell,265187,Summon Demonic Tyrant,
Spell,105174,Hand of Gul'dan,
Spell,196277,Implosion,
Spell,267102,Demonic Core,
Spell,234153,Drain Life,
Spell,265412,Doom,
Spell,108416,Dark Pact,
Spell,267217,Nether Portal,
Spell,33702,Blood Fury,

Talent,267171,Demonic Strength
Talent,267211,Bilescourge Bombers
Talent,264130,Power Siphon
Talent,264057,Soul Strike
Talent,264119,Summon Vilefiend
Talent,111898,Grimoire: Felguard
Talent,265412,Doom
Talent,108416,Dark Pact
Talent,267217,Nether Portal

Item,5512,Healthstone,
Spell,30283,Shadow Fury,

Buff,267217,Nether Portal
Buff,264173,Demonic Core
Buff,205145,Demonic Calling
Buff,265273,Demonic Power


Debuff,265412,Doom
*/
