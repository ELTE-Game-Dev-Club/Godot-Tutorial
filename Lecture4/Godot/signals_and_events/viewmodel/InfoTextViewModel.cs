using Godot;
using Godot.Collections;

namespace InstancingAndNamespaces.viewmodel;

public partial class InfoTextViewModel : Control
{
    [Export]
    public RichTextLabel LivesLabel;

    [Export]
    public RichTextLabel BombLabel;

    public HullViewModel PlayerHull; 

    public override void _Ready()
    {
        PlayerControl.Instance.LivesChanged += OnLivesChanged;
        PlayerControl.Instance.BombCountChanged += OnBombCountChanged;
        
        OnLivesChanged();
        OnBombCountChanged();
    }

    public void OnLivesChanged()
    {
        LivesLabel.Text = PlayerControl.Instance.LivesCount.ToString();
    }

    public void OnBombCountChanged()
    {
        BombLabel.Text = PlayerControl.Instance.LivesCount.ToString();
    }
}