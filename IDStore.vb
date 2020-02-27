Public Class IDStore
    Public FName As String = "./IDStore.csv"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tablename As String = "export"
        Dim DataSet As DataSet = New DataSet()
        DataSet.Tables.Add(tablename)
        DataSet.Tables(tablename).Columns.Add("Common Name")
        DataSet.Tables(tablename).Columns.Add("Web Location")
        DataSet.Tables(tablename).Columns.Add("ID")
        DataSet.Tables(tablename).Columns.Add("PWD")
        DataSet.Tables(tablename).Columns.Add("Notes")

        Dim SR As System.IO.StreamReader = New System.IO.StreamReader(FName)
        Dim allData As String = SR.ReadToEnd()
        Dim rows As String() = allData.Split(vbCrLf) '("\r".ToCharArray())
        Dim incr1 As Integer = 0
        For Each r As String In rows
            r = r.Trim(vbLf).Trim
            Dim items As String() = r.Split(",")
                If items(0) <> vbNullString And items(0) <> Nothing Then
                    DataSet.Tables(tablename).Rows.Add(items)
                End If

            incr1 += 1
        Next
        SR.Close()
        SR.Dispose()

        DataGridView1.DataSource = DataSet.Tables(0).DefaultView
        Me.Refresh()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        SaveDataGrid()
        Me.Close()
    End Sub
    Private Sub SaveDataGrid()
        Dim textstr As New System.Text.StringBuilder()
        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If IsNothing(DataGridView1.Rows(x).Cells(0).Value) = False Then
                For v As Integer = 0 To DataGridView1.Columns.Count - 1
                    'extracting cell value from 0 to 9 and add it on list
                    If v > 0 Then
                        textstr.Append(",")
                    End If
                    Dim tempstr As String = DataGridView1.Rows(x).Cells(v).Value.ToString()
                    tempstr = tempstr.Replace(",", "") ' remove any commas input into any field so csv file is not corrupted
                    textstr.Append(tempstr)
                Next
            End If
            'adding new line to text
            textstr.AppendLine()
        Next
        IO.File.WriteAllText(FName, textstr.ToString())

        Exit Sub
    End Sub

    Private Sub btnExitNoSave_Click(sender As Object, e As EventArgs) Handles btnExitNoSave.Click
        Me.Close()
        Exit Sub
    End Sub
End Class
