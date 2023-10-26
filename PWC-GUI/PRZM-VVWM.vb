Partial Public Class Form1
    Sub RunPRZMandVVWM()

        CalculateButton.Text = "working..."
        CalculateButton.Enabled = False
        BackgroundWorker1.RunWorkerAsync()

        ''The file name should be stored somewhere already but for now here it is
        'Dim PRZMVVWMinputFile As String = FileNames.WorkingDirectory & "PRZMVVWM.txt"
        'SaveInputsAsTextFile(PRZMVVWMinputFile)

        'Dim p As Process = New Process
        'p.StartInfo.FileName = My.Application.Info.DirectoryPath() & "\PRZM-VVWM.exe"
        'p.StartInfo.Arguments = """" & PRZMVVWMinputFile & """"
        'p.StartInfo.UseShellExecute = False
        'p.StartInfo.RedirectStandardOutput = True
        'p.StartInfo.RedirectStandardError = True
        'p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        'p.StartInfo.CreateNoWindow = True
        'p.Start()

        'Dim output As String = p.StandardOutput.ReadToEnd
        'Dim output2 As String = p.StandardError.ReadToEnd

        ''  p.WaitForExit()
        'My.Computer.FileSystem.WriteAllText("run_status.txt", output & output2, False, System.Text.Encoding.ASCII)

    End Sub



End Class
