using System;
using Futurift;
using Futurift.DataSenders;
using Futurift.Options;
using UnityEngine;


public class FutuRiftControllerScript : MonoBehaviour
{
    private FutuRiftController _controller;

    [SerializeField] private string ipAddress = "127.0.0.1";

    [SerializeField] private int port = 6065;

    [SerializeField] private float initialPitch = 0.0f;
    
    [SerializeField] private float initialRoll = 0.0f;
    
    [SerializeField] private int interval = 100;

    private void Awake()
    {
        var udpOptions = new UdpOptions()
        {
            ip = ipAddress,
            port = port
        };

        var futuRiftOptions = new FutuRiftOptions()
        {
            interval = interval
        };

        _controller =
            new FutuRiftController(dataSender: new UdpPortSender(udpOptions), futuRiftOptions: futuRiftOptions)
            {
                Pitch = initialPitch,
                Roll = initialRoll
            };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _controller.Pitch++;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _controller.Pitch--;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _controller.Pitch++;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _controller.Pitch--;
        }

        var euler = transform.eulerAngles;
        _controller.Pitch = -(euler.x > 180 ? euler.x - 360 : euler.x);
        _controller.Roll = (euler.z > 180 ? euler.z - 360 : euler.z);
    }

    private void OnEnable()
    {
        _controller.Start();
    }

    private void OnDisable()
    {
        if (_controller != null)
        {
            _controller.Stop();
        }
    }
}
