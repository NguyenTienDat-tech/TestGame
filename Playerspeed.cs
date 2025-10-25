using UnityEngine;

public class Playerspeed : MonoBehaviour
{
    public float speed = 5.0f;
    public float jump = 10.0f;
    private Rigidbody2D rb;
    public LayerMask groundLayer; //chọn những vật nào mình muốn tương tác
    public Transform groundCheck; //kiểm tra dưới chân nhân vật
    private bool isGrounded; //kiểm tra nhân vật có chạm đất hay không
    private Animator animator;

    // Tham chiếu đến thành phần Animator và Rigidbody2D
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Truyền dữ liệu vào game
    void Update()
    {
        nhanvatdichuyen();
        nhanvatnhay();
        Animation();
    }

    private void nhanvatdichuyen()
    {
        //di chuyển <-- -->
        float dichuyen = Input.GetAxis("Horizontal");
        //di chuyển nhân vật
        rb.velocity = new Vector2(dichuyen * speed, rb.velocity.y); //giữ nguyên vận tốc y

        //lật hướng nhân vật khi đổi chiều
        if (dichuyen > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (dichuyen < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    //nhân vật nhảy
    private void nhanvatnhay()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //over...: vẽ vòng tròn quanh điểm groundcheck, 0.2f: bán kính vòng tròn
    }

    //hàm animation
    private void Animation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f; //lấy giá trị tuyệt đối vận tốc x và nếu lớn hơn 0.1f thì nhân vật đang chạy
        bool isJumping = !isGrounded; // nếu không chạm đất thì nhân vật đang nhảy
        animator.SetBool("run", isRunning);
        animator.SetBool("jump", isJumping);
    }
}