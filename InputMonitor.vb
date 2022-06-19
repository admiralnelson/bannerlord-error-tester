Imports TaleWorlds.InputSystem
Imports TaleWorlds.Core

Public Class InputMonitor

    Shared keyValue As Dictionary(Of InputKey, List(Of Action))
    Public Shared Sub Tick()
        For Each key In keyValue
            If Input.IsReleased(key.Key) Then
                For Each act In key.Value
                    act()
                Next
            End If
        Next
    End Sub

    Public Shared Sub RegisterInputKey(key As InputKey, callback As Action)
        If keyValue Is Nothing Then keyValue = New Dictionary(Of InputKey, List(Of Action))
        If keyValue.ContainsKey(key) Then
            keyValue(key).Add(callback)
            Exit Sub
        End If
        keyValue.Add(key, New List(Of Action))
        keyValue(key).Add(callback)
    End Sub

End Class
