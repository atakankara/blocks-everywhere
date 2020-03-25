using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] GameObject particleSFX;
    [SerializeField] Sprite[] hitSprites;
    // cached reference
    [SerializeField] Level level;

    // state variable
    [SerializeField] int hitTimes; // serialized for debug
    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(gameObject.tag == "Breakable")
            level.countBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            hitTimes++;
            if (hitTimes >= maxHits)
            {
                destroyBlock();
            } else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = hitTimes-1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    public void destroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().addToScore();
        Destroy(gameObject);
        TriggerParticleSFX();   
        level.decreaseBlockCount();

    }
    private void TriggerParticleSFX()
    {
        GameObject particle = Instantiate(particleSFX, transform.position , transform.rotation);
        Destroy(particle, 1f);
    }
}
