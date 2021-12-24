using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SetUI : MonoBehaviour
{
    GameManager gameManager;
    
    [SerializeField]
    private Transform graveTextPos;
    [SerializeField]
    private TMP_Text textAge;
    [SerializeField]
    private TMP_Text stateText;
    [SerializeField]
    private TMP_Text textGameEnd;
    [SerializeField]
    private Image image;
    [SerializeField]
    GameObject revive;
    [SerializeField]
    GameObject settings;
    [SerializeField]
    Devil devil;

    

    [SerializeField]
    AudioSource heartbeat;
    bool isHeartbeatAdjusted;

    float health;
    Tweener fill;
    Tweener color;
    void Start()
    {       
        gameManager = GameManager.Instance;
        fill = image.DOFillAmount(health, 0.2f).SetAutoKill(false);
        color = image.DOColor(Color.Lerp(Color.red, Color.black, health),0.3f).SetAutoKill(false);
    }

    // Update is called once per frame
    void Update()
    {       
            textAge.text = $"Age: {gameManager.SecondsPassed.ToString("#0")}";
            gameManager.MostPossibleLife = Mathf.Max(0,gameManager.MostPossibleLife);
            health =((gameManager.MostPossibleLife - gameManager.SecondsPassed)/gameManager.MostPossibleLife);
            if(health <0.5f && !isHeartbeatAdjusted)
            {
                heartbeat.pitch =2;
                isHeartbeatAdjusted = true;
            }
            if(!gameManager.gameEnd)
            {
                stateText.gameObject.SetActive(true);
                stateText.text = gameManager.Pe.StateMachine.CurrentState.ToString();
            }
            fill.ChangeEndValue(health, true).Restart();
            color.ChangeEndValue(Color.Lerp(Color.red, Color.black, health),true).Restart();

            if(gameManager.gameEnd && health <0.01f && gameManager.isScoreShouldBeDefined)
            {
                StartCoroutine(KeepTextInPos());
                heartbeat.Stop();
                if((int)gameManager.SecondsPassed > PlayerPrefs.GetInt("theSurvivor"))
                {
                    PlayerPrefs.SetInt("theSurvivor", (int)gameManager.SecondsPassed);
                }
                
                SetActivation();
                revive.gameObject.transform.DOScale(1.1f, 0.5f).SetLoops(-1,LoopType.Yoyo);
                gameManager.isScoreShouldBeDefined = false;
            }
        }

        public void Restart()
        {
            PlayerPrefs.SetFloat("Seconds", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoToMenu()
        {
            PlayerPrefs.SetFloat("Seconds", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        void SetActivation()
        { 
            textAge.gameObject.SetActive(false);
            settings.SetActive(true);
            revive.SetActive(true);
        }

        IEnumerator KeepTextInPos()
        {
            textGameEnd.text = string.Concat("You died \n <color=grey><size=2em><b>", gameManager.SecondsPassed.ToString("#0"), "</size></b></color>\n years old");
            textGameEnd.gameObject.SetActive(true);

            while(!gameManager.isUISet)
            {   
                textGameEnd.gameObject.transform.position = gameManager.Cam.WorldToScreenPoint(graveTextPos.position);
                yield return null;
            }
            
            devil.gameObject.SetActive(true);
            yield break;
        }
    
}
