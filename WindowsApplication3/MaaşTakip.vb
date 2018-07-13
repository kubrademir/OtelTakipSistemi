Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class MaaşTakip
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Sub DatagridYenile()
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MaasiGoster", con)
        komutsatiri.CommandType = CommandType.StoredProcedure

        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutsatiri)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Maas")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AnaMenü.Show()
        Me.Hide()

    End Sub
    Sub Temizle()

        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button2_Ara_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Personel As New Kisi
        Dim TC_No As String
        TC_No = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TC_No = TextBox3.Text
        Personel.PersonelAra(TC_No)
    End Sub

    Private Sub Button1_Listele_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DatagridYenile()
    End Sub

    Private Sub Button3_Degistir_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim TC_No As String
        Dim Maasi As Decimal
        TC_No = TextBox3.Text
        Maasi = TextBox2.Text
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komutsatiri As SqlCommand = New SqlCommand("MaasGuncelle", con)
        komutsatiri.CommandType = CommandType.StoredProcedure
        komutsatiri.Parameters.AddWithValue("@Maasi", Maasi)
        komutsatiri.Parameters.AddWithValue("@TC_No", TC_No)
        komutsatiri.ExecuteNonQuery()
        con.Close()
        DatagridYenile()
    End Sub

    Private Sub Button5_Kaydet_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim TC_No, Maasi, YatirilanTarih As String
        Dim Ucret As New Kisi
        TC_No = TextBox3.Text
        Maasi = TextBox4.Text
        YatirilanTarih = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Ucret.MaasEkle(TC_No, Maasi, YatirilanTarih)
        DatagridYenile()
    End Sub



    Private Sub MaaşTakip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        GirişEkranı.Show()
        Me.Hide()

    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        AnaMenü.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Temizle_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Temizle()
    End Sub
End Class