using UnityEngine.UI;
using UnityEngine;

public interface IBar
{
    public void Init(IPlayer player);
    public void Tick();
}

public class BarController : MonoBehaviour, IBar
{
    private IPlayer player;
   
    public void Init(IPlayer player)
    {
        _text = GetComponentInChildren<Text>();
        this.player = player;
    }
    
    public void Tick()
    {
        if (player.GetHealth()>=0)
        {
            _text.text = "HP: " + player.GetHealth().ToString();
        }
    }
    
    private Text _text;
}
