using UnityEngine;
/// <summary>
/// 角色移動與發射
/// </summary>
public class Player : MonoBehaviour
{
    #region 欄位
    [Header("位置增減"),Range(0,1000)]
    public float aisle = 2.5f;
    [Header("目前位置")]
    public Vector3 myPosition;
    [Header("剛體")]
    public Rigidbody2D RB;
    [Header("動畫")]
    public Animator AN ;
    public string walk = "走";
    public string shoot = "射";
    [Header("各排")]
    public Vector3 first= new Vector3(-7.47f, -1.9f, 0);
    public Vector3 second = new Vector3(-7.47f, 0.6f, 0);
    public Vector3 third = new Vector3(-7.47f, 3.1f, 0);
    public bool onFirst;
    public bool onSecond;
    public bool onThird;
    public bool put =true;
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AN = GetComponent<Animator>();
        myPosition = transform.position;
    }
    private void Update()
    {
        if (Input.GetAxis("Vertical") == 0) put = true;
    }
    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) Launch();
    }
    #region 方法
    void Move()
    {
        #region 開關
        if (myPosition.y == first.y)
        {
            onFirst = true;
            onSecond = false;
            onThird = false;
        }
        if (myPosition.y == second.y)
        {
            onFirst = false;
            onSecond = true;
            onThird = false;
        }
        if (myPosition.y == third.y )
        {
            onFirst = false;
            onSecond = false;
            onThird = true;
        }
        #endregion
        float w = Input.GetAxis("Vertical");
        AN.SetBool(walk, w != 0);
        if (onFirst && w > 0 && put )
        {
            myPosition.y = second.y;
            put = false;
            //print("按鍵輸入" + myPosition.y);
        }
        if (onSecond && w > 0 && put)
        {
            myPosition.y = third.y;
            put = false;
            //print("按鍵輸入" + myPosition.y);
        }
        if (onSecond && w < 0 && put)
        {
            myPosition.y = first.y;
            put = false;
            //print("按鍵輸入" + myPosition.y);
        }
        if (onThird && w < 0 && put)
        {
            myPosition.y = second.y;
            put = false;
            //print("按鍵輸入" + myPosition.y);
        }
    
        RB.MovePosition(myPosition);

    }

    void Launch()
    {
        AN.SetTrigger(shoot);
    }
    #endregion
}
