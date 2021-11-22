using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class Client : MonoBehaviour
{
    private WebSocket ws;
    
    void Start()
    {
        ws = new WebSocket("ws://localhost:3000/");
        ws.OnOpen += (sender, e) => { Debug.Log("websocket Open"); };

        ws.OnMessage += (sender, e) => {};

        ws.OnError += (sender, e) => { Debug.Log("Websocket Error Massage" + e.Message); };

        ws.OnClose += (sender, e) => { Debug.Log("WebSocket Close"); };

        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            ws.Send("Test Message");
        }
    }

    private void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}
