using Frontline.Domain;
using protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class UnitLevelUpEventArgs : EventArgs
    {
        public UnitInfo UnitInfo { get; set; }
        public int OldLevel { get; set; }
    }

    public class UnitGradeUpEventArgs : EventArgs
    {
        public UnitInfo UnitInfo { get; set; }
        public int OldGrade { get; set; }
    }

    public class EquipLevelUpEventArgs : EventArgs
    {
        public UnitInfo UnitInfo { get; set; }
        public EquipInfo EquipInfo { get; set; }
        public int OldLevel { get; set; }
    }

    public class EquipGradeUpEventArgs : EventArgs
    {
        public UnitInfo UnitInfo { get; set; }
        public EquipInfo EquipInfo { get; set; }
        public int OldGrade { get; set; }
    }

    public class DungeonPassEventArgs : EventArgs
    {
        public Dungeon Dungeon { get; set; }
        public int Number { get; set; }
    }
}
