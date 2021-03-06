using UnityEngine;
using System.Collections;

public class PlayerAnimationSetup : MonoBehaviour {
	// スライディング実行時間  
	public float slidingTime = 1F;
    
	Animator animator;
	CharacterController character;
	float slidingTimeLeft = 0F;
	Vector3 colliderCenter;
	float colliderHeight;
	
	void Start () {
		// キャラクターコントローラーの取得
		character = GetComponent<CharacterController>();
		// Animatorコンポーネントの取得
		animator = GetComponent<Animator>();
		animator.SetLayerWeight (1, 0.8f);

		colliderCenter = character.center;
		colliderHeight = character.height;
	}
	
	void Update () {
		// キー入力の取得		
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis ("Horizontal");
		bool isJump = Input.GetKey(KeyCode.Space);
		bool isSliding = Input.GetKey(KeyCode.C);
		
		// TreasureControllerのParametersにパラメーターをセット
		animator.SetBool("IsGround", character.isGrounded); 
		animator.SetBool("IsJumpStart", false); 
		animator.SetBool("IsSlidingStart", false);
		
		// スライディング実行時間残を減少させる
		if (slidingTimeLeft > 0) {
			slidingTimeLeft -= Time.deltaTime;
		}
		
		animator.SetFloat("SlidingTime", slidingTimeLeft);

		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
		if (state.nameHash == Animator.StringToHash ("Base Layer.Sliding")) 
		{
			Vector3 newColliderCenter = colliderCenter;
			newColliderCenter.y *= 0.5f;
			character.center = newColliderCenter;
			character.height = colliderHeight * 0.5f;
		} 
		else
		{
			character.center = colliderCenter;
			character.height = colliderHeight;
		}


		if (character.isGrounded) {			
			animator.SetFloat("Speed", v);			
			animator.SetFloat("Direction", h);
			if (isJump) {
				animator.SetBool("IsJumpStart", true);
			}			
			if (isSliding) {
				animator.SetBool("IsSlidingStart", true);
				slidingTimeLeft = slidingTime;
				animator.SetFloat("SlidingTime", slidingTime);
			}
		}		
	}
	
}