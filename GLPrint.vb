Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports System
Imports System.Runtime.InteropServices

Public Class GLPrint
    Public Class tp
        Public xul, xur, xll, xlr As Double
        Public yul, yur, yll, ylr As Double

        Sub New(xa, ya, xb, yb, xc, yc, xd, yd)
            xul = xa
            yul = ya

            xur = xb
            yur = yb

            xll = xc
            yll = yc

            xlr = xd
            ylr = yd
        End Sub
    End Class
    Dim X, Y, Z, size, gblRings, gblSectors As Double
    Dim rotx, roty, rotz As Double
    Dim vl, nl, tl As List(Of Double)
    Dim il As List(Of Integer)
    Dim txtcordList As List(Of tp)
    Dim vert() As Double
    Dim normal(3) As Double
    Dim indices(1) As Integer
    Dim texcoords(8) As Double

    Public Sub New(Optional size As Integer = 1)
        Dim modVal, intDivVal As Double
        Me.size = size / 2
        txtcordList = New List(Of tp)()

        ' generate pre-made texture corordinate map
        For i As Integer = 0 To (1023)
            If (i Mod 16) = 0 Then
                modVal = 0
            Else
                modVal = 1.0 / (i Mod 16)
            End If

            If CInt(i / 16) = 0 Then
                intDivVal = 0
            Else
                intDivVal = 1.0 / CInt(i / 16)
            End If

            txtcordList.Add(New tp(
                            modVal,
                            (1 - intDivVal),
                            (modVal + 0.0625),
                            (1 - intDivVal),
                            (modVal + 0.0625),
                            (1 - (intDivVal + 0.0625)),
                            modVal,
                            (1 - (intDivVal + 0.0625))))
        Next
    End Sub

    Sub print(lx As Double, ly As Double, data As String)
        GL.Disable(EnableCap.Lighting)
        GL.PushMatrix()

        For i As Integer = 0 To (data.Length - 1)
            rectangle(i, data(i))
            'il.add(i + 1)
        Next

        GL.Translate(lx, ly, 0)
        GL.Rotate(rotx, 1, 0, 0)
        GL.Rotate(roty, 0, 1, 0)
        GL.Rotate(rotz, 0, 0, 1)

        GL.PopMatrix()
        GL.Enable(EnableCap.Lighting)
    End Sub

    Sub rectangle(charIndex As Integer, str As String)
        'vl.Add(size * charIndex)
        'vl.Add(0)
        GL.Vertex3((size * charIndex), 0.0F, 0.0F)
        GL.TexCoord2(texcoords(0), texcoords(1))

        'vl.Add(size + (size * charIndex))
        'vl.Add(0)
        GL.Vertex3(size + (size * charIndex), 0.0F, 0.0F)
        GL.TexCoord2(texcoords(2), texcoords(3))

        'vl.Add(size + (size * charIndex))
        'vl.Add((size * 2))
        GL.Vertex3(size + (size * charIndex), (size * 2), 0.0F)
        GL.TexCoord2(texcoords(4), texcoords(5))

        'vl.Add((size * charIndex))
        'vl.Add((size * 2))
        GL.Vertex3((size * charIndex), (size * 2), 0.0F)
        GL.TexCoord2(texcoords(6), texcoords(7))
    End Sub

End Class
