using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompsKitMarket.Core.Entities.Enums;

namespace CompsKitMarket.Core.Entities.Kits
{
    public class Frame : Part
    {
        public int MotherFormId { get; set; }
        public FormFactor MotherForm { get; set; }

        public FrameForm Form{ get; set; }
        public Color Color { get; set; }
        public bool Game { get; set; }

        public int VideoLenght { get; set; }
        public int CoolHeight { get; set; }
        public int ChargeLength { get; set; }

        public byte Fans { get; set; }
        public byte InsideHsdSize3 { get; set; }
        public byte InsideHsdSize2 { get; set; }
    }
}
