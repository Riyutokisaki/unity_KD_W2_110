using UnityEngine;
/// <summary>
/// �^���_��
/// </summary>
public class barry : MonoBehaviour
{
    #region ���
    public GameObject Effects;
    //�C������ �S��
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Instantiate(Effects, gameObject.transform.position, Quaternion.identity);
        RubyMove rubyMove = collision.GetComponent<RubyMove>();
        //RubyMove�b�o��C#���W�r�OrubyMove(�n�i���o��C#�ɮפ~��ϥ�)
        //�N��w�q���I��(collision)�ɱqRubyMove�̮������
        print(rubyMove + "����F!");
        //�ˬdRuby�I��
        rubyMove.ChangeHealth(1);
        //�a�J��rubyMove(barry�o��C#�ɮ׸�RubyMove���W�r)��ChangeHealth(�a�J�ܼ�<�[���q>)
        Destroy(gameObject);
        //���������
    }
   
}
