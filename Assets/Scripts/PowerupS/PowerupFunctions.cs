using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFunctions : MonoBehaviour
{
    [SerializeField]
    private float powerupDuration;
    [SerializeField]
    private Camera gamecamera;
    [SerializeField]
    private float newFOV;
    private float oldFOV;
    [SerializeField]
    private GameObject player;
    private Vector3 originalScale;

    public ScoreController scoreController;
    public HealthController healthController;

    private void Awake()
    {
        oldFOV = gamecamera.fieldOfView;
        originalScale = player.transform.localScale;
    }
    public void FieldOfViewPowerup()
    {
        gamecamera.fieldOfView = newFOV;
        StartCoroutine(PowerupTimer(PowerupType.FieldOfView));
    }
    public void SizeReducerPowerup()
    {
        player.transform.localScale = originalScale * 0.5f;
        StartCoroutine(PowerupTimer(PowerupType.SizeReducer));
    }
    public void GravityReducerPowerup()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * 0.5f;
        StartCoroutine(PowerupTimer(PowerupType.GravityReducer));
    }
    public void GravityIncreaserPowerup()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * 2.0f;
        StartCoroutine(PowerupTimer(PowerupType.GravityIncreaser));
    }
    public void ScoreMultiplierPowerup()
    {
        scoreController.ScoreMultiplier();
        StartCoroutine(PowerupTimer(PowerupType.ScoreMultiplier));
    }
    public void HealthIncrementPowerup()
    {
        healthController.AddHealth();
    }
    IEnumerator PowerupTimer(PowerupType ptype)
    {
        yield return new WaitForSeconds(powerupDuration);
        BackToNormal(ptype);
    }

    private void BackToNormal(PowerupType ptype)
    {
        switch (ptype)
        {
            case PowerupType.FieldOfView:
                gamecamera.fieldOfView = oldFOV;
                break;
            case PowerupType.SizeReducer:
                player.transform.localScale = originalScale;
                break;
            case PowerupType.GravityReducer:
                player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * 2.0f;
                break;
            case PowerupType.GravityIncreaser:
                player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * 0.5f;
                break;
            case PowerupType.ScoreMultiplier:
                scoreController.ScoreDemultiplier();
                break;
        }
    }
}
