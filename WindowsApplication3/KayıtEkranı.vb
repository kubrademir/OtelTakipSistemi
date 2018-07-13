Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class KayıtEkranı
    Dim con As New SqlConnection
    Dim komut As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader


    Private Sub Button1_Kaydet_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MusteriKimlik, Musteri As New Kisi
        Dim TC_No, Ad, Soyad, DogumTarihi, DogumYeri, Cinsiyeti, Adres, TelNo, Eposta, Tur, OdaId, GelisTarihi, AyrilisTarihi, Alinan, Durum As String
        TC_No = TextBox5.Text
        Ad = TextBox1.Text
        Soyad = TextBox2.Text
        DogumTarihi = DateTimePicker3.Value.ToString("yyyy-MM-dd")
        DogumYeri = TextBox7.Text
        If RadioButton1.Checked Then
            Cinsiyeti = RadioButton1.Text
        Else
            Cinsiyeti = "Erkek"
        End If
        TelNo = TextBox6.Text
        Adres = TextBox4.Text
        Eposta = TextBox3.Text
        Tur = 2
        OdaId = ComboBox2.SelectedItem
        GelisTarihi = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        AyrilisTarihi = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Alinan = TextBox8.Text
        Durum = 1
        MusteriKimlik.MüsteriKimlik(TC_No, Ad, Soyad, DogumTarihi, DogumYeri, Cinsiyeti, TelNo, Adres, Eposta, Tur)
        Musteri.MüsteriEkle(TC_No, OdaId, GelisTarihi, AyrilisTarihi, Durum, Alinan)
        MsgBox("Kayıt Tamamlandı!")



    End Sub

    Private Sub KayıtEkranı_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        Dim komut2 As SqlCommand = New SqlCommand
        Dim dr2 As SqlDataReader
        komut2.CommandText = "SELECT distinct OdaNo FROM  Oda"
        komut2.Connection = con
        komut2.CommandType = CommandType.Text
        con.Open()
        dr2 = komut2.ExecuteReader()
        While (dr2.Read())

            ComboBox2.Items.Add(dr2("OdaNo"))
        End While
        con.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        GirişEkranı.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AnaMenü.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Hesapla_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fiyat As Decimal
        Dim ilk As Date = DateTimePicker1.Value
        Dim son As Date = DateTimePicker2.Value
        Dim fark As TimeSpan = son - ilk
        Dim fark1 As Integer = Convert.ToInt32(fark.Days.ToString())
        fark1 = fark1 + 1
        fiyat = TextBox9.Text
        TextBox8.Text = fark1.ToString() * fiyat
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TC_No As String
        TC_No = TextBox5.Text
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MüsteriCikar", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.ExecuteNonQuery()
        con.Close()
        MsgBox("Kayıt Başarıyla Silinmiştir !")
    End Sub
End Class