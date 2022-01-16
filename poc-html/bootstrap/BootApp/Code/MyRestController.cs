﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BootApp.Code;

[MyAttribute]
public class MyRestController : Controller
{
    public MyRestController()
    {
        Console.WriteLine("Tesing");
    }

    [HttpGet]
    [Route("/sayhelloyoufool")]
    public string SayHello2()
    {
        return "Yolo";
    }
}