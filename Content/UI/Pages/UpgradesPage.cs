using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightNohit.Content.UI.Pages;

public class UpgradesPage : ATogglesPage
{
    public UpgradesPage(List<PageUIElement> uIElements, string name, string description, Texture2D wheelIconTexture, float layer) : base(uIElements, name, description, wheelIconTexture, layer)
    {
    }

    public override string PageName => "Upgrades";
}
