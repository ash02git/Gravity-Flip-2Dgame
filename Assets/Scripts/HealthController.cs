using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private int heartcount;
    [SerializeField]
    private int healthAddOn=2;
    [SerializeField]
    private List<GameObject> hearts;
    [SerializeField]
    private GameObject heartPrefab;

    public PlayerController player;

    public void AddHealth()
    {
        heartcount+=healthAddOn;
        AddHearts(healthAddOn);//keeping 2 hearts increment per health powerup
    }

    public void SubtractHealth()
    {
        if (heartcount > 0)
        {
            heartcount--;
            RemoveHeart();
            CheckDeath();
        }
    }

    private void CheckDeath()
    {
        if (heartcount < 1)
        {
            Debug.Log("Player died");
            StartCoroutine(player.GameOverTimer());
            player.enabled = false;
            AudioManager.Instance.Play(Sounds.Death);
        }
    }

    private void RemoveHeart()
    {
        Destroy(hearts[hearts.Count-1]);
        hearts.RemoveAt(hearts.Count-1);
    }
    private void AddHearts(int count)
    {
        for(int i =1;i<=count;i++)
        {
            GameObject heart = Instantiate(heartPrefab,transform);
            hearts.Add(heart);
        }
    }
}
