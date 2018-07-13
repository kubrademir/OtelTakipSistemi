Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class GelirGiderEkranı
    Dim con As New SqlConnection
    Dim kmt As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        AnaMenü.Show()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub RadioButton4_Maas_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komut As String
        komut = "select TC_No,Maasi from Maas "
        Dim komutubagla As SqlCommand = New SqlCommand(komut, con)
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutubagla)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Maas")
        DataGridView1.DataSource = ds.Tables(0)
        Dim cmd As SqlCommand = New SqlCommand("Select  sum(Maasi) from Maas", con)
        TextBox2.Text = cmd.ExecuteScalar().ToString()
        con.Close()

    End Sub

    Private Sub RadioButton3_Urun_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komut As String
        komut = "select ToplamTutar from Urun "
        Dim komutubagla As SqlCommand = New SqlCommand(komut, con)
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutubagla)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Urun")
        DataGridView1.DataSource = ds.Tables(0)
        Dim cmd As SqlCommand = New SqlCommand("Select  sum(ToplamTutar) from Urun", con)
        TextBox4.Text = cmd.ExecuteScalar().ToString()

        con.Close()
    End Sub

    Private Sub RadioButton1_Oda_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim con As SqlConnection = New SqlConnection("Data Source=KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        Dim komut As String

        komut = "select OdaId ,Alinan from Doluluk "
        Dim komutubagla As SqlCommand = New SqlCommand(komut, con)
        Dim adptr As SqlDataAdapter = New SqlDataAdapter(komutubagla)
        Dim ds As DataSet = New DataSet
        adptr.Fill(ds, "Urun")
        DataGridView1.DataSource = ds.Tables(0)
        Dim cmd As SqlCommand = New SqlCommand("Select  sum(Alinan) from Doluluk", con)
        TextBox1.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        GirişEkranı.Show()
        Me.Hide()
    End Sub

    Private Sub GelirGiderEkranı_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Hesapla_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UrunTotal, MaasTotal, OdaTotal As Integer
        UrunTotal = Convert.ToInt32(TextBox4.Text)
        MaasTotal = Convert.ToInt32(TextBox2.Text)
        OdaTotal = Convert.ToInt32(TextBox1.Text)
        TextBox3.Text = UrunTotal + MaasTotal + OdaTotal
    End Sub
End Class