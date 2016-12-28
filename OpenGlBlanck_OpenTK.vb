Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Audio.OpenAL
Imports System.Drawing

Public Class Viewer
    Inherits GameWindow

    Private rtri As Double = 0
    Private rquad As Double = 0

    Public Sub New(w As Integer, h As Integer)
        MyBase.New(w, h)
        Me.X = 100
        Me.Y = 100

        GL.ShadeModel(ShadingModel.Smooth)                               ' enable smooth shading
        GL.ClearColor(0.0F, 0.0F, 0.0F, 0.5F)                            ' black background
        GL.ClearDepth(1.0F)                                              ' depth buffer setup
        GL.Enable(EnableCap.DepthTest)                                   ' enables depth testing
        GL.DepthFunc(DepthFunction.Lequal)                               ' type Of depth test
        GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest)   ' nice perspective calculations
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        'GL.LoadIdentity()
        GL.MatrixMode(MatrixMode.Projection)

        GL.LoadMatrix(Matrix4.Perspective(45.0F, CDbl(Me.Width) / CDbl(Me.Height), 0.1F, 5000.0F))
        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
    End Sub

    Protected Overrides Sub OnUpdateFrame(e As FrameEventArgs)
        MyBase.OnUpdateFrame(e)

    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        GL.Viewport(ClientRectangle)
        GL.LoadMatrix(Matrix4.Perspective(45.0F, CDbl(Me.Width) / CDbl(Me.Height), 0.1F, 5000.0F))
        GL.MatrixMode(MatrixMode.Modelview)
    End Sub

    Protected Overrides Sub OnRenderFrame(e As FrameEventArgs)
        MyBase.OnRenderFrame(e)

        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.ClearColor(Color.Black)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
        GL.Translate(-1.5F, 0.0F, -6.0F)
        GL.Rotate(rtri, 0.0F, 1.0F, 0.0F)


        GL.Begin(PrimitiveType.Triangles)
        GL.Color3(1.0F, 0.0F, 0.0F)             ' Red
        GL.Vertex3(0.0F, 1.0F, 0.0F)            ' Top Of Triangle (Front)
        GL.Color3(0.0F, 1.0F, 0.0F)             ' green
        GL.Vertex3(-1.0F, -1.0F, 1.0F)      ' left Of Triangle (front)
        GL.Color3(0.0F, 0.0F, 1.0F)             ' blue
        GL.Vertex3(1.0F, -1.0F, 1.0F)           ' right Of triangle (front)

        GL.Color3(1.0F, 0.0F, 0.0F)             ' red
        GL.Vertex3(0.0F, 1.0F, 0.0F)            ' top Of triangle (right)
        GL.Color3(0.0F, 0.0F, 1.0F)             ' blue
        GL.Vertex3(1.0F, -1.0F, 1.0F)           ' left Of triangle (right)
        GL.Color3(0.0F, 1.0F, 0.0F)             ' green
        GL.Vertex3(1.0F, -1.0F, -1.0F)      ' right Of triangel (right)

        GL.Color3(1.0F, 0.0F, 0.0F)             ' red
        GL.Vertex3(0.0F, 1.0F, 0.0F)            ' top Of triangle (back)
        GL.Color3(0.0F, 1.0F, 0.0F)             ' green
        GL.Vertex3(1.0F, -1.0F, -1.0F)      ' left Of triangle (back)
        GL.Color3(0.0F, 0.0F, 1.0F)             ' blue
        GL.Vertex3(-1.0F, -1.0F, -1.0F)         ' right Of triangle (back)

        GL.Color3(1.0F, 0.0F, 0.0F)             ' red
        GL.Vertex3(0.0F, 1.0F, 0.0F)            ' top Of triangle (left)
        GL.Color3(0.0F, 0.0F, 1.0F)             ' blue
        GL.Vertex3(-1.0F, -1.0F, -1.0F)         ' left Of triangle (left)
        GL.Color3(0.0F, 1.0F, 0.0F)             ' green
        GL.Vertex3(-1.0F, -1.0F, 1.0F)      ' right Of triangle (left)
        GL.End()
        rtri += 0.17

        GL.LoadIdentity()                     ' reset the current modelview matrix
        GL.Translate(1.5F, 0.0F, -7.0F)      ' move 1.5 Units right And 7 into the screen
        GL.Rotate(rquad, 1.0F, 1.0F, 1.0F)       ' rotate the quad On the X,Y And Z-axis
        rquad -= 0.15F                          ' rotation angle

        GL.Begin(PrimitiveType.Quads)               ' start drawing a quad
        GL.Color3(0.0F, 1.0F, 0.0F)             ' green top
        GL.Vertex3(1.0F, 1.0F, -1.0F)           ' top right (top)
        GL.Vertex3(-1.0F, 1.0F, -1.0F)      ' top left (top)
        GL.Vertex3(-1.0F, 1.0F, 1.0F)           ' bottom left (top)
        GL.Vertex3(1.0F, 1.0F, 1.0F)            ' bottom right (top)

        GL.Color3(1.0F, 0.5F, 0.0F)             ' orange
        GL.Vertex3(1.0F, -1.0F, 1.0F)           ' top right (bottom)
        GL.Vertex3(-1.0F, -1.0F, 1.0F)      ' top left (bottom)
        GL.Vertex3(-1.0F, -1.0F, -1.0F)         ' bottom left (bottom)
        GL.Vertex3(1.0F, -1.0F, -1.0F)      ' bottom right (bottom)

        GL.Color3(1.0F, 0.0F, 0.0F)             ' red
        GL.Vertex3(1.0F, 1.0F, 1.0F)            ' top right (front)
        GL.Vertex3(-1.0F, 1.0F, 1.0F)           ' top left (front)
        GL.Vertex3(-1.0F, -1.0F, 1.0F)      ' bottom left (front)
        GL.Vertex3(1.0F, -1.0F, 1.0F)           ' bottom right (front)

        GL.Color3(1.0F, 1.0F, 0.0F)                 ' yellow
        GL.Vertex3(-1.0F, 1.0F, -1.0F)      ' top right (back)
        GL.Vertex3(1.0F, 1.0F, -1.0F)           ' top left (back)
        GL.Vertex3(1.0F, -1.0F, -1.0F)      ' bottom left (back)
        GL.Vertex3(-1.0F, -1.0F, -1.0F)         ' bottom right (back)

        GL.Color3(0.0F, 0.0F, 1.0F)             ' blue
        GL.Vertex3(-1.0F, 1.0F, 1.0F)           ' top right (left)
        GL.Vertex3(-1.0F, 1.0F, -1.0F)      ' top left (left)
        GL.Vertex3(-1.0F, -1.0F, -1.0F)         ' bottom left (left)
        GL.Vertex3(-1.0F, -1.0F, 1.0F)      ' bottom right (left)

        GL.Color3(1.0F, 0.0F, 1.0F)             ' violett
        GL.Vertex3(1.0F, 1.0F, -1.0F)           ' top right (right)
        GL.Vertex3(1.0F, 1.0F, 1.0F)            ' top left (right)
        GL.Vertex3(1.0F, -1.0F, 1.0F)       ' bottom left (right)
        GL.Vertex3(1.0F, -1.0F, -1.0F)      ' bottom right (right)
        GL.End()


        Me.SwapBuffers()
    End Sub
End Class
