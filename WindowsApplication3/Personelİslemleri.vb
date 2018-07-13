Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Personelİslemleri
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Sub DatagridYenile()
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("PersoneliGoster", con)
        komutsatiri.CommandType = CommandType.StoredProcedure

        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Kisi")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
    Private Sub Button3_Temizle_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()


    End Sub


    Private Sub Button1_PersonelEkle_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim personel As New Kisi
        Dim TC_No, Ad, Soyad, DogumTarihi, DogumYeri, Cinsiyeti, Adres, TelNo, Eposta, Tur As String
        TC_No = TextBox1.Text
        Ad = TextBox2.Text
        Soyad = TextBox3.Text
        DogumTarihi = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        DogumYeri = TextBox4.Text
        If RadioButton1.Checked Then
            Cinsiyeti = RadioButton1.Text
        Else
            Cinsiyeti = "Erkek"
        End If
        TelNo = TextBox5.Text
        Adres = TextBox6.Text
        Eposta = TextBox7.Text
        Tur = 1
        personel.PersonelEkle(TC_No, Ad, Soyad, DogumTarihi, DogumYeri, Cinsiyeti, TelNo, Adres, Eposta, Tur)
        DatagridYenile()
    End Sub

    Private Sub Button2_PersonelCikar_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TC_No As String
        Dim Personel As New Kisi
        TC_No = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        Personel.PersonelCikar(TC_No)
        DatagridYenile()
    End Sub

    Private Sub Button4_Listele_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DatagridYenile()
    End Sub

    Private Sub Button5_Ara_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Personel As New Kisi
        Dim TC_No As String
        TC_No = TextBox1.Text
        Personel.PersonelAra(TC_No)
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("PerAra", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.ExecuteNonQuery()
        con.Close()
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Kisi")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Personelİslemleri_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim TC_No, Ad, Soyad, DogumTarihi, DogumYeri, Cinsiyeti, Adres, TelNo, Eposta, Tur, Sifre As String
        TC_No = TextBox1.Text
        Ad = TextBox2.Text
        Soyad = TextBox3.Text
        DogumTarihi = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        DogumYeri = TextBox4.Text
        If RadioButton1.Checked Then
            Cinsiyeti = RadioButton1.Text
        Else
            Cinsiyeti = "Erkek"
        End If
        TelNo = TextBox5.Text
        Adres = TextBox6.Text
        Eposta = TextBox7.Text
        Sifre = TextBox8.Text
        Tur = 3
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("YoneticiEkle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.Parameters.AddWithValue("@Ad", Ad)
        komutsatiri.Parameters.AddWithValue("@Soyad", Soyad)
        komutsatiri.Parameters.AddWithValue("@DogumTarihi", DogumTarihi)
        komutsatiri.Parameters.AddWithValue("@DogumYeri", DogumYeri)
        komutsatiri.Parameters.AddWithValue("@Cinsiyeti", Cinsiyeti)
        komutsatiri.Parameters.AddWithValue("@TelNo", TelNo)
        komutsatiri.Parameters.AddWithValue("@Adres", Adres)
        komutsatiri.Parameters.AddWithValue("@Eposta", Eposta)
        komutsatiri.Parameters.AddWithValue("@Tur", Tur)
        komutsatiri.Parameters.AddWithValue("@Sifre", Sifre)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        AnaMenü.Show()


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        GirişEkranı.Show()


    End Sub
End Class