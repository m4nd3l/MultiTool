using MultiTool.Tools;
using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;

namespace MultiTool.UI.Elements.Menu;
public class ToMainPageMenuItem : PageMenuItem<MainMenu> {
    public ToMainPageMenuItem(Color? color = null, int spaceModifier = 0, Action? toExecute = null)
        : base("Back", color, spaceModifier,  toExecute) {
    }
}