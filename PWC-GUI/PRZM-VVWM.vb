Partial Public Class Form1
    Sub RunPRZMandVVWM()

        'Run PRZMPRZM on a separate thread

        CalculateButton.Text = "working..."
        CalculateButton.Enabled = False
        BackgroundWorker1.RunWorkerAsync()


    End Sub



End Class
