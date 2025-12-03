Imports System.Drawing.Drawing2D

Public Class RoundedButton 
    Inherits Button

    Private Function GetRoundPath(ByVal Rect As RectangleF, ByVal radius As Integer) As GraphicsPath
        Dim r2 As Single = radius / 2.0F
        Dim GraphPath As GraphicsPath = New GraphicsPath()
        GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90)
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y)
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90)
        GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2)
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90)
        GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height)
        GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90)
        GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2)
        GraphPath.CloseFigure()
        Return GraphPath
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim Rect As RectangleF = New RectangleF(0, 0, Me.Width, Me.Height)

        Using GraphPath As GraphicsPath = GetRoundPath(Rect, 12.5)
            Me.Region = New Region(GraphPath)

            Using pen As Pen = New Pen(Color.FromArgb(0, 104, 245), 1.75F)
                pen.Alignment = PenAlignment.Inset
                e.Graphics.DrawPath(pen, GraphPath)
            End Using
        End Using
    End Sub
End Class