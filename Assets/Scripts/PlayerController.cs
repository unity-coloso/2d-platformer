using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Projectile projectilePrefab;

    public bool hasKey;
    public bool hasProjectile;

    public int health = 5;
    public float moveSpeed = 5f;
    public float jumpForce = 15f;

    public float xDirection;
    public bool isGrounded;

    [SerializeField] float movement;
    Rigidbody2D rigidbody2d;
    Animator animator;

    public void Damage(int damage)
    {
        //Debug.Log(damage + "를 받았다!");
        Debug.Log($"{damage}를 받았다!");

        //health = health - damage;
        health -= 1;
        if (health < 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            GameManager.Instance.GameOver();
        }

        animator.SetTrigger("Hurt");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()가 호출되었습니다.");

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 캐릭터 방향 처리.
        xDirection = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xDirection) > 0)
        {
            if (xDirection < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        movement = xDirection * moveSpeed;
        if (Mathf.Abs(movement) > 0.1f)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        // 플레이어가 땅("Platforms")에 발을 딛고 있는가?
        isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        animator.SetBool("Grounded", isGrounded);

        // 조건 1. 게임 매니저의 상태가 "실행 중(Running)"일 때
        // 조건 2. 스페이스 바를 눌렀을 때,
        // 조건 3. 플레이어가 땅에 받을 딛고 있을 때
        if (GameManager.Instance.State == GameManager.GameState.Running &&
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded)
        {
            Debug.Log("플레이어 캐릭터가 점프합니다.");

            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   // Vector2(0, 1)
        }

        if (hasProjectile && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("발사체를 발사합니다.");

            Vector3 playerDirection = new Vector3(transform.localScale.x, 0, 0);

            Projectile projectile = GameObject.Instantiate<Projectile>(
                projectilePrefab,
                transform.position + playerDirection,
                Quaternion.identity);

            projectile.Fire(playerDirection);

            hasProjectile = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(movement, rigidbody2d.velocity.y);
    }
}
