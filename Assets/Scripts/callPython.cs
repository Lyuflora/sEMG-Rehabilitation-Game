using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;
using System.Windows;
using Debug = UnityEngine.Debug;
using System.Threading;

public class callPython : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        Debug.Log("Button Clicked. TestClick.");
        Thread newThread = new Thread(new ThreadStart(_click));
        newThread.Start();
    }

    public void _click()
    {
        string[] strArgsIn = new string[2];//参数列表
        string pyFilename = @"main.py";//这里是python的文件名字
        strArgsIn[0] = "2";
        strArgsIn[1] = "3";
        RunPythonScript(pyFilename, strArgsIn);
    }
    //调用python核心代码
    public static void RunPythonScript(string sArgName, params string[] teps)
    {
        Process p = new Process();
        string path; //= System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径（将文件放在c#的debug文件夹中可以这样操作）
        path = @"D:\UnityProject\version1\python_codes\" + sArgName;//(因为我没放debug下，所以直接写的绝对路径,替换掉上面的路径了)
        p.StartInfo.FileName = @"D:\Program Files\Python37\python.exe";//没有配环境变量的话，可以像我这样写python.exe的绝对路径。如果配了，直接写"python.exe"即可
        string sArguments = path;
        foreach (string sigstr in teps)
        {
            sArguments += " " + sigstr;//传递参数
        }
        print("args= " + sArguments);

        //StreamWriter myStreamWriter = myProcess.StandardInput;

        p.StartInfo.Arguments = sArguments;         //设置调用时的参数
        p.StartInfo.UseShellExecute = false;        //在 Unity中使用 Log 输出外部程序执行时的输出进行查看
        p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出（所有输出会通过事件回调的方式在回调参数中返回）
        p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
        p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
        p.StartInfo.CreateNoWindow = true;          //调用时不打开新窗口

        Debug.Log("Process.start()");
        p.Start();
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);

        String input = "3";//Console.ReadLine();
        p.StandardInput.WriteLine(input);
        System.Console.ReadLine();
        p.WaitForExit();    //使外部脚本与Unity脚本同步执行

        /*// 完成导入之后，调用一下刷新方法，确保 Unity Editor 加载到的配置文件都是最新
        AssetDatabase.Refresh();*/  // what is its use here

    }
    //输出打印的信息
    static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            AppendText(e.Data + Environment.NewLine);
            //在此处解析从python文件收到的值，主要为手势的编号

        }
    }
    public delegate void AppendTextCallback(string text);
    public static void AppendText(string text)
    {
        //Console.WriteLine(text);     //此处在控制台输出.py文件print的结果
        print("从py接收输出：" + text);
    }
}

