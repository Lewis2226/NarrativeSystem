using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameObject _player;

    void Awake()
    {
        _player = player;
    }

}
