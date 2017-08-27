using UnityEngine;
using System.Collections;

public class DestroyableObsticle : MonoBehaviour {

	public int damageState = 5;
    bool IsInvincible = false;
    public float InvincibleTime = 0.1f;

	public SpriteRenderer spriteRenderer;
	public Sprite damagedSprite;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void updateState(){
		if (damageState == 2) {
			spriteRenderer.sprite = damagedSprite;
		} else if (damageState == 0){
			Destroy(gameObject,0);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Damaging") {

            if (IsInvincible)
            {
                return;
            }
            IsInvincible = true;
            damageState = damageState - 1;
            
            OnHitColourChange();
            updateState();
		}
	}
    
    void OnHitColourChange()
    {
        SpriteRenderer t_sprite = gameObject.GetComponent<SpriteRenderer>();
        Color colour = new Color(1f, 0.1f, 0.1f, 1f);
        t_sprite.color = colour;

        Invoke("OnHitColourChange2", InvincibleTime);

    }

    void OnHitColourChange2()
    {
        SpriteRenderer t_sprite = gameObject.GetComponent<SpriteRenderer>();
        Color colour = new Color(1f, 1f, 1f, 1f);
        t_sprite.color = colour;
        IsInvincible = false;
    }


}
