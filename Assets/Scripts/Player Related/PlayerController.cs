using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Camera gameCamera;
    public ScoreController scorecontroller;
    public HealthController healthcontroller;
    public GameOverController gameovercontroller;
    public PauseController pausecontroller;
    public PowerupFunctions p_functions;
    public SegmentManager segmentManager;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            pausecontroller.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GravityReversal();
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(((transform.position.x + speed * Time.fixedDeltaTime) ),transform.position.y);
    }

    private void GravityReversal()
    {
        rb.gravityScale = -1.0f * rb.gravityScale;
        AudioManager.Instance.Play(Sounds.GravityFlip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderEnum ctype = collision.gameObject.GetComponent<ColliderType>().GetColliderType();
        if(ctype == ColliderEnum.Spike)
        {
            healthcontroller.SubtractHealth();
            AudioManager.Instance.Play(Sounds.Spikehit);
        }
        else if(ctype == ColliderEnum.Collectible)
        {
            Destroy(collision.gameObject);
            scorecontroller.AddScore();
            AudioManager.Instance.Play(Sounds.Collectible);
        }
        else if(ctype ==ColliderEnum.SegmentEnd)
        {
            segmentManager.LoadNextSegment();
        }
        else if(ctype == ColliderEnum.Powerup)
        {
            AudioManager.Instance.Play(Sounds.Powerup);
            switch (collision.gameObject.GetComponent<PowerupTypes>().GetPowerupType())
            {
                case PowerupType.FieldOfView:p_functions.FieldOfViewPowerup();
                    break;
                case PowerupType.GravityIncreaser:p_functions.GravityIncreaserPowerup();
                    break;
                case PowerupType.GravityReducer:p_functions.GravityReducerPowerup();
                    break;
                case PowerupType.SizeReducer:p_functions.SizeReducerPowerup();
                    break;
                case PowerupType.ScoreMultiplier:p_functions.ScoreMultiplierPowerup();
                    break;
                case PowerupType.HealthIncrement:p_functions.HealthIncrementPowerup();
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(3.0f);
        gameovercontroller.gameObject.SetActive(true);
    }
}
