using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Transform firePoint;//���𔭎˂���ʒu
    public GameObject bulletPrefab;
    public GameObject explosion;

    GameContoroller gameContoroller;

    public static float px = 0;//���@�ʒu���O���t�@�C���Q�Ɨp
    public static float py = 0;//���@�ʒu���O���t�@�C���Q�Ɨp

    private void Start()
    {
        gameContoroller = GameObject.Find("GameContoroller").GetComponent<GameContoroller>();
    }


    // Update is called once per frame
    void Update()
    {

        Shot();
        Move();
        px = transform.position.x * 0.7f;//���@�_���e�p
        py = transform.position.y * 0.7f;//���@�_���e�p
    }
    void Shot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }
    void Move()
    {
        //Player����
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4;
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 4;
        float moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime * 4;

        transform.position = new Vector2(
            //�G���A�w�肵�Ĉړ�����
            Mathf.Clamp(transform.position.x + moveX, -2.8f, 2.8f),
            Mathf.Clamp(transform.position.y + moveY, -1.37f, 1.52f)
            );
    }

    private void OnTriggerEnter2D(Collider2D collisition)
    {
        if (collisition.CompareTag("EnemyBullet") == true)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(collisition.gameObject);
            Destroy(gameObject);
            gameContoroller.GameOver();

        }

        
    }

}
