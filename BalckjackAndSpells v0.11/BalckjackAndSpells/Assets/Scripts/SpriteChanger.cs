using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour
{

    public Sprite Neutral;
    public Sprite Druid;
    public Sprite Necromancer;

    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Neutral;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the space bar is pushed down
        {
            ChangeSprite(); // call method to change sprite
        }
    }

    void ChangeSprite()
    {
        if (spriteRenderer.sprite == Druid || spriteRenderer.sprite == Neutral) // checks then changes sprite
        {
            spriteRenderer.sprite = Necromancer;
        }
        else
        {
            spriteRenderer.sprite = Druid; // otherwise change it back to sprite1
        }

    }
}