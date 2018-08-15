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
    public class Destro : CombatRoutine
    {
        public override string Name
        {
            get
            {
                return "Demo";
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
            Log.Write("Welcome to Demo", Color.Purple);
        }
        private static bool _ForceAoE;

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
        public override void Stop()
        {

        }
        public override void Pulse()
        {
            if (WoW.PlayerIsInCombat && WoW.TargetIsEnemy && WoW.IsSpellInRange("Shadow Bolt") && !WoW.PlayerIsChanneling)
            {
                AoECheck();
                //Log.Write(String.Format("Bilescourge Bombers : " + WoW.IsSpellAvailable("Bilescourge Bombers")), Color.Blue);
                //Log.Write(String.Format("Doom : " + WoW.IsSpellAvailable("Doom")), Color.Blue);
                //Log.Write(String.Format("Soul Strike : " + WoW.IsSpellAvailable("Soul Strike")), Color.Blue);
                //Log.Write(String.Format("Summon Vilefiend Available: " + WoW.IsSpellAvailable("Summon Vilefiend")), Color.Blue);
                //Log.Write(String.Format("Summon Vilefiend OnCooldown: " + WoW.IsSpellOnCooldown("Summon Vilefiend")), Color.Blue);
                //Log.Write(String.Format("Summon Vilefiend CD Remaining: " + WoW.PlayerCooldownTimeRemaining("Summon Vilefiend")), Color.Blue);
                // Log.Write(String.Format("IsSpellOnCooldown Soul Strike : " + WoW.IsSpellOnCooldown("Soul Strike")), Color.Blue);

                //def->add_action("demonic_strength");
                if (WoW.CanCast("Demonic Strength") && WoW.IsSpellAvailable("Demonic Strength") && !WoW.IsSpellOnCooldown("Demonic Strength") && WoW.UseCooldowns)
                {
                    WoW.CastSpell("Demonic Strength");
                    return;
                }

                //def->add_action("summon_vilefiend,if=cooldown.summon_demonic_tyrant.remains>30|(cooldown.summon_demonic_tyrant.remains<10&cooldown.call_dreadstalkers.remains<10)");+
                if (WoW.CanCast("Summon Vilefiend") && WoW.IsSpellAvailable("Summon Vilefiend") && !WoW.IsSpellOnCooldown("Summon Vilefiend") && (WoW.PlayerCooldownTimeRemaining("Summon Demonic Tyrant") > 30 ||
                    (WoW.PlayerCooldownTimeRemaining("Summon Demonic Tyrant") < 10 && WoW.PlayerCooldownTimeRemaining("Call Dreadstalkers") < 10)))
                {
                    WoW.CastSpell("Summon Vilefiend");
                    return;
                }
                //def->add_action("grimoire_felguard");
                if (WoW.CanCast("Grimoire: Felguard") && WoW.IsSpellAvailable("Grimoire: Felguard") && !WoW.IsSpellOnCooldown("Grimoire: Felguard") && WoW.UseCooldowns)
                {
                    WoW.CastSpell("Grimoire: Felguard");
                    return;
                }
                //def->add_action("hand_of_guldan,if=soul_shard>=5");
                if (WoW.CanCast("Hand of Gul'dan") && WoW.CurrentSoulShards >= 5 && WoW.IsSpellOnCooldown("Call Dreadstalkers"))
                {
                    WoW.CastSpell("Hand of Gul'dan");
                    
                    return;
                }



                //def->add_action("hand_of_guldan,if=soul_shard>=3&cooldown.call_dreadstalkers.remains>4&(!talent.summon_vilefiend.enabled|cooldown.summon_vilefiend.remains>4)");
                if (WoW.CanCast("Hand of Gul'dan") && WoW.CurrentSoulShards >= 3 &&
                    WoW.PlayerCooldownTimeRemaining("Call Dreadstalkers") > 4 &&
                    (!WoW.IsSpellAvailable("Summon Vilefiend") || WoW.PlayerCooldownTimeRemaining("Summon Vilefiend") > 4))
                {
                    WoW.CastSpell("Hand of Gul'dan");
                    return;
                }
                // Cast Implosion on 5+ stacked Targets
                if (WoW.CanCast("Implosion") && _ForceAoE)
                {
                    WoW.CastSpell("Implosion");
                    return;
                }
                //def->add_action("call_dreadstalkers");
                if (WoW.CanCast("Call Dreadstalkers") && !WoW.IsSpellOnCooldown("Call Dreadstalkers") && (WoW.CurrentSoulShards >= 2/* || (WoW.CurrentSoulShards >= 1 && WoW.PlayerHasBuff("Demonic Calling"))*/))
                {
                    WoW.CastSpell("Call Dreadstalkers");
                    return;
                }
                //def->add_action("bilescourge_bombers");
                if (WoW.CanCast("Bilescourge Bombers") && WoW.IsSpellAvailable("Bilescourge Bombers") && WoW.CurrentSoulShards >= 2)
                {
                    WoW.CastSpell("Bilescourge Bombers");
                    return;
                }
                //def->add_action("summon_demonic_tyrant,if=talent.summon_vilefiend.enabled&buff.dreadstalkers.remains>action.summon_demonic_tyrant.cast_time&buff.vilefiend.remains>action.summon_demonic_tyrant.cast_time");
                if (WoW.CanCast("Summon Demonic Tyrant") && !WoW.IsSpellOnCooldown("Summon Demonic Tyrant") && WoW.UseCooldowns && WoW.GetAsyncKeyState(Keys.NumPad3) < 0)
                {
                    WoW.CastSpell("Summon Demonic Tyrant");
                    return;
                }
                //def->add_action("summon_demonic_tyrant,if=!talent.summon_vilefiend.enabled&buff.dreadstalkers.remains>action.summon_demonic_tyrant.cast_time&soul_shard=0");
                //def->add_action("power_siphon,if=buff.wild_imps.stack>=2&buff.demonic_core.stack<=2&buff.demonic_power.down");
                if (WoW.CanCast("Power Siphon") && WoW.IsSpellAvailable("Power Siphon") && !WoW.IsSpellOnCooldown("Power Siphon") && WoW.PlayerBuffStacks("Wild Imps") >= 2 &&
                    WoW.PlayerBuffStacks("Demonic Core") <= 2 && !WoW.PlayerHasBuff("Demonic Power"))
                {
                    WoW.CastSpell("Power Siphon");
                    return;
                }
                //def->add_action("demonbolt,if=soul_shard<=3&buff.demonic_core.up");
                if (WoW.CanCast("Demonbolt") && WoW.CurrentSoulShards <= 3 && WoW.PlayerBuffStacks("Demonic Core") >= 1)
                {
                    WoW.CastSpell("Demonbolt");
                    return;
                }
                //def->add_action("doom,cycle_targets=1,if=(talent.doom.enabled&target.time_to_die>duration&(!ticking|remains<duration*0.3))");
                if (WoW.CanCast("Doom") && WoW.IsSpellAvailable("Doom") && (!WoW.TargetHasDebuff("Doom") || WoW.TargetDebuffTimeRemaining("Doom") <= 9))
                {
                    WoW.CastSpell("Doom");
                    return;
                }
                //def->add_action("call_action_list,name=build_a_shard");
                //action_priority_list_t* def = get_action_priority_list("default");
                //action_priority_list_t* aoe = get_action_priority_list("aoe");
                //bas->add_action("soul_strike");
                if (WoW.CanCast("Soul Strike") && WoW.IsSpellAvailable("Soul Strike") && !WoW.IsSpellOnCooldown("Soul Strike") && WoW.CurrentSoulShards < 5)
                {
                    WoW.CastSpell("Soul Strike");
                    return;
                }
                
                //bas->add_action("shadow_bolt");
                if (WoW.CanCast("Shadow Bolt") && WoW.CurrentSoulShards < 5)
                {
                    WoW.CastSpell("Shadow Bolt");
                    return;
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
Spell,265339,Imp Swarm,
Spell,265412,Doom,
Spell,108416,Dark Pact,

Item,5512,Healthstone,



Buff,264173,Demonic Core
Buff,205145,Demonic Calling
Buff,265273,Demonic Power


Debuff,265412,Doom
*/

