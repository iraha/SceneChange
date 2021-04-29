using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerUI : MonoBehaviour
{

    public GameObject gameOverUI;

    [SerializeField]
    private Text gamaoverText = default;

    //
    [SerializeField]
    private Text battleStartText = default;

    [SerializeField]
    private Vector3 startScale = new Vector3(10f, 10f, 10f);
    //

    [SerializeField]
    private Vector3 startPosition = new Vector3(550f, 2000f, 0f);

    [SerializeField]
    private Vector3 endPosition = new Vector3(550f, 1300f, 0f);

    [SerializeField]
    private Vector3 boundPosition1 = new Vector3(550f, 1420f, 0f);

    [SerializeField]
    private Vector3 boundPosition2 = new Vector3(550f, 1350f, 0f);

    [SerializeField]
    private int divisionFrame = 1000;

    [SerializeField]
    private float startSpeed = 20f;

    [SerializeField]
    private float waitSeconds = 1f;

    [SerializeField]
    private float hideSeconds = 1f;

    [SerializeField]
    private float acceleration = 0.5f;

    [SerializeField]
    private Button retireButton = default;

    [SerializeField]
    private Button continueButton = default;

    private float distance_two;


    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(true);
        this.startPosition = new Vector3(550f, 2000f, 0f);
        this.gamaoverText.transform.localPosition = this.startPosition;
        this.retireButton.gameObject.SetActive(false);
        this.continueButton.gameObject.SetActive(false);

        StartGameOverEffect();

    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        GameOver2();

    }

    public void GameOver()
    {
        if (Input.GetKeyDown("e"))
        {
            gameOverUI.SetActive(true);
        }
    }

    public void OnClickRetireButton()
    {
        SceneManager.LoadScene("SampleScene");
        //Debug.Log("ゲームオーバー");
    }

    public void GameOver2()
    {
        if (Input.GetKeyDown("w"))
        {
            gameOverUI.SetActive(true);
        }
    }

    public void OnClickContinueButton()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    // GameOver演出処理 -------------------------------

    public void StartGameOverEffect()
    {
        this.gamaoverText.gameObject.SetActive(true);
        distance_two = Vector3.Distance(startPosition, endPosition);

        this.startPosition = new Vector3(550f, 2000f, 0f);
        this.gamaoverText.transform.localPosition = startPosition;
        //
        //this.battleStartText.transform.localScale = startScale;
        StartCoroutine("GameOverTextEffectCoroutine");
    }

    private IEnumerator GameOverTextEffectCoroutine()
    {
        /*
        this.battleStartText.gameObject.SetActive(false);
        for (int i = 0; i <= this.divisionFrame; i++)
        {
            this.battleStartText.transform.localScale = Vector3.Lerp(this.startScale, Vector3.one, ((float)i / (float)this.divisionFrame));
            yield return null;
        }
        yield return new WaitForSeconds(this.waitSeconds);
        while (this.battleStartText.color.a > 0)
        {
            this.battleStartText.transform.localScale += (Vector3.one * 0.1f);
            this.battleStartText.color -= (Color.black * (Time.deltaTime / this.hideSeconds));
            yield return null;
        }
        this.battleStartText.color = Color.clear;
        this.battleStartText.gameObject.SetActive(false);
        Debug.Log("BattleStart演出終了");
        */

        // --------------------------------------
        Debug.Log("ゲームオーバーテキスト開始");
        //float speed = startSpeed;

        startSpeed = 20f;

        this.gamaoverText.gameObject.SetActive(true);

        for (int i = 0; i <= this.startSpeed; i++)
        {
            this.gamaoverText.transform.localPosition = Vector3.Lerp(this.startPosition, this.endPosition, ((float)i / (float)this.startSpeed));
            yield return null;
        }

        Debug.Log("バウンド1");
        startSpeed = 5f;
        for (int i = 0; i <= this.startSpeed; i++)
        {
            this.gamaoverText.transform.localPosition = Vector3.Lerp(this.endPosition, this.boundPosition1, ((float)i / (float)this.startSpeed));
            yield return null;
        }

        startSpeed = 5f;
        for (int i = 0; i <= this.startSpeed; i++)
        {
            this.gamaoverText.transform.localPosition = Vector3.Lerp(this.boundPosition1, this.endPosition, ((float)i / (float)this.startSpeed));
            yield return null;
        }

        Debug.Log("バウンド2");
        startSpeed = 2f;
        for (int i = 0; i <= this.startSpeed; i++)
        {
            this.gamaoverText.transform.localPosition = Vector3.Lerp(this.endPosition, this.boundPosition2, ((float)i / (float)this.startSpeed));
            yield return null;
        }

        startSpeed = 2f;
        for (int i = 0; i <= this.startSpeed; i++)
        {
            this.gamaoverText.transform.localPosition = Vector3.Lerp(this.boundPosition2, this.endPosition, ((float)i / (float)this.startSpeed));
            yield return null;
        }

        yield return new WaitForSeconds(this.waitSeconds);


    }



    // ここまでGameOver演出処理 -------------------------


}
