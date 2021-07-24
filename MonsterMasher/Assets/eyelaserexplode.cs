using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyelaserexplode : MonoBehaviour
{

    public int damage = 4;
    public float speed = 5f;
    public float expiretime = 3f;
    public GameObject fireballhit;
    public SpriteRenderer mySprite;
    public bool done = false;
    

    private void Start()
    {
        if (PlayerManager.playerObject.transform.localScale.x == -1)
        {

            speed = Mathf.Abs(speed);
            
        }
        FireBallSoundManager.Instance.Fireballsound.Play();
        
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (done)
        {
            return;
        }

        expiretime -= Time.deltaTime;
        if (expiretime <= 0)
        {
            DestroyMe();
        }

            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (done)
        {

        }

        EnemyHitable phitcheck = collision.gameObject.GetComponentInParent<EnemyHitable>();

        if (phitcheck != null  && phitcheck.GetHealth()>0)
        {
            //Debug.Log("We hit an enemy");
            done = true;
            FireBallSoundManager.Instance.Explosionsound.Play();
            phitcheck.GetHit(damage);
            mySprite.enabled = false;
            fireballhit.SetActive(true);
        }



    }
}
