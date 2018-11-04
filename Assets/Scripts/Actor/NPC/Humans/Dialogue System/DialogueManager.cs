/*---------------------------------------------------
 * 制作日 : 2018年10月04日
 * 制作者：シスワントレサ
 * 内容　：対話情報を管理するクラス
 * 最後の更新：2018年10月4日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    [SerializeField]
    private Image humanPortrait;
    public Image HumanPortrait
    {
        get { return humanPortrait; }
        set { humanPortrait = value; }
    }

    [SerializeField]
    private new TMPro.TextMeshProUGUI name;
    public TMPro.TextMeshProUGUI Name
    {
        get { return name; }
        set { name = value; }
    }

    [SerializeField]
    private TMPro.TextMeshProUGUI dialogue;
    public TMPro.TextMeshProUGUI Dialogue
    {
        get { return dialogue; }
        set { dialogue = value; }
    }

    private bool isCorrectHuman;
    public bool IsCorrectHuman
    {
        get { return isCorrectHuman; }
        set { isCorrectHuman = value; }
    }

    private Queue<string> dialogueQueue;

    /// <summary>
    /// 現在犬と話しているのか？
    /// </summary>
    private bool isTalking;
    public bool IsTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }

    [SerializeField]
    private GameObject spaceToNext;

    private void Start()
    {
        dialogueQueue = new Queue<string>();
        isTalking = false;
    }

    public void StartConversation(string[] sentences)
    {
        dialogueQueue.Clear();

        foreach (string sentence in sentences)
        {
            dialogueQueue.Enqueue(sentence);
        }
        ContinueConversation();
    }

    public void ContinueConversation()
    {
        spaceToNext.SetActive(false);
        if(dialogueQueue.Count == 0)
        {
            StopAllCoroutines();
            GiveOrLeave();
            return;
        }

        string sentence = dialogueQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogue.text = "";
        StringBuilder builder = new StringBuilder();
        foreach (char letter in sentence.ToCharArray())
        {
            builder.Append(letter);
            dialogue.text = builder.ToString();
            yield return null;
        }
        spaceToNext.SetActive(true);
    }

    void GiveOrLeave()
    {
        dialogue.text = "will you give " + name.text + " the light ?";

        StartCoroutine(WaitForKeyPressed());
    }

    IEnumerator WaitForKeyPressed()
    {
        yield return new WaitForSeconds(2f);
        
        bool keyPressed = false;
        while(!keyPressed)
        {
            Debug.Log("Enter Loop");

            if (Input.GetKeyDown(KeyCode.X)) // プレイヤは話した人間を離れる
            {
                Debug.Log("X Key Pressed !!!");
                EndConversation();
                yield break;
            }
            else if (Input.GetKeyUp(KeyCode.C)) // ライトを人間に渡す「ゲームオーバーかどうか」
            {
                Debug.Log("C Key Pressed !!!");
                keyPressed = true;
            }
            yield return null;
        }
        // Report the result of the game.
        PreloadComponent.gameOver.Gameover(isCorrectHuman);

        yield break;
    }

    public void EndConversation()
    {
        StopAllCoroutines();
        gameObject.GetComponent<Animator>().SetBool("IsTalking", false);
        isTalking = false;
        // プレイヤは入力が得られるように。
        PreloadComponent.events.isPlayerControllable.Raise();
    }
} // !class
