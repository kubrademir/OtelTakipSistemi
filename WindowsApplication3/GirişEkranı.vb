Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class GirişEkranı
    Dim con As New SqlConnection
    Dim komut As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Private Sub Button2_YoneticiGirisi_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        Dim KAdi As String = ComboBox1.SelectedItem
        Dim Sifre As String = TextBox2.Text
        Dim komut2 As SqlCommand = New SqlCommand()
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter
        Dim dataSet As DataSet = New DataSet
        komut2.CommandText = " Select Ad,Sifre from Kisi where Ad='" & KAdi & "' And Sifre='" & Sifre & "' and Tur=3"
        con.Open()
        komut2.Connection = con
        dataAdapter.SelectCommand = komut2
        dataAdapter.Fill(dataSet, "0")
        Dim Count = dataSet.Tables(0).Rows.Count
        If Count > 0 Then
            AnaMenü.Show()
            Me.Hide()
            con.Close()
        Else
            MessageBox.Show("Kullanıcı Adı ya da Şifreyi Yanlış girdiniz!!")

        End If


    End Sub


    Private Sub Button1_PersonelGirisi_Click(sender As Object, e As EventArgs) Handles Button2.Click

        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        Dim KAdi As String = ComboBox1.SelectedItem
        Dim Sifre As String = TextBox2.Text
        Dim komut2 As SqlCommand = New SqlCommand()
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter
        Dim dataSet As DataSet = New DataSet
        komut2.CommandText = " Select Ad,Sifre from Kisi where Ad='" & KAdi & "' And Sifre='" & Sifre & "' and Tur=2"
        con.Open()
        komut2.Connection = con
        dataAdapter.SelectCommand = komut2
        dataAdapter.Fill(dataSet, "0")
        Dim Count = dataSet.Tables(0).Rows.Count
        If Count > 0 Then
            AnaMenü.Button1.Enabled = False
            AnaMenü.Button4.Enabled = False
            AnaMenü.Button5.Enabled = False
            AnaMenü.Button6.Enabled = False
            Odaİşlemleri.Button2.Enabled = False
            Odaİşlemleri.Button3.Enabled = False
            AnaMenü.Show()
            Me.Hide()
            con.Close()
        Else
            MessageBox.Show("Kullanıcı Adı ya da Şifreyi Yanlış girdiniz!!")

        End If



    End Sub

    Private Sub GirişEkranı_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        komut.CommandText = "SELECT  Ad FROM  Kisi"
        komut.Connection = con
        komut.CommandType = CommandType.Text
        con.Open()
        dr = komut.ExecuteReader()
        While (dr.Read())

            ComboBox1.Items.Add(dr("Ad"))
        End While
        con.Close()


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then

            TextBox2.PasswordChar = "*"
        End If
    End Sub
End Class
