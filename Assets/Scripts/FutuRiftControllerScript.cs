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
        _controller =
            new FutuRiftController(new UdpPortSender(new UdpOptions()
            {
                ip = ipAddress,
                port = port
            }));
    }

    private void Update()
    {
        var euler = transform.eulerAngles;
        _controller.Pitch = (euler.x > 180 ? euler.x - 360 : euler.x);
        _controller.Roll = -(euler.z > 180 ? euler.z - 360 : euler.z);
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
