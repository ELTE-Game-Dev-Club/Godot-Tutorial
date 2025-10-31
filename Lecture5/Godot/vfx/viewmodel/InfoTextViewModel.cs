using Godot;
using Godot.Collections;

namespace InstancingAndNamespaces.viewmodel;

public partial class InfoTextViewModel : Control
{

    [Export] public RichTextLabel HealthLabel;
    
    [Export]
    public RichTextLabel LivesLabel;

    [Export]
    public RichTextLabel BombLabel;

    public HullViewModel PlayerHull; 

    public override void _Ready()
    {
        PlayerControl.Instance.LivesChanged += OnLivesChanged;
        PlayerControl.Instance.BombCountChanged += OnBombCountChanged;
        PlayerControl.Instance.PlayerHealthChanged += OnHealthChanged;
        
        OnLivesChanged();
        OnBombCountChanged();
        OnHealthChanged();
    }

    public void OnLivesChanged()
    {
        LivesLabel.Text = PlayerControl.Instance.LivesCount.ToString();
    }

    public void OnBombCountChanged()
    {
        BombLabel.Text = PlayerControl.Instance.LivesCount.ToString();
    }

    public void OnHealthChanged()
    {
        if (PlayerControl.Instance.Ship is not null)
        {
            HealthLabel.Text = PlayerControl.Instance.Ship.Health.ToString();
        }
        else
        {
            HealthLabel.Text = "0";
        }
    }
}