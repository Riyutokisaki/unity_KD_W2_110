using UnityEngine;

public class bullet : MonoBehaviour
{
    #region ���
    [Header("�l�u������")]
    public Rigidbody2D bulletRB;
    [Header("��m�P�T��'")]
    public float bulletDis;
    [Header("�S��")]
    //ParticleSystem�ɤl�t�����
    public ParticleSystem Eff;
    #endregion
    
    //�]�l�u��Instantiate()���ͩҥH����Start()
    //�Өϥ�Awake()���
    private void Awake()
    {
        //�b���(�g�X)�ɮ��쪫�����P��m�T��
        bulletRB = GetComponent<Rigidbody2D>();
        bulletDis = transform.position.magnitude;
    }
    void Update()
    {
    //�C�V�P�_�p�G�����ܤƪ���m>100
    //�P������
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 direction,float force)//���}��RubyMove�ϥ�(���J�O)
    {
        //����.�[�O(��V*�O�D)
        bulletRB.AddForce(direction * force);
    }
}
