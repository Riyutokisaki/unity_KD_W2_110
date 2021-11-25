using UnityEngine;

/// <summary>
/// �ϥβV�X��ʵe����ruby���ʵ{��
/// �ثe���D:Ruby���ʮɰʵe����
/// </summary>
/// 

public class RubyMove : MonoBehaviour
{
    #region ���
    //�p�H���
    private Vector2 LookDirection;//�w�q�ݪ���V 46 57
    private Vector2 RubyPosition;//�w�q��m 30 64
    private Vector2 RubyGO;//�w�q���ʶq 41

    //���}���
    public Animator RubyAnimation;//�w�q�ʵe����ܼ� 22 57
    public Rigidbody2D RB;//�w�q����(Move) 23

    public float speed = 3f;//64
    #endregion

    void Start()//�C���}�l�ɰ���
    {
        RubyAnimation = GetComponent<Animator>();//����M�θ}���������󪺰ʵe����A�b���}���|���
        RB = GetComponent<Rigidbody2D>();//Ū���M�θ}�����󪺭��餸��A�|�b���}������
        //GetComponent        <>        ();
        //(Ū���M�θ}��������)<���Y�Ӥ���>(�ܼ�);
    }

    private void FixedUpdate()//�T�w�V�ư���
    {
        RubyPosition = transform.position;//��ثe�����m�w�q�ܨp�H��줺

        #region �w�q����ƭ�(����������h��)
        //horizontal���� vertical����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //�˴���(��ܩ�unity��console��)
        print("���k��ƭȬ�"+horizontal);
        print("�W�U��ƭȬ�" +vertical);
        #endregion
        
        RubyGO = new Vector2(horizontal,vertical);//��W�����o������ƭȳ]�߷s����w�q��RubyGo

        #region �����J����0��
        if (!Mathf.Approximately(RubyGO.x,0) || !Mathf.Approximately(RubyGO.y,0))
        {
            LookDirection = RubyGO;//���a���U���ʫ����(����0)�A�h����Ruby���
            LookDirection.Normalize();//�зǤơA�ϫ���ƭȧ�ֱ���ƭ�:1
        }
        else//�ۤϪ��A�Y�����J��0�h���]�ʵe�ʧ@(Ĳ�owit)
        {
            RubyAnimation.SetTrigger("wit");
        }
        #endregion

        #region ����V�X�𪺰ʵe
       //�����¦V�ƭ�
        RubyAnimation.SetFloat("x",LookDirection.x);
        RubyAnimation.SetFloat("y", LookDirection.y);
        //��RubyGo�����ʶq����Speed
        RubyAnimation.SetFloat("Speed", RubyGO.magnitude);
        #endregion

        //����Ruby��m
        RubyPosition = RubyPosition + speed * RubyGO * Time.deltaTime;
        RB.MovePosition(RubyPosition);//�ϥο���i�沾��
    }
    
}