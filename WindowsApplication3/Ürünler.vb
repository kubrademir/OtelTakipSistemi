Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Ürünler
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader


    Private Sub Button5_Temizle_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub
    Sub DataGridYenile()
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("UrunleriGoster", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Urun")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub Button4_ListeyiGuncelle_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridYenile()

    End Sub
    Private Sub Button7_Hesapla_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox7.Text = TextBox6.Text * TextBox4.Text

    End Sub
    Private Sub Button3_Ekle_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim UrunKodu, KategoriAdi, UrunAdi, Markasi, Adedi, Fiyati, ToplamTutar As String
        Dim Urun As New Urunler

        KategoriAdi = TextBox1.Text
        UrunAdi = TextBox2.Text
        UrunKodu = TextBox3.Text
        Adedi = TextBox4.Text
        Markasi = TextBox5.Text
        Fiyati = TextBox6.Text
        ToplamTutar = TextBox7.Text
        Urun.UrunEkle(KategoriAdi, Markasi, UrunAdi, UrunKodu, Fiyati, Adedi, ToplamTutar)

        DataGridYenile()
    End Sub



    Private Sub Button2_ÜrünCikar_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim UrunIptal As New Urunler
        Dim UrunKodu As Integer
        UrunKodu = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        UrunIptal.UrunCikar(UrunKodu)

        DataGridYenile()
    End Sub

    Private Sub Button1_Ara_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Urun As New Urunler
        Dim UrunKodu As String
        UrunKodu = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        UrunKodu = Convert.ToInt32(TextBox8.Text)
        Urun.UrunAra(UrunKodu)

    End Sub

    Private Sub Ürünler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridYenile()

    End Sub

    Private Sub Button8_Guncelle_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim KategoriAdi, UrunAdi, UrunKodu, Markasi As String
        Dim Fiyati, Adedi, ToplamTutar As Decimal

        KategoriAdi = TextBox1.Text
        UrunAdi = TextBox2.Text
        Markasi = TextBox5.Text
        Fiyati = TextBox6.Text
        Adedi = TextBox4.Text
        ToplamTutar = TextBox7.Text
        UrunKodu = TextBox3.Text
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("UrunGuncelle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@KategoriAdi", KategoriAdi)
        komutsatiri.Parameters.AddWithValue("@Markasi", Markasi)
        komutsatiri.Parameters.AddWithValue("@UrunAdi", UrunAdi)
        komutsatiri.Parameters.AddWithValue("@UrunKodu", UrunKodu)
        komutsatiri.Parameters.AddWithValue("@Fiyati", Fiyati)
        komutsatiri.Parameters.AddWithValue("@Adedi", Adedi)
        komutsatiri.Parameters.AddWithValue("@ToplamTutar", ToplamTutar)
        komutsatiri.ExecuteNonQuery()
        con.Close()

        DataGridYenile()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AnaMenü.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        GirişEkranı.Show()
        Me.Hide()

    End Sub
End Class