Imports System.IO

Public Class Launcher

    Private gtkPath = "C:\Program Files (x86)\GtkRadiant 1.5.0\GtkRadiant.exe"
    Private appPath = "C:\Users\Clayton\AppData\Roaming\RadiantSettings\1.5.0\q3.game\local.pref"
    Private flag = "<epair name=""LastMap"">", endflag = "</epair>"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args() As String = System.Environment.GetCommandLineArgs()

        If args.Count < 2 Then Return

        Dim mapfile = args(1)

        Dim fileText() As String = File.ReadAllLines(appPath)

        For i = 0 To fileText.Count - 1
            If fileText(i).Contains(flag) Then fileText(i) = flag & mapfile & endflag
        Next

        File.WriteAllLines(appPath, fileText)

        Process.Start(gtkPath)

        Me.Close()
    End Sub
End Class
