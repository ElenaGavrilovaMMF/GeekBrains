using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject _player;
    public GameObject _canvas;
    public GameObject _level;
    void Awake()
    {
        _player = Instantiate(_player, new Vector3(-23f, 0.25f, -26f), Quaternion.identity);
        _canvas = Instantiate(_canvas, Vector3.zero, Quaternion.identity);
        _level = Instantiate(_level, Vector3.zero, Quaternion.identity);
        
        barController = _canvas.GetComponentsInChildren<BarController>()[0];
        player = _player.GetComponent<PlayerController>();
        doorController = _level.GetComponentsInChildren<DoorController>();
        
        player.Init();
        barController.Init(player);
        foreach (IDoor door in doorController)
        {
            door.Init();
        }
    }
    

    void Update()
    {
        player.Tick();
        barController.Tick();
        foreach (IDoor door in doorController)
        {
            door.Tick();
        }
    }

    private IPlayer player;
    private IBar barController;
    private IDoor[] doorController;
}
