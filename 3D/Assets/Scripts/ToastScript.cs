using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToastScript : MonoBehaviour
{
    public static void ShowToast(string InitMessage, float? InitTimeout = null)
    {
        if (_instance._messages.Count > 0 && _instance._messages.Peek().message == InitMessage)
        {
            return;
        }

        _instance._messages.Enqueue(new ToastMessage
        {
            message = InitMessage,
            timeout = InitTimeout ?? Timeout
        });
    }

    private static ToastScript _instance;
    private TextMeshProUGUI _toastTMP;
    private const float Timeout = 5;
    private float _leftTime;
    private GameObject _content;
    private readonly Queue<ToastMessage> _messages = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _instance = this;
        _content = transform.Find("Content").gameObject;
        _toastTMP = transform.Find("Content/ToastTMP").GetComponent<TextMeshProUGUI>();
        _content.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_leftTime > 0)
        {
            _leftTime -= Time.deltaTime;
            
            if (_leftTime <= 0)
            {
                _messages.Dequeue();
                _content.SetActive(false);
            }
        }
        else if (_messages.Count > 0)
        {
            var M = _messages.Peek();
            _toastTMP.text = M.message;
            _leftTime = M.timeout;
            _content.SetActive(true);
        }
    }

    private class ToastMessage
    {
        public string message { get; set; }
        public float timeout { get; set; }
    }
}
