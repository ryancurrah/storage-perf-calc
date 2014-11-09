Module StoragePerfCalc
    Dim objHardDrive As HardDrive = New HardDrive

    Sub Main()

        Dim Width As Integer
        Dim Height As Integer

        Console.Title = "Storage Performance Calculator"
        Width = 95
        Height = 30
        Console.SetWindowSize(Width, Height)

        Console.Clear()
        Console.BackgroundColor = ConsoleColor.Yellow
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("-------------------------------------------------------------")
        Console.WriteLine("S T O R A G E    P E R F O R M A N C E    C A L C U L A T O R")
        Console.WriteLine("-------------------------------------------------------------")
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine()
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine("Please Select an Option:")
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()

        MainMenu()
        MainMenuInput()
    End Sub

    ' MainMenu UI
    Public Sub MainMenu()
        Console.WriteLine("1) Set/Clear values")
        Console.WriteLine("2) Calculate values")
        Console.WriteLine("3) Help")
        Console.WriteLine("4) Quit")
    End Sub

    ' MainMenu Inputs
    Public Sub MainMenuInput()
        Dim input
        Dim x = False
        input = ReadLineNumberOnly()
        Do While x = False
            Select Case input
                Case 1
                    ' 1) Set values
                    SetValuesMenu()
                    'x = True
                Case 2
                    ' 2) Calculate values
                    CalcValuesMenu()
                    'x = True
                Case 3
                    ' 3) Help
                    HelpMenu()
                    'x = True
                Case 4
                    ' 4) Quit
                    Quit()
                    x = True
                Case Else
                    Console.WriteLine("Please select a number from 1 - 4.")
                    input = ReadLineNumberOnly()
            End Select
        Loop
    End Sub
    ' CalcValues UI
    Public Sub CalcValuesMenu()
        Console.Clear()
        Console.WriteLine()
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine("Please Select a Value to Calculcate:")
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine(" 0) Return to Main Menu")
        Console.WriteLine()
        Console.WriteLine(" 1) " & HardDrive.L_name & "               2) " & HardDrive.X_name)
        Console.WriteLine(" 3) " & HardDrive.Ts_name & "                            4) " & HardDrive.IOPS_name)
        Console.WriteLine(" 5) " & HardDrive.Ra_name & "                            6) " & HardDrive.U_name)
        Console.WriteLine(" 7) " & HardDrive.R_name & "                            8) " & HardDrive.Dc_name)
        Console.WriteLine(" 9) " & HardDrive.Di_name & "                              10) " & HardDrive.Dr_name)
        CalcValuesMenuInput()
    End Sub

    Public Sub CalcValuesMenuInput()
        Dim input
        Dim x = False
        input = ReadLineNumberOnly()
        Do While x = False
            Select Case input
                Case 0
                    Main()
                Case 1
                    Console.Clear()
                    objHardDrive.AvgRotationalLatency()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.L_name & " Formula: " & HardDrive.L_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.L_name & " Value: " & objHardDrive.L_value)
                    Console.ReadLine()
                    x = True
                Case 2
                    Console.Clear()
                    objHardDrive.InternalTransferTime()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.X_name & " Formula: " & HardDrive.X_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.X_name & " Value: " & objHardDrive.X_value)
                    Console.ReadLine()
                    x = True
                Case 3
                    Console.Clear()
                    objHardDrive.ServiceTime()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.Ts_name & " Formula: " & HardDrive.Ts_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.Ts_name & " Value: " & objHardDrive.Ts_value)
                    Console.ReadLine()
                    x = True
                Case 4
                    Console.Clear()
                    objHardDrive.IOPS()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.IOPS_name & " Formula: " & HardDrive.IOPS_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.IOPS_name & " Value: " & objHardDrive.IOPS_value)
                    Console.ReadLine()
                    x = True
                Case 5
                    Console.Clear()
                    objHardDrive.ArrivalTime()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.Ra_name & " Formula: " & HardDrive.Ra_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.Ra_name & " Value: " & objHardDrive.Ra_value)
                    Console.ReadLine()
                    x = True
                Case 6
                    Console.Clear()
                    objHardDrive.Utilization()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.U_name & " Formula: " & HardDrive.U_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.U_name & " Value: " & objHardDrive.U_value)
                    Console.ReadLine()
                    x = True
                Case 7
                    Console.Clear()
                    objHardDrive.ResponseTime()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.R_name & " Formula: " & HardDrive.R_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.R_name & " Value: " & objHardDrive.R_value)
                    Console.ReadLine()
                    x = True
                Case 8
                    Console.Clear()
                    objHardDrive.DiskCapacity()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.Dc_name & " Formula: " & HardDrive.Dc_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.Dc_name & " Value: " & objHardDrive.Dc_value)
                    Console.ReadLine()
                    x = True
                Case 9
                    Console.Clear()
                    objHardDrive.DiskIOPS()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.Di_name & " Formula: " & HardDrive.Di_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.Di_name & " Value: " & objHardDrive.Di_value)
                    Console.ReadLine()
                    x = True
                Case 10
                    Console.Clear()
                    objHardDrive.DisksRequired()
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.WriteLine(HardDrive.Dr_name & " Formula: " & HardDrive.Dr_formula)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(HardDrive.Dr_name & " Value: " & objHardDrive.Dr_value)
                    Console.ReadLine()
                    x = True
                Case Else
                    Console.WriteLine("Please select a number from 1 - 10.")
                    input = ReadLineNumberOnly()
            End Select
        Loop
    End Sub

    ' SetValuesMenu UI
    Public Sub SetValuesMenu()
        Console.Clear()
        Console.WriteLine()
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine("Please Select a Value to Set:")
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine(" 0) Return to Main Menu")
        Console.WriteLine()
        Console.WriteLine(" 1) " & HardDrive.RPM_name & "                        2) " & HardDrive.T_name)
        Console.WriteLine(" 3) " & HardDrive.BS_name & "                                  4) " & HardDrive.DTR_name)
        Console.WriteLine(" 5) " & HardDrive.L_name & "              6) " & HardDrive.X_name)
        Console.WriteLine(" 7) " & HardDrive.Ts_name & "                           8) " & HardDrive.IOPS_name)
        Console.WriteLine(" 9) " & HardDrive.A_name & "                           10) " & HardDrive.Ra_name)
        Console.WriteLine("11) " & HardDrive.U_name & "                            12) " & HardDrive.R_name)
        Console.WriteLine("13) " & HardDrive.As_name & "     14) " & HardDrive.Ds_name)
        Console.WriteLine("15) " & HardDrive.Dc_name & "                         16) " & HardDrive.Ai_name)
        Console.WriteLine("17) " & HardDrive.Dai_name & "                     18) " & HardDrive.Du_name)
        Console.WriteLine("19) " & HardDrive.Di_name & "                             20) " & HardDrive.Dr_name)
        SetValuesMenuInput()
    End Sub

    ' SetValuesMenu Inputs
    Public Sub SetValuesMenuInput()
        Dim input
        Dim x = False
        Dim currentValueSaying = "The Current Value is: "
        input = ReadLineNumberOnly()
        Do While x = False
            Select Case input
                Case 0
                    Main()
                Case 1
                    ' RPM Value
                    Console.Clear()
                    If objHardDrive.RPM_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.RPM_value)
                    objHardDrive.RPM_set = False
                    objHardDrive.SetValue(objHardDrive.RPM_set, objHardDrive.RPM_value, HardDrive.RPM_name, HardDrive.RPM_unit)
                    x = True
                Case 2
                    ' Seek Time (T)
                    Console.Clear()
                    If objHardDrive.T_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.T_value)
                    objHardDrive.T_set = False
                    objHardDrive.SetValue(objHardDrive.T_set, objHardDrive.T_value, HardDrive.T_name, HardDrive.T_unit)
                    x = True
                Case 3
                    ' Block Size
                    Console.Clear()
                    If objHardDrive.BS_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.BS_value)
                    objHardDrive.BS_set = False
                    objHardDrive.SetValue(objHardDrive.BS_set, objHardDrive.BS_value, HardDrive.BS_name, HardDrive.BS_unit)
                    x = True
                Case 4
                    ' Data Transfer Rate
                    Console.Clear()
                    If objHardDrive.DTR_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.DTR_value)
                    objHardDrive.DTR_set = False
                    objHardDrive.SetValue(objHardDrive.DTR_set, objHardDrive.DTR_value, HardDrive.DTR_name, HardDrive.DTR_unit)
                    x = True
                Case 5
                    ' Average Rotational Latency (L)
                    Console.Clear()
                    If objHardDrive.L_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.L_value)
                    objHardDrive.L_set = False
                    objHardDrive.SetValue(objHardDrive.L_set, objHardDrive.L_value, HardDrive.L_name, HardDrive.L_unit)
                    x = True
                Case 6
                    ' Internal Transfer Time (X)
                    Console.Clear()
                    If objHardDrive.X_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.X_value)
                    objHardDrive.X_set = False
                    objHardDrive.SetValue(objHardDrive.X_set, objHardDrive.X_value, HardDrive.X_name, HardDrive.X_unit)
                    x = True
                Case 7
                    ' Service Time (Ts)
                    Console.Clear()
                    If objHardDrive.Ts_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Ts_value)
                    objHardDrive.Ts_set = False
                    objHardDrive.SetValue(objHardDrive.Ts_set, objHardDrive.Ts_value, HardDrive.Ts_name, HardDrive.Ts_unit)
                    x = True
                Case 8
                    ' Input/Output Operations Per Second 
                    Console.Clear()
                    If objHardDrive.IOPS_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.IOPS_value)
                    objHardDrive.IOPS_set = False
                    objHardDrive.SetValue(objHardDrive.IOPS_set, objHardDrive.IOPS_value, HardDrive.IOPS_name, HardDrive.IOPS_unit)
                    x = True
                Case 9
                    ' Arrival Rate (A)
                    Console.Clear()
                    If objHardDrive.A_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.A_value)
                    objHardDrive.A_set = False
                    objHardDrive.SetValue(objHardDrive.A_set, objHardDrive.A_value, HardDrive.A_name, HardDrive.A_unit)
                    x = True
                Case 10
                    ' Arrival Time (Ra)
                    Console.Clear()
                    If objHardDrive.Ra_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Ra_value)
                    objHardDrive.Ra_set = False
                    objHardDrive.SetValue(objHardDrive.Ra_set, objHardDrive.Ra_value, HardDrive.Ra_name, HardDrive.Ra_unit)
                    x = True
                Case 11
                    ' Utilization (U)
                    Console.Clear()
                    If objHardDrive.U_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.U_value)
                    objHardDrive.U_set = False
                    objHardDrive.SetValue(objHardDrive.U_set, objHardDrive.U_value, HardDrive.U_name, HardDrive.U_unit)
                    x = True
                Case 12
                    ' Response time (R)
                    Console.Clear()
                    If objHardDrive.R_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.R_value)
                    objHardDrive.R_set = False
                    objHardDrive.SetValue(objHardDrive.R_set, objHardDrive.R_value, HardDrive.R_name, HardDrive.R_unit)
                    x = True
                Case 13
                    ' Application Disk Size Requirement (As)
                    Console.Clear()
                    If objHardDrive.As_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.As_value)
                    objHardDrive.As_set = False
                    objHardDrive.SetValue(objHardDrive.As_set, objHardDrive.As_value, HardDrive.As_name, HardDrive.As_unit)
                    x = True
                Case 14
                    ' Actual Disk Size (Ds)
                    Console.Clear()
                    If objHardDrive.Ds_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Ds_value)
                    objHardDrive.Ds_set = False
                    objHardDrive.SetValue(objHardDrive.Ds_set, objHardDrive.Ds_value, HardDrive.Ds_name, HardDrive.Ds_unit)
                    x = True
                Case 15
                    ' Disk Capacity (Dc)
                    Console.Clear()
                    If objHardDrive.Dc_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Dc_value)
                    objHardDrive.Dc_set = False
                    objHardDrive.SetValue(objHardDrive.Dc_set, objHardDrive.Dc_value, HardDrive.Dc_name, HardDrive.Dc_unit)
                    x = True
                Case 16
                    ' Application IOPS Requirement (Ai)
                    Console.Clear()
                    If objHardDrive.Ai_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Ai_value)
                    objHardDrive.Ai_set = False
                    objHardDrive.SetValue(objHardDrive.Ai_set, objHardDrive.Ai_value, HardDrive.Ai_name, HardDrive.Ai_unit)
                    x = True
                Case 17
                    ' Actual Disk IOPS (Dai)
                    Console.Clear()
                    If objHardDrive.Dai_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Dai_value)
                    objHardDrive.Dai_set = False
                    objHardDrive.SetValue(objHardDrive.Dai_set, objHardDrive.Dai_value, HardDrive.Dai_name, HardDrive.Dai_unit)
                    x = True
                Case 18
                    ' Maximum Disk Utilization (Du)
                    Console.Clear()
                    If objHardDrive.Du_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Du_value)
                    objHardDrive.Du_set = False
                    objHardDrive.SetValue(objHardDrive.Du_set, objHardDrive.Du_value, HardDrive.Du_name, HardDrive.Du_unit)
                    x = True
                Case 19
                    ' Disk IOPS (Di)
                    Console.Clear()
                    If objHardDrive.Di_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Di_value)
                    objHardDrive.Di_set = False
                    objHardDrive.SetValue(objHardDrive.Di_set, objHardDrive.Di_value, HardDrive.Di_name, HardDrive.Di_unit)
                    x = True
                Case 20
                    ' Disks Required (Dr)
                    Console.Clear()
                    If objHardDrive.Dr_set = True Then Console.WriteLine(currentValueSaying & objHardDrive.Dr_value)
                    objHardDrive.Dr_set = False
                    objHardDrive.SetValue(objHardDrive.Dr_set, objHardDrive.Dr_value, HardDrive.Dr_name, HardDrive.Dr_unit)
                    x = True
                Case Else
                    Console.WriteLine("Please select a number from 1 - 20.")
                    input = ReadLineNumberOnly()
            End Select
        Loop
    End Sub

    ' Ask user for input
    ' If setting a an HD value use the SetValue method in the HardDrive class
    Public Function GetInput(name, unit, Optional forumla = "")
        Dim input
        Console.WriteLine()
        Console.WriteLine("What is the " & name & " in " & unit & "?")
        Console.WriteLine("Enter 'c' if you want to clear the value")
        If forumla <> "" Then Console.WriteLine("Formula: " & forumla)
        input = ReadLineNumberOnly()
        Return input
    End Function

    ' SetValuesMenu UI
    Public Sub HelpMenu()
        Console.Clear()
        Console.WriteLine()
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine("Please Select a Value for help: ")
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine(" 0) Return to Main Menu")
        Console.WriteLine()
        Console.WriteLine(" 1) " & HardDrive.RPM_name & "                        2) " & HardDrive.T_name)
        Console.WriteLine(" 3) " & HardDrive.BS_name & "                                  4) " & HardDrive.DTR_name)
        Console.WriteLine(" 5) " & HardDrive.L_name & "              6) " & HardDrive.X_name)
        Console.WriteLine(" 7) " & HardDrive.Ts_name & "                           8) " & HardDrive.IOPS_name)
        Console.WriteLine(" 9) " & HardDrive.A_name & "                           10) " & HardDrive.Ra_name)
        Console.WriteLine("11) " & HardDrive.U_name & "                            12) " & HardDrive.R_name)
        Console.WriteLine("13) " & HardDrive.As_name & "     14) " & HardDrive.Ds_name)
        Console.WriteLine("15) " & HardDrive.Dc_name & "                         16) " & HardDrive.Ai_name)
        Console.WriteLine("17) " & HardDrive.Dai_name & "                     18) " & HardDrive.Du_name)
        Console.WriteLine("19) " & HardDrive.Di_name & "                             20) " & HardDrive.Dr_name)
        HelpMenuInput()
    End Sub

    ' HelpMenu Inputs
    Public Sub HelpMenuInput()
        Dim input
        Dim x = False
        Dim helpSaying = "Help Information for: "
        input = ReadLineNumberOnly()
        Do While x = False
            Select Case input
                Case 0
                    Main()
                Case 1
                    ' RPM Value
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.RPM_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.RPM_help)
                    Console.ReadLine()
                    x = True
                Case 2
                    ' Seek Time (T)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.T_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.T_help)
                    Console.ReadLine()
                    x = True
                Case 3
                    ' Block Size
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.BS_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.BS_help)
                    Console.ReadLine()
                    x = True
                Case 4
                    ' Data Transfer Rate
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.DTR_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.DTR_help)
                    Console.ReadLine()
                    x = True
                Case 5
                    ' Average Rotational Latency (L)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.L_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.L_help)
                    Console.ReadLine()
                    x = True
                Case 6
                    ' Internal Transfer Time (X)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.X_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.X_help)
                    Console.ReadLine()
                    x = True
                Case 7
                    ' Service Time (Ts)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Ts_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Ts_help)
                    Console.ReadLine()
                    x = True
                Case 8
                    ' Input/Output Operations Per Second 
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.IOPS_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.IOPS_help)
                    Console.ReadLine()
                    x = True
                Case 9
                    ' Arrival Rate (A)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.A_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.A_help)
                    Console.ReadLine()
                    x = True
                Case 10
                    ' Arrival Time (Ra)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Ra_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Ra_help)
                    Console.ReadLine()
                    x = True
                Case 11
                    ' Utilization (U)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.U_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.U_help)
                    Console.ReadLine()
                    x = True
                Case 12
                    ' Response time (R)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.R_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.R_help)
                    Console.ReadLine()
                    x = True
                Case 13
                    ' Application Disk Size Requirement (As)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.As_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.As_help)
                    Console.ReadLine()
                    x = True
                Case 14
                    ' Actual Disk Size (Ds)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Ds_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Ds_help)
                    Console.ReadLine()
                    x = True
                Case 15
                    ' Disk Capacity (Dc)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Dc_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Dc_help)
                    Console.ReadLine()
                    x = True
                Case 16
                    ' Application IOPS Requirement (Ai)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Ai_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Ai_help)
                    Console.ReadLine()
                    x = True
                Case 17
                    ' Actual Disk IOPS (Dai)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Dai_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Dai_help)
                    Console.ReadLine()
                    x = True
                Case 18
                    ' Maximum Disk Utilization (Du)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Du_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Du_help)
                    Console.ReadLine()
                    x = True
                Case 19
                    ' Disk IOPS (Di)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Di_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Di_help)
                    Console.ReadLine()
                    x = True
                Case 20
                    ' Disks Required (Dr)
                    Console.Clear()
                    Console.WriteLine()
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.WriteLine(helpSaying & HardDrive.Dr_name)
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine()
                    Console.WriteLine(HardDrive.Dr_help)
                    Console.ReadLine()
                    x = True
                Case Else
                    Console.WriteLine("Please select a number from 1 - 20.")
                    input = ReadLineNumberOnly()
            End Select
        Loop
    End Sub

    ' Error checking to make sure entered input is a numeric only
    Public Function ReadLineNumberOnly()
        Dim input
        Dim x = False
        input = Console.ReadLine
        Do While x = False
            If IsNumeric(input) Or input = "c" Or input = "C" Then
                x = True
            Else
                Console.WriteLine("Please enter a numeric input...")
                input = Console.ReadLine
            End If
        Loop
        Return input
    End Function

    Public Sub Quit()
        Environment.Exit(0)
    End Sub
End Module
