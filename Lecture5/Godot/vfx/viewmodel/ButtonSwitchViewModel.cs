using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public partial class ButtonSwitchViewModel : Node
{
    [Export]
    public Array<Button> Buttons = new Array<Button>();

    public override void _Ready()
    {
        base._Ready();

        SelectButton(Buttons[0]);
        foreach (var button in Buttons)
        {
            button.Pressed += () => { OnButtonPressed(button); };
        }
    }

    public void OnButtonPressed(Button button)
    {
        foreach (var b in Buttons)
        {
            if (b == button)
            {
                SelectButton(b);
            }
            else
            {
                UnselectButton(b);
            }
        }
    }

    public void SelectButton(Button button)
    {
        button.Scale = new Vector2(1.3f, 1.3f);
    }

    public void UnselectButton(Button button)
    {
        button.Scale = new Vector2(1, 1);
    }
}
