using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine.UI;

public sealed class UIManager : MonoBehaviour
{
    //[SerializeField] GameObject sampleButtonUI;
    [SerializeField] UIDocument _uiDocument;
    [SerializeField] string firstSceneName = "ProjectionTestScene";
    
    TextField inpElem1, inpElem2, inpElem3, inpElem4, inpElem5, inpElem6;
    Label label;
    VisualElement headerElement;
    ROSConnection ros;
    GameObject rosObject;
    Color errorColor = new Color(0.75f, 0f, 0f);
    bool enableTransition = false;
    float _h;

    float lastTime = 0;
    float duration = 1 / 30f;
    void Start()
    {
        //UI関連のエレメントを各変数と紐付け
        //接続ボタン
        var connectElement = _uiDocument.rootVisualElement.Q<Label>("Connect");
        connectElement.AddManipulator(new Clickable(ButtonClicked));

        //終了ボタン
        var quitElement = _uiDocument.rootVisualElement.Q<Label>("Quit");
        quitElement.AddManipulator(new Clickable(QuitButtonClicked));

        //上部文字列
        label = _uiDocument.rootVisualElement.Q<Label>("DescriptionText1");

        //IPアドレス
        inpElem1 = _uiDocument.rootVisualElement.Q<TextField>("IPTextField1");
        inpElem2 = _uiDocument.rootVisualElement.Q<TextField>("IPTextField2");
        inpElem3 = _uiDocument.rootVisualElement.Q<TextField>("IPTextField3");
        inpElem4 = _uiDocument.rootVisualElement.Q<TextField>("IPTextField4");

        //名前空間の入力欄
        inpElem5 = _uiDocument.rootVisualElement.Q<TextField>("NamespaceInputField");
        inpElem6 = _uiDocument.rootVisualElement.Q<TextField>("PortInputField");

        //ヘッダ
        headerElement = _uiDocument.rootVisualElement.Q<VisualElement>("Header");
        _h = Screen.height * 0.1f;

        //ROSConnectionPrefabがあり、かつ、なんらかエラーを吐いている場合例外処理と、ユーザへ通知
        rosObject = GameObject.Find("ROSConnectionPrefab(Clone)");
        if(rosObject != null && rosObject.GetComponent<ValueTransport>().connectionError)
        {
            label.text = "Settings Menu --[ERROR] Connection Failed.";
            label.style.color = errorColor; //文字色は赤
        }
    }

    void ButtonClicked()
    {
        //すべての入力項目が満たされている場合の処理
        if(inpElem1.text != "" && inpElem2.text != "" && inpElem3.text != "" && inpElem4.text != "" && inpElem5.text != "" && inpElem6.text != "")
        {
            enableTransition = true;
            string ipAddress = inpElem1.text + "." + inpElem2.text + "." + inpElem3.text + "." + inpElem4.text;

            ros = ROSConnection.GetOrCreateInstance();
            ros.ConnectOnStart = false;
            ros.RosIPAddress = ipAddress;
            ros.RosPort = int.Parse(inpElem6.text);;
            ros.ShowHud = false;
            ros.NetworkTimeoutSeconds = 1f; 
            ros.listenForTFMessages = false;

            rosObject = GameObject.Find("ROSConnectionPrefab(Clone)");
            rosObject.AddComponent<ValueTransport>();
            rosObject.GetComponent<ValueTransport>().rosNamespace = inpElem5.text;

            rosObject.AddComponent<QuitApplication>();
            
            ros.Connect();

            DontDestroyOnLoad(rosObject);            
        }
        else //入力に不備がある場合
        {
            label.text = "Settings Menu --[ERROR] Please Fill All Forms.";
            label.style.color = errorColor;
        }     
    }

    // Update is called once per frame
    void Update()
    {
        if(enableTransition)
        {
            if(Time.time - lastTime > duration)
            {
                _h += (Screen.height - _h) * (1080f / Screen.height * 0.125f);
                headerElement.style.height = _h;

                lastTime = Time.time;
            }

            if (_h > Screen.height * 0.99)
            {
                rosObject.GetComponent<ValueTransport>().connectionError = ros.HasConnectionError;
                if(ros.HasConnectionError)
                {                    
                    SceneManager.LoadScene("IPAddressInput");
                    ros.Disconnect();
                }
                else
                {
                    SceneManager.LoadScene(firstSceneName);
                }
            }
        }
    }

    void QuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnApplicationQuit()
    {
        if(enableTransition)
        {
            ros.Disconnect();
        }
    }
}
