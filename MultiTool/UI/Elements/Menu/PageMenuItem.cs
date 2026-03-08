using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;

namespace MultiTool.UI.Elements.Menu;
public class PageMenuItem<T> : MenuItem where T : Frame, new() {
    public PageMenuItem(string text, Color? color = null, int spaceModifier = 0, Action? toExecute = null)
        : base(text, color, (int index) => { T page = new T(); page.initialize(); page.run(); toExecute?.Invoke(); }, spaceModifier) {

    }
}
