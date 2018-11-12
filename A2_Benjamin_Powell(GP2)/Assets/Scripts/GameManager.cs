using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _numCoins;
    public int score = 0;

    public int NumCoins
    {
        get { return _numCoins; }
        set { _numCoins = value; }
    }


    // Use this for initialization
    private void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Die()
    {
        AddScore(10);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UIManager.Instance.UpdateScore();
    }
}
