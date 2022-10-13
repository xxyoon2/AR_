using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniUI
{
    public void GameStart();
    public void GameClear();
    public void GameOver();
    public void Info();
    public void HP(int health);
}

public class MiniGameUI : MonoBehaviour, IMiniUI
{
    public void GameStart()
    {
        
    }

    public void GameClear()
    {

    }

    public void GameOver()
    {
        
    }

    public void Info()
    {

    }

    public void HP(int health)
    {

    }
}
