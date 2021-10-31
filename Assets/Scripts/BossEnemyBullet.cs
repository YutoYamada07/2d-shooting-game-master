using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
   
    // İ’è‚³‚ê‚½•ûŒü‚É’e‚ğˆÚ“®‚³‚¹‚é
    float dx;
    float dy;
    public void Setting(float angle, float speed)
    {
        // “G‚Ì‰E‘¤‚ª0‹
        // ”½Œv‰ñ‚è‚ÉŠp“x‚Í‘‚¦‚é

        // 2PI‚ª360‹
        // PI‚ª180‹
        // PI/2‚ª90‹

        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -3 || transform.position.x > 3 ||
            transform.position.y < -3 || transform.position.y > 3)
        {
            Destroy(gameObject);
        }
    }
}
