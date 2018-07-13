Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Urunler
    Public UrunKodu As String
    Public UrunAdi As String
    Public KategoriAdi As String
    Public Adedi As String
    Public Fiyati As String
    Public Markasi As String
    Public ToplamTutar As String
    Public Sub UrunEkle(ByVal KategoriAdi As String, ByVal Markasi As String, ByVal UrunAdi As String, ByVal UrunKodu As String, ByVal Fiyati As String, ByVal Adedi As String, ByVal ToplamTutar As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("UrunEkle", con)
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
    End Sub
    Public Sub UrunCikar(ByVal UrunKodu As String)
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("UrunCikar", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@UrunKodu", UrunKodu)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub UrunAra(ByVal UrunKodu As String)
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("UrunAra", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@UrunKodu", UrunKodu)
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Urun")
        Ürünler.DataGridView1.DataSource = ds.Tables(0)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub

End Class
Public Class Odalar
    Public OdaNo As String
    Public OdaTuru As String
    Public KisiSayisi As String
    Public Fiyati As String
    Public Sub OdaEkle(ByVal OdaNo As String, ByVal OdaTuru As String, ByVal KisiSayisi As String, ByVal Fiyati As String)

        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdaEkle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@OdaTuru", OdaTuru)
        komutsatiri.Parameters.AddWithValue("@OdaNo", OdaNo)
        komutsatiri.Parameters.AddWithValue("@Fiyati", Fiyati)
        komutsatiri.Parameters.AddWithValue("@KisiSayisi", KisiSayisi)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub OdaCikar(ByVal OdaId As String)
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdaCikar", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@OdaId", OdaId)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub OdaAra(ByVal OdaTuru As String, ByVal KisiSayisi As String, ByVal Fiyati As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdaAra", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@OdaTuru", OdaTuru)
        komutsatiri.Parameters.AddWithValue("@Fiyati", Fiyati)
        komutsatiri.Parameters.AddWithValue("@KisiSayisi", KisiSayisi)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub

End Class
Public Class Kisi
    Public Ad
    Public Soyad
    Public Adres
    Public TelNo
    Public TC_No
    Public DogumYeri
    Public DogumTarihi
    Public Cinsiyet
    Public Eposta
    Public Tur
    Public Maasi
    Public Sub PersonelEkle(ByVal TC_No As String, ByVal Ad As String, ByVal Soyad As String, ByVal DogumTarihi As String, ByVal DogumYeri As String, ByVal Cinsiyeti As String, ByVal TelNo As String, ByVal Adres As String, ByVal Eposta As String, ByVal Tur As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("PersonelEkle", con)
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
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub PersonelCikar(ByVal TC_No As String)
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("PersonelCikar", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub MaasEkle(ByVal TC_No As String, ByVal Maasi As String, ByVal YatirilanTarih As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MaasEkle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.Parameters.AddWithValue("@Maasi", Maasi)
        komutsatiri.Parameters.AddWithValue("@YatirilanTarih", YatirilanTarih)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub PersonelAra(ByVal TC_No As String)
        Dim con = New SqlConnection("Data Source= KÜBRA; database=OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("PersonelAra", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Maas")
        MaaşTakip.DataGridView1.DataSource = ds.Tables(0)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub MüsteriKimlik(ByVal TC_No As String, ByVal Ad As String, ByVal Soyad As String, ByVal DogumTarihi As String, ByVal DogumYeri As String, ByVal Cinsiyeti As String, ByVal TelNo As String, ByVal Adres As String, ByVal Eposta As String, ByVal Tur As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MusteriKimlik", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.Parameters.AddWithValue("@Ad", Ad)
        komutsatiri.Parameters.AddWithValue("@Soyad", Soyad)
        komutsatiri.Parameters.Add("@DogumTarihi", SqlDbType.Date)
        komutsatiri.Parameters("@DogumTarihi").Value = DogumTarihi
        komutsatiri.Parameters.AddWithValue("@DogumYeri", DogumYeri)
        komutsatiri.Parameters.AddWithValue("@Cinsiyeti", Cinsiyeti)
        komutsatiri.Parameters.AddWithValue("@TelNo", TelNo)
        komutsatiri.Parameters.AddWithValue("@Adres", Adres)
        komutsatiri.Parameters.AddWithValue("@Eposta", Eposta)
        komutsatiri.Parameters.AddWithValue("@Tur", Tur)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub MüsteriEkle(ByVal TC_No As String, ByVal OdaId As String, ByVal GelisTarihi As String, ByVal AyrilisTarihi As String, ByVal Durum As String, ByVal Alinan As String)
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MusteriEkle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.Parameters.AddWithValue("@OdaId", OdaId)
        komutsatiri.Parameters.AddWithValue("@GelisTarihi", GelisTarihi)
        komutsatiri.Parameters.AddWithValue("@AyrilisTarihi", AyrilisTarihi)
        komutsatiri.Parameters.AddWithValue("@Durum", Durum)
        komutsatiri.Parameters.AddWithValue("@Alinan", Alinan)
        komutsatiri.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
