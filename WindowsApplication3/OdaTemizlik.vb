Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class OdaTemizlik
    Dim con As New SqlConnection
    Dim komut As SqlCommand = New SqlCommand()
    Dim dr As SqlDataReader



    Private Sub OdaTemizlik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")

        komut.CommandText = "SELECT OdaNo FROM  Oda"
        komut.Connection = con
        komut.CommandType = CommandType.Text
        con.Open()
        dr = komut.ExecuteReader()
        While (dr.Read())

            ListBox1.Items.Add(dr("OdaNo"))
        End While
        con.Close()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim Müsteri, Temizlik As String
        Müsteri = Label2.Text
        Temizlik = Label3.Text
        TextBox1.Text = ListBox1.SelectedItem
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")
        con.Open()
        komut.CommandText = "Select Durum From Doluluk"
        komut.Connection = con
        komut.CommandType = CommandType.Text
        dr = komut.ExecuteReader()
        While (dr.Read())

            If (dr(0).ToString() = Label4.Text) Then

                Label2.Text = dr(1).ToString()
                Label3.Text = dr(2).ToString()
                Label5.Text = dr(3).ToString()
            End If
        End While

        dr.Close()
        con.Close()

        If (Label2.Text = "Boş") Then

            RadioButton2.Checked = True

        Else

            RadioButton1.Checked = True
        End If

        If (Label3.Text = "Temiz") Then

            RadioButton3.Checked = True

        Else

            RadioButton4.Checked = True

        End If
        If (Label5.Text = "Kullanılabilir") Then

            RadioButton5.Checked = True

        Else

            RadioButton6.Checked = True
        End If

    End Sub

    Private Sub Button2_Kaydet_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Durum As Integer = 0
        con = New SqlConnection("Data Source= KÜBRA; database= OtelTakipSistemi; integrated security=true")

        If RadioButton1.Checked = True Then
            Durum = 1

        ElseIf RadioButton2.Checked = True Then
            Durum = 2
        End If
        komut.CommandText = "Update Doluluk set Durum where Durum=Durum "
        komut.Connection = con
        komut.CommandType = CommandType.Text
        con.Open()
        komut.ExecuteNonQuery()
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
End Class