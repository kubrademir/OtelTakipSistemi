Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Odaİşlemleri
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Sub DatagridYenile()
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdalariGoster", con)
        komutsatiri.CommandType = CommandType.StoredProcedure

        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Oda")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button3_OdaCikar_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim OdaIptal As New Odalar
        Dim OdaId As Integer
        OdaId = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        OdaIptal.OdaCikar(OdaId)
        DatagridYenile()

    End Sub

    Private Sub Button2_OdaEkle_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim oda As New Odalar
        Dim OdaNo, KisiSayisi, Fiyati, OdaTuru As String

        OdaNo = TextBox1.Text
        OdaTuru = TextBox2.Text
        KisiSayisi = TextBox3.Text
        Fiyati = TextBox5.Text
        oda.OdaEkle(OdaNo, OdaTuru, KisiSayisi, Fiyati)
        DatagridYenile()

    End Sub


    Private Sub Button5_Temizle_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()

    End Sub

    Private Sub Button6_Göster_Click(sender As Object, e As EventArgs) Handles Button6.Click
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("OdalariGoster", con)
        komutsatiri.CommandType = CommandType.StoredProcedure

        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Oda")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Odaİşlemleri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DatagridYenile()

    End Sub

    Private Sub Button1_OdaAra_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OdaArama.Show()
        Me.Hide()

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