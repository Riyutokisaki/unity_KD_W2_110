using UnityEngine;
/// <summary>
/// ���Ⲿ�ʻP�o�g
/// </summary>
public class Player : MonoBehaviour
{
    #region ���
    [Header("��m�W��"),Range(0,1000)]
    public float aisle = 2.5f;
    [Header("�ثe��m")]
    public Vector3 myPosition;
    [Header("����")]
    public Rigidbody2D RB;
    [Header("�ʵe")]
    public Animator AN ;
    public string walk = "��";
    public string shoot = "�g";
    [Header("�U��")]
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
    #region ��k
    void Move()
    {
        #region �}��
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
            //print("�����J" + myPosition.y);
        }
        if (onSecond && w > 0 && put)
        {
            myPosition.y = third.y;
            put = false;
            //print("�����J" + myPosition.y);
        }
        if (onSecond && w < 0 && put)
        {
            myPosition.y = first.y;
            put = false;
            //print("�����J" + myPosition.y);
        }
        if (onThird && w < 0 && put)
        {
            myPosition.y = second.y;
            put = false;
            //print("�����J" + myPosition.y);
        }
    
        RB.MovePosition(myPosition);

    }

    void Launch()
    {
        AN.SetTrigger(shoot);
    }
    #endregion
}
