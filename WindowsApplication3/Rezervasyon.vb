Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Rezervasyon
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Giris_Click(sender As Object, e As EventArgs) Handles Button6.Click
        KayıtEkranı.Show()
        Me.Hide()

    End Sub


    Private Sub Button3_Ara_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim OdaTipi As String
        OdaTipi = ComboBox4.SelectedItem
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdaBul", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@OdaTuru", OdaTipi)
        komutsatiri.ExecuteNonQuery()
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim dr As SqlDataReader = komutsatiri.ExecuteReader
        While (dr.Read())
            ListBox1.Items.Add(dr("OdaNo"))
        End While
        con.Close()


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Rezervasyon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()

        Dim komut As SqlCommand = New SqlCommand
        Dim dr As SqlDataReader
        komut.CommandText = "SELECT distinct OdaTuru FROM  Oda"
        komut.Connection = con
        komut.CommandType = CommandType.Text

        dr = komut.ExecuteReader()
        While (dr.Read())

            ComboBox4.Items.Add(dr("OdaTuru"))
        End While
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AnaMenü.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Kaydet_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TC_No, GelisTarihi, AyrilisTarihi, OdaNo, Durum As String
        Dim Alinan As Decimal
        TC_No = TextBox5.Text
        GelisTarihi = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        AyrilisTarihi = DateTimePicker3.Value.ToString("yyyy-MM-dd")
        Alinan = TextBox1.Text
        OdaNo = ListBox1.SelectedItem
        Durum = 2
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("RezervasyonEkle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.Parameters.AddWithValue("@GelisTarihi", GelisTarihi)
        komutsatiri.Parameters.AddWithValue("@AyrilisTarihi", AyrilisTarihi)
        komutsatiri.Parameters.AddWithValue("@Alinan", Alinan)
        komutsatiri.Parameters.AddWithValue("@OdaNo", OdaNo)
        komutsatiri.Parameters.AddWithValue("@Durum", Durum)
        komutsatiri.ExecuteNonQuery()
        con.Close()
        MsgBox("Kayıt Tamamlandı!")
    End Sub

    Private Sub Button2_Iptal_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TC_No As String
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        TC_No = TextBox5.Text
        Dim komutsatiri As SqlCommand = New SqlCommand("RezIptal", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
End Class