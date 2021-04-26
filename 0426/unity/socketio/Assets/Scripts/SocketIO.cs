using System.Collections;
using UnityEngine;
using Socket.Quobject.SocketIoClientDotNet.Client;

public class SocketIO : MonoBehaviour
{

    private QSocket socket;
    private int posID = 0;

    public Cube cube;


    // Start is called before the first frame update
    void Start()
    {
        socket = null;
        socket = IO.Socket("http://localhost:9090");

        socket.On(QSocket.EVENT_CONNECT, () => {

            Debug.Log("EVENT_CONNECT");
            socket.Emit("unity-start", ": )");

        });
        socket.On(QSocket.EVENT_DISCONNECT, () => {

            Debug.Log("EVENT_DISCONNECT");
            this.socket.Connect();
        });

        socket.On("unity-center", (data) => {
            float value = float.Parse(data.ToString());
            //Debug.Log("center:"+ value);

            if (value > 0.7f)
            {
                this.posID = 0;
            }
        });

        socket.On("unity-left", (data) => {
            float value = float.Parse(data.ToString());
            //Debug.Log("left:" + value);
            if (value > 0.7f)
            {
                this.posID = 1;
            }
        });

        socket.On("unity-right", (data) => {
            float value = float.Parse(data.ToString());
            //Debug.Log("right:" + value);
            if (value > 0.7f)
            {
                this.posID = 2;
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        switch (this.posID)
        {
            case 0:
                this.cube.moveCenter();
                break;
            case 1:
                this.cube.moveLeft();
                break;
            case 2:
                this.cube.moveRight();
                break;

        }
    }

    private void OnApplicationQuit()
    {
        socket.Disconnect();
        socket.Close();
    }

    private void OnDisable()
    {
        socket.Disconnect();
        socket.Close();
    }
}
