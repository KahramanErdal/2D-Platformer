using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image heartPrefab;
    public Sprite fullHealthSprite;
    public Sprite emptyHealthSprite;

    private List<Image> hearts = new List<Image>();
   
    public void SetMaxHearts(int maxHearts)
    {
        foreach (Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }

        hearts.Clear();
        
        for(int i = 0; i < maxHearts; i++)
        {
            Image newHeart = Instantiate(heartPrefab, transform);
            newHeart.sprite = fullHealthSprite;
            hearts.Add(newHeart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count;i++) 
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHealthSprite;
            }
            else
            {
                hearts[i].sprite = emptyHealthSprite;
            }
        }
    }
}
