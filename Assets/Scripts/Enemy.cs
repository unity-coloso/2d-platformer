using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState
    {
        Patrol, // �� ĳ���Ͱ� �����ϴ� ����
        Chase   // �÷��̾� ĳ���͸� �����ϴ� ����
    }

    enum EnemyDirection
    {
        Left = -1,
        Idle = 0,
        Right = 1
    }

    public float chasingRange = 3f;
    public float changeMindTime = 3f;
    public float moveSpeed = 5f;
    public float xDirection;
    public bool isGrounded;

    [SerializeField] EnemyState state;
    [SerializeField] EnemyDirection direction;

    [SerializeField] float movement;
    [SerializeField] Vector3 edgeOffset;
    [SerializeField] Vector3 directionToPlayer;
    [SerializeField] float distanceToPlayer;

    Rigidbody2D rigidbody2d;
    Animator animator;
    GameObject player;

    [SerializeField] float elapsedTime;  // ���������� ������ �ٲٰ� ���� ����� �ð�.

    void Start()
    {
        state = EnemyState.Patrol;
        direction = EnemyDirection.Idle;

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        movement = xDirection * moveSpeed;
        if (Mathf.Abs(movement) > 0.1)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        // �÷��̾� ĳ���ͷ� ���ϴ� ���� ����.
        directionToPlayer = player.transform.position - transform.position;

        // �÷��̾� ĳ���Ϳ��� �Ÿ�.
        distanceToPlayer = directionToPlayer.magnitude;

        // �� ĳ������ �պκ��� ������ �ƴѰ�?
        isGrounded = Physics2D.CircleCast(transform.position + edgeOffset, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        if (!isGrounded)    // isGrounded == false
        {
            direction = direction == EnemyDirection.Left ? EnemyDirection.Right : EnemyDirection.Left;
            xDirection = (float)direction;
        }

        if (xDirection != 0)
        {
            transform.localScale = new Vector3(xDirection, 1, 1);
        }

        if (state == EnemyState.Patrol)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= changeMindTime)
            {
                direction = (EnemyDirection)Random.Range(-1, 2);   // -1, 0, 1;
                xDirection = (float)direction;

                elapsedTime = 0;
            }

            if (distanceToPlayer <= chasingRange)
            {
                state = EnemyState.Chase;
            }
        }
        else if (state == EnemyState.Chase)
        {
            direction = directionToPlayer.x < 0 ? EnemyDirection.Left : EnemyDirection.Right;
            xDirection = (float)direction;

            if (distanceToPlayer > chasingRange)
            {
                state = EnemyState.Patrol;
            }
        }
    }

    void LateUpdate()
    {
        edgeOffset = new Vector3(transform.localScale.x * 0.5f, 0, 0);
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(movement, rigidbody2d.velocity.y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + edgeOffset, transform.position + edgeOffset + Vector3.down * 1.1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ��(Enemy)�� �浹�߽��ϴ�.");

            collision.collider.SendMessage("Damage", 1);
        }
    }
}