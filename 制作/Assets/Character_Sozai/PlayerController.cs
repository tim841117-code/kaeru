using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;  //���s�A�j���[�V�����̍Đ����x�ǉ��v���O�����i�A�j���[�V�����N���b�v���쐬�������ɃR�����g�A�E�g����j
    float jumpForce = 800.0f;   //�Q�[���o�����X�Ŋe�l�Œ���
    float walkForce = 30.0f;    //�Q�[���o�����X�Ŋe�l�Œ���
    float maxWalkSpeed = 4.0f;  //�Q�[���o�����X�Ŋe�l�Œ���

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();  //���s�A�j���[�V�����̍Đ����x�ǉ��v���O�����i�A�j���[�V�����N���b�v���쐬�������ɃR�����g�A�E�g����j��Animator��Component���擾
    }

    void Update()
    {

        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(this.rigid2D.linearVelocity.y) <= 0.05f)//GetKeyDown���\�b�h���g���ăX�y�[�X�L�[�������ꂽ���𒲂ׂ�B���AY�����̈ړ���0�̎�
        {
            this.animator.SetTrigger("JumpTrigger");//���s�A�j���[�V�����̍Đ����x�ǉ��v���O�����iJump�̃A�j���[�V�����N���b�v���쐬�������ɃR�����g�A�E�g����j���W�����v�A�j���[�V�����̐؂�ւ��ǉ��v���O����
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

		//���E�Ɉړ�����
		int key = 0;
		if (Input.GetKey(KeyCode.RightArrow)) key = 1;
		if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

		//�v���C���̑��x
		float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        //�X�s�[�h����
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //���������ɉ����Ĕ��]
        if(key !=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

		//���s�A�j���[�V�����̍Đ����x�ǉ��v���O����52�s����55�s�܂ŁiJump�̃A�j���[�V�����N���b�v���쐬�������ɃR�����g�A�E�g����j���W�����v�A�j���[�V�����̐؂�ւ��ǉ��v���O����
		//�v���C���[�̑��x�ɉ����ăA�j���[�V�������x��ς���
		//if (this.rigid2D.velocity.y == 0)
		//{ this.animator.speed = speedx / 2.0f; }
		//else
		//{ this.animator.speed = 1.0f; }

		//��ʊO�ɗ������o���ꍇ�͍ŏ�����i��������ꂽ���ꍇ�ɁA58�`61�s���R�����g�A�E�g����j
		//if (transform.position.y < -30)//���̒l�ŗ������e���w��i�}�b�v�����鎞�ɍ��W�ɒ��ӁB���̏ꍇ�A����-30�ɃL�����N�^�[���ړ�����ƃQ�[���I�[�o�[�j
		//{
		//	SceneManager.LoadScene("GameScene");//��蒼���Ȃ��A�Q�[���I�[�o�[�ɂ���ꍇ�́AGameOverScene���쐬�����A�J�ڂ�����
		//}

		//�v���C���[�̑��x�ɉ����ăA�j���[�V�������x��ς���
		//this.animator.speed = speedx / 2.0f;�@//���s�A�j���[�V�����̍Đ����x�ǉ��v���O�����i�A�j���[�V�����N���b�v���쐬�������ɃR�����g�A�E�g����j
	}

    //�S�[���ɓ���
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene"); // ClearScene�Ɉړ�����B
    }

}
