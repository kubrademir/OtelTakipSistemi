Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class AnaMenü
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Sub DatagridYenile()
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim tbl As DataTable = New DataTable()
        tbl.Clear()
        Dim adptr As SqlDataAdapter = New SqlDataAdapter("Select TC_No,GelisTarihi,AyrilisTarihi,OdaId from Doluluk ", con)
        adptr.Fill(tbl)
        con.Close()
        DataGridView1.DataSource = tbl

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Personelİslemleri.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Odaİşlemleri.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Ürünler.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        GelirGiderEkranı.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        MaaşTakip.Show()
        Me.Hide()

    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Rezervasyon.Show()
        Me.Hide()
    End Sub

    Private Sub AnaMenü_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        OdaTemizlik.Show()
        Me.Hide()

    End Sub

    Private Sub Button22_Rezervasyon_Click(sender As Object, e As EventArgs) Handles Button22.Click
        DatagridYenile()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        End
    End Sub

    Private Sub ButtonOda_Click(sender As Object, e As EventArgs) Handles ButtonOda.Click
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        Dim sorgu As String = "Select OdaNo,Durum from Oda,Doluluk "
        Dim sda As SqlDataAdapter = New SqlDataAdapter(sorgu, con)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        DataGridView3.DataSource = dt
        DataGridView3.Refresh()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Personelİslemleri.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        GirişEkranı.Show()
        Me.Hide()

    End Sub
End Class