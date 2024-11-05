using System;
using Futurift;
using Futurift.DataSenders;
using Futurift.Options;
using UnityEngine;


public class FutuRiftControllerScript : MonoBehaviour
{
    private FutuRiftController _controller;

    [SerializeField] private string ipAddress = "";

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _controller.Pitch++;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _controller.Pitch--;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _controller.Pitch++;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _controller.Pitch--;
        }
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
