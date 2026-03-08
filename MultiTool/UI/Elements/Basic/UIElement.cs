using MultiTool.UI.Elements.Basic.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.UI.Elements.Basic;
public abstract class UIElement {
    public UISettings getSettings() {
        return GlobalSettings.getSettings();
    }
}

