Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class OdaArama
    Dim con As New SqlConnection
    Dim komut As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        KayıtEkranı.Show()
        Me.Hide()

    End Sub



    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        GirişEkranı.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()

    End Sub

    Private Sub OdaArama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")

        komut.CommandText = "SELECT distinct OdaTuru FROM  Oda"
        komut.Connection = con
        komut.CommandType = CommandType.Text
        con.Open()
        dr = komut.ExecuteReader()
        While (dr.Read())

            ComboBox2.Items.Add(dr("OdaTuru"))
        End While
        con.Close()
        Dim komut2 As SqlCommand = New SqlCommand
        Dim dr2 As SqlDataReader
        komut2.CommandText = "SELECT distinct KisiSayisi FROM  Oda"
        komut2.Connection = con
        komut2.CommandType = CommandType.Text
        con.Open()
        dr2 = komut2.ExecuteReader()
        While (dr2.Read())

            ComboBox3.Items.Add(dr2("KisiSayisi"))
        End While
        con.Close()
    End Sub
    Private Sub Button1_Ara_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UygunOda As New Odalar
        Dim OdaTuru, KisiSayisi, Fiyati As String
        OdaTuru = ComboBox2.SelectedItem
        KisiSayisi = ComboBox3.SelectedItem
        Fiyati = TextBox5.Text
        UygunOda.OdaAra(OdaTuru, KisiSayisi, Fiyati)
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdaAra", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@OdaTuru", OdaTuru)
        komutsatiri.Parameters.AddWithValue("@Fiyati", Fiyati)
        komutsatiri.Parameters.AddWithValue("@KisiSayisi", KisiSayisi)
        komutsatiri.ExecuteNonQuery()
        con.Close()
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Oda")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AnaMenü.Show()
        Me.Hide()

    End Sub
End Class

