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
        _controller.Roll = -(euler.y > 180 ? euler.y - 360 : euler.y);
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
