using MultiTool.UI.Elements.Basic.Color;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.UI.Elements.Basic.Settings;
public class UISettings {
    private TextColor _titleText;
    private TextColor _normalText;
    private TextColor _selectedText;
    private TextColor _successfulText;
    private TextColor _errorText;

    public UISettings(TextColor titleText, TextColor normalText, 
                      TextColor selectedText, TextColor successfulText, 
                      TextColor errorText) {
        _titleText = titleText;
        _normalText = normalText;
        _selectedText = selectedText;
        _successfulText = successfulText;
        _errorText = errorText;
    }

    public TextColor getTitleText() {
        return _titleText;
    }
    public TextColor getNormalText() {
        return _normalText;
    }
    public TextColor getSelectedText() {
        return _selectedText;
    }
    public TextColor getSuccessfulText() {
        return _successfulText;
    }
    public TextColor getErrorText() {
        return _errorText;
    }
}

