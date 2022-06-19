Imports TaleWorlds
Imports TaleWorlds.InputSystem

Namespace Global.ErrorTester
    Public Class SubModuleEntryPoint
        Inherits MountAndBlade.MBSubModuleBase

        Protected Overrides Sub OnSubModuleLoad()
            MyBase.OnSubModuleLoad()
            InputMonitor.RegisterInputKey(InputKey.Home, Sub()
                                                             Console.WriteLine("test")
                                                         End Sub)
            InputMonitor.RegisterInputKey(InputKey.Insert, Sub()
                                                               Throw New Exception("exception test!")
                                                           End Sub)
        End Sub

        Protected Overrides Sub OnApplicationTick(dt As Single)
            MyBase.OnApplicationTick(dt)
            InputMonitor.Tick()
        End Sub
    End Class
End Namespace
