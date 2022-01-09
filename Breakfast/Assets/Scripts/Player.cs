using UnityEngine;
/// <summary>
/// ���Ⲿ�ʻP�o�g
/// </summary>
public class Player : MonoBehaviour
{
    #region ���
    //[Header("��m�W��"),Range(0,1000)]
    private float aisle = 2.5f;
    [Header("�ثe��m")]
    public Vector3 myPosition;
    //[Header("����")]
    private Rigidbody2D RB;
    [Header("�ʵe")]
    public Animator AN ;
    private string walk = "��";
    private string shoot = "�g";
    [Header("�U��")]
    private Vector3 first= new Vector3(-7.47f, -1.9f, 0);
    private Vector3 second = new Vector3(-7.47f, 0.6f, 0);
    private Vector3 third = new Vector3(-7.47f, 3.1f, 0);
    public bool onFirst;
    public bool onSecond;
    public bool onThird;
    public bool put =true;
    [Header("�l�u��m")]
    public GameObject[] bullets;
    [Header("CD�ɶ�")]
    public float CDTime = 2f;
    [SerializeField]
    private float coldTime;
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AN = GetComponent<Animator>();
        myPosition = transform.position;
        coldTime = 0;
    }
    private void Update()
    {
        if (Input.GetAxis("Vertical") == 0) put = true;
    }
    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) Launch();
        coldTime += Time.deltaTime;
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

    private void Launch()
    {
        print("�o�g");
        if (coldTime>=CDTime) 
        {
            Vector2 direction = myPosition;
            direction.Normalize();
            AN.SetTrigger(shoot);
            GameObject newBullets = Instantiate(bullets[Random.Range(0, 3)], RB.position, Quaternion.identity);

            Bullets bull = GetComponent<Bullets>();
            bull.Shoot(direction, 200);

            coldTime = 0;
        }
    
            
        
    }
    #endregion
}
