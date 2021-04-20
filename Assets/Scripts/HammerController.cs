using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public Text finalScore;
    public Image finalBackground;
    public Text finalText1;
    public Text finalText2;

    private MoleSpawner ms;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ms = GetComponent<MoleSpawner>();
        finalBackground.enabled = false;
        finalScore.enabled = false;
        finalText1.enabled = false;
        finalText2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ms.gameTime > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
                score++;
                scoreText.text = score.ToString();
                if(ms.gameTime >= 10)
                {
                    ms.moleTime = 2;
                } else if(ms.gameTime < 10)
                {
                    ms.moleTime = 1;
                }
                
                ms.Spawn();
            }
        }

        if(ms.gameTime < 1)
        {
            finalScore.text = score.ToString();
            finalScore.enabled = true;
            finalBackground.enabled = true;
            finalText1.enabled = true;
            finalText2.enabled = true;
        }
    }
}
