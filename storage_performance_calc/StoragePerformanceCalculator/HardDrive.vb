Public Class HardDrive

    ' Different unit types used
    Private Const unitType1 = "ms"
    Private Const unitType2 = "MB/s"
    Private Const unitType3 = "KB"
    Private Const unitType4 = "RPM"
    Private Const unitType5 = "IOPS"
    Private Const unitType6 = "%"
    Private Const unitType7 = "GB"
    Private Const unitType8 = "Disk(s)"

    ' Rotations Per Minute
    ' No formula, value given by manufacturer
    Private RPM_priv_value = 0
    Public RPM_set = False
    Public Const RPM_name = "Rotations Per Minute"  
    Public Const RPM_unit = unitType4
    Public Const RPM_help = "The rotational speed of the Hard Drive disks." & vbCrLf & "This value is provided by the manufacturer." & vbCrLf & "This value is used in the calculation of " & L_name & "."

    ' Seek Time (T)
    ' No formula, value given by manufacturer
    Private T_priv_value = 0
    Public T_set = False
    Public Const T_name = "Seek Time (T)"
    Public Const T_unit = unitType1
    Public Const T_help = "How much time it takes for the R/W head to move between tracks on the disk." & vbCrLf & "This value is provided by the manufacturer." & vbCrLf & "This value is used in the calculation of " & Ts_name & "."

    ' Block Size
    ' No formula, value given/set by user
    Private BS_priv_value = 0
    Public BS_set = False
    Public Const BS_name = "Block Size"
    Public Const BS_unit = unitType3
    Public Const BS_help = "The basic unit of contiguous data storage and retrieval." & vbCrLf & "This value is provided by the user." & vbCrLf & "This value is used in the calculation of " & X_name & "."

    ' Data Transfer Rate (MB/s)
    ' No formula, value given by manufacturer
    Private DTR_priv_value = 0
    Public DTR_set = False
    Public Const DTR_name = "Internal Data Transfer Rate"
    Public Const DTR_unit = unitType2
    Public Const DTR_help = "The rate at which data travels from buffer to disk." & vbCrLf & "This value is provided by the manufacturer." & vbCrLf & "This value is used in the calculation of " & X_name & "."

    ' Average Rotational Latency (L)
    Private L_priv_value = 0.0
    Public L_set = False
    Public Const L_name = "Average Rotational Latency (L)"
    Public Const L_formula = "(0.5 / RPM) * 60 seconds * 1000 Seconds"
    Public Const L_unit = unitType1
    Public Const L_help = "How long it takes for the drive platter to position itself under the R/W head" & vbCrLf & "This value is the result of the formula " & L_formula & "." & vbCrLf & "This value is used in the calculation of " & Ts_name & "."

    ' Internal Data Transfer Time (X)
    Private X_priv_value = 0
    Public X_set = False
    Public Const X_name = "Internal Transfer Time (X)"
    Public Const X_formula = "Block Size / Internal Data Transfer Rate"
    Public Const X_unit = unitType1
    Public Const X_help = "The time it takes for data to move from the disk surface to the R/W head" & vbCrLf & "This value is the result of the formula " & X_formula & "." & vbCrLf & "This value is used in the calculation of " & Ts_name & "."

    ' Service Time (Ts)
    Private Ts_priv_value = 0
    Public Ts_set = False
    Public Const Ts_name = "Service Time (Ts)"
    Public Const Ts_formula = "Seek Time (T) + Average Rotational Latency (L) + Int Transfer Time (X)"
    Public Const Ts_unit = unitType1
    Public Const Ts_help = "How much time a 'controller' takes to service one I/O" & vbCrLf & "This value is the result of the formula " & Ts_formula & "." & vbCrLf & "This value is used in the calculation of " & IOPS_name & "."

    ' Input/Output Operations Per Second 
    Private IOPS_priv_value = 0
    Public IOPS_set = False
    Public Const IOPS_name = "Input/Output Operations Per Second (IOPS)"
    Public Const IOPS_formula = "1 / Service Time (Ts) * 1000 Seconds"
    Public Const IOPS_unit = unitType5
    Public Const IOPS_help = "Number of Reads / Writes performed in a second" & vbCrLf & "This value is the result of the formula " & IOPS_formula & "."

    ' Arrival Rate (A)
    ' Used in Utilization calculation
    Private A_priv_value = 0
    Public A_set = False
    Public Const A_name = "Arrival Rate (A)"
    Public Const A_unit = unitType5
    Public Const A_help = "The ammount of IOPS being used." & vbCrLf & "This value is usually given by the application proivder." & vbCrLf & "This value is used in the calculation of " & Ra_formula & "."

    ' Arrival Time (Ra)
    ' Used in Utilization calculation
    Private Ra_priv_value = 0
    Public Ra_set = False
    Public Const Ra_name = "Arrival Time (Ra)"
    Public Const Ra_formula = "1 / Arrival Rate (A) * 1000"
    Public Const Ra_unit = unitType1
    Public Const Ra_help = "The ammount of time it takes to serve IOPS." & vbCrLf & "This value is the result of the formula " & Ra_formula & "." & vbCrLf & "This value is used in the calculation of " & U_name

    ' Utilization (U)
    Private U_priv_value = 0
    Public U_set = False
    Public Const U_name = "Utilization (U)"
    Public Const U_formula = "Service Time (Ts) / Arrival Time (Ra) * 100"
    Public Const U_unit = unitType6
    Public Const U_help = "How much capacity is being used." & vbCrLf & "This value is the result of the formula " & U_formula & "." & vbCrLf & "This value is used in the calculation of " & R_name

    ' Response time (R)
    Private R_priv_value = 0
    Public R_set = False
    Public Const R_name = "Response Time (R)"
    Public Const R_formula = "Service Time (Ts) / (1 – Utilization (U))"
    Public Const R_unit = unitType1
    Public Const R_help = "The total time for an I/O from arrival to departure of the system." & vbCrLf & "This value is the result of the formula " & R_formula & "."

    ' Application Disk Size Requirement (As)
    ' Given by application vendor
    Private As_priv_value = 0
    Public As_set = False
    Public Const As_name = "Application Disk Size Requirement (As)"
    Public Const As_unit = unitType7
    Public Const As_help = "The hard drive size requirement of the application." & vbCrLf & "This value is usually given by the application proivder." & vbCrLf & "This value is used in the calculation of " & Dc_name & "."

    ' Actual Disk Size (Ds)
    ' The size of the hard drive that will be used
    Private Ds_priv_value = 0
    Public Ds_set = False
    Public Const Ds_name = "Actual Disk Size (Ds)"
    Public Const Ds_unit = unitType7
    Public Const Ds_help = "The actual hard drive size." & vbCrLf & "This value is given by the user." & vbCrLf & "This value is used in the calculation of " & Dc_name & "."

    ' Disk Capacity (Dc)
    Private Dc_priv_value = 0
    Public Dc_set = False
    Public Const Dc_name = "Disk Capacity (Dc)"
    Public Const Dc_formula = "Application Disk Size Requirement (As) / Actual Disk Size (Ds)"
    Public Const Dc_unit = unitType7
    Public Const Dc_help = "The ammount of hard drives needed to satisfy the applications size requirements." & vbCrLf & "This value is the result of the formula " & Dc_formula & "." & vbCrLf & "This value is used in the calculation of " & Dr_name & "."

    ' Application IOPS Requirement (Ai)
    ' Given by application vendor
    Private Ai_priv_value = 0
    Public Ai_set = False
    Public Const Ai_name = "Application IOPS Requirement (Ai)"
    Public Const Ai_unit = unitType5
    Public Const Ai_help = "The maximum ammount of IOPS the application uses." & vbCrLf & "This value is usually given by the application proivder." & vbCrLf & "This value is used in the calculation of " & Di_name & "."

    ' Actual Disk IOPS (Dai)
    ' The maximum IOPS of the hard drive that will be used
    Private Dai_priv_value = 0
    Public Dai_set = False
    Public Const Dai_name = "Actual Disk IOPS (Dai)"
    Public Const Dai_unit = unitType5
    Public Const Dai_help = "The actual ammount of IOPS the Hard Drive is able to serve." & vbCrLf & "This value is given by the user." & vbCrLf & "This value is used in the calculation of " & Di_name & "."

    ' Maximum Disk Utilization (Du)
    ' The maximum ammount of utilization we want to use on the drive
    Private Du_priv_value = 0
    Public Du_set = False
    Public Const Du_name = "Maximum Disk Utilization (Du)"
    Public Const Du_unit = unitType6
    Public Const Du_help = "The maximum ammount of IOPS usage to use in %, usually no more than 70%." & vbCrLf & "This value is given by the user." & vbCrLf & "This value is used in the calculation of " & Di_name & "."

    ' Disk IOPS (Di)
    Private Di_priv_value = 0
    Public Di_set = False
    Public Const Di_name = "Disk IOPS (Di)"
    Public Const Di_formula = "Application IOPS Requirement (Ai) / (Actual Disk IOPS (Dai) * Maximum Disk Utilization (Du))"
    Public Const Di_unit = unitType5
    Public Const Di_help = "The ammount of hard drives needed to satisfy the applications IOPS requirements." & vbCrLf & "This value is the result of the formula " & Di_formula & "." & vbCrLf & "This value is used in the calculation of " & Dr_name & "."

    ' Disks Required (Dr)
    Private Dr_priv_value = 0
    Public Dr_set = False
    Public Const Dr_name = "Disks Required (Dr)"
    Public Const Dr_formula = "Max (Disk Capacity (Dc), Disk IOPS (Di))"
    Public Const Dr_unit = unitType8
    Public Const Dr_help = "The ammount of Hard Drives required to satisfy the applications requirements, take the max of the two values" & vbCrLf & "This value is the result of the formula " & Dr_formula & "."

    ' RPM Value
    Public Property RPM_value()
        Get
            Return RPM_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                RPM_priv_value = 0
                RPM_set = False
            Else
                RPM_priv_value = value
                RPM_set = True
            End If
        End Set
    End Property

    ' Seek Time (T)
    Public Property T_value()
        Get
            Return T_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                T_priv_value = 0
                T_set = False
            Else
                T_priv_value = value
                T_set = True
            End If
        End Set
    End Property

    ' Block Size
    Public Property BS_value()
        Get
            Return BS_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                BS_priv_value = 0
                BS_set = False
            Else
                BS_priv_value = value
                BS_set = True
            End If
        End Set
    End Property

    ' Data Transfer Rate
    Public Property DTR_value()
        Get
            Return DTR_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                DTR_priv_value = 0
                DTR_set = False
            Else
                DTR_priv_value = value
                DTR_set = True
            End If
        End Set
    End Property

    ' Average Rotational Latency (L)
    Public Property L_value()
        Get
            Return L_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                L_priv_value = 0
                L_set = False
            Else
                L_priv_value = value
                L_set = True
            End If
        End Set
    End Property

    ' Internal Transfer Time (X)
    Public Property X_value()
        Get
            Return X_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                X_priv_value = 0
                X_set = False
            Else
                X_priv_value = value
                X_set = True
            End If
        End Set
    End Property

    ' Service Time (Ts)
    Public Property Ts_value
        Get
            Return Ts_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Ts_priv_value = 0
                Ts_set = False
            Else
                Ts_priv_value = value
                Ts_set = True
            End If
        End Set
    End Property

    ' Input/Output Operations Per Second 
    Public Property IOPS_value
        Get
            Return IOPS_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                IOPS_priv_value = 0
                IOPS_set = False
            Else
                IOPS_priv_value = value
                IOPS_set = True
            End If
        End Set
    End Property

    ' Arrival Rate (A)
    Public Property A_value()
        Get
            Return A_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                A_priv_value = 0
                A_set = False
            Else
                A_priv_value = value
                A_set = True
            End If
        End Set
    End Property

    ' Arrival Time (Ra)
    Public Property Ra_value()
        Get
            Return Ra_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Ra_priv_value = 0
                Ra_set = False
            Else
                Ra_priv_value = value
                Ra_set = True
            End If
        End Set
    End Property

    ' Utilization (U)
    Public Property U_value
        Get
            Return U_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                U_priv_value = 0
                U_set = False
            Else
                U_priv_value = value
                U_set = True
            End If
        End Set
    End Property

    ' Response time (R)
    Public Property R_value
        Get
            Return R_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                R_priv_value = 0
                R_set = False
            Else
                R_priv_value = value
                R_set = True
            End If
        End Set
    End Property

    ' Application Disk Size Requirement (As)
    Public Property As_value()
        Get
            Return As_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                As_priv_value = 0
                As_set = False
            Else
                As_priv_value = value
                As_set = True
            End If
        End Set
    End Property

    ' Actual Disk Size (Ds)
    Public Property Ds_value()
        Get
            Return Ds_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Ds_priv_value = 0
                Ds_set = False
            Else
                Ds_priv_value = value
                Ds_set = True
            End If
        End Set
    End Property

    ' Disk Capacity (Dc)
    Public Property Dc_value()
        Get
            Return Dc_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Dc_priv_value = 0
                Dc_set = False
            Else
                Dc_priv_value = value
                Dc_set = True
            End If
        End Set
    End Property

    ' Application IOPS Requirement (Ai)
    Public Property Ai_value
        Get
            Return Ai_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Ai_priv_value = 0
                Ai_set = False
            Else
                Ai_priv_value = value
                Ai_set = True
            End If
        End Set
    End Property

    ' Actual Disk IOPS (Dai)
    Public Property Dai_value
        Get
            Return Dai_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Dai_priv_value = 0
                Dai_set = False
            Else
                Dai_priv_value = value
                Dai_set = True
            End If
        End Set
    End Property

    ' Maximum Disk Utilization (Du)
    Public Property Du_value
        Get
            Return Du_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Du_priv_value = 0
                Du_set = False
            Else
                ' Set percent value to decimal form
                value = value / 100
                Du_priv_value = value
                Du_set = True
            End If
        End Set
    End Property

    ' Disk IOPS (Di)
    Public Property Di_value
        Get
            Return Di_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Di_priv_value = 0
                Di_set = False
            Else
                Di_priv_value = value
                Di_set = True
            End If
        End Set
    End Property

    ' Disks Required (Dr)
    Public Property Dr_value
        Get
            Return Dr_priv_value
        End Get
        Set(ByVal value)
            If value.ToString = "C" Or value.ToString = "c" Then
                Dr_priv_value = 0
                Dr_set = False
            Else
                Dr_priv_value = value
                Dr_set = True
            End If
        End Set
    End Property

    ' SetValue helps reduce the ammount of code used to perform calculations.
    ' It will ask user to input values unless the _set variable is true which means that the...
    ' ...value has already been set dont ask user again and will output there preset value to the screen.
    Public Sub SetValue(ByRef setValue, ByRef valueVar, nameVar, unitVar)
        If setValue = False Then
            valueVar = GetInput(nameVar, unitVar)
        Else
            Console.WriteLine(nameVar & " value is " & valueVar & unitVar & ".")
        End If
    End Sub

    ' Perform calculations
    Public Sub AvgRotationalLatency()
        ' Calculate Average Rotational Latency (L) in milliseconds round to the nearest tenth decimal place
        ' (0.5 / RPM) * 60 second * 1000 Seconds

        SetValue(RPM_set, RPM_value, RPM_name, RPM_unit)
        L_value = Math.Round((0.5 / RPM_value) * 60 * 1000, 2)
    End Sub

    Public Sub InternalTransferTime()
        ' Calculate Internal Transfer Time (X) round to the nearest hundredth decimal place
        ' Block Size KB / Internal Data Transfer Rate MB/s

        ' Block Size
        SetValue(BS_set, BS_value, BS_name, BS_unit)
        ' Data Transfer Rate
        SetValue(DTR_set, DTR_value, DTR_name, DTR_unit)

        X_value = Math.Round(BS_value / DTR_value, 2)

    End Sub

    Public Sub ServiceTime()
        'Service Time (Ts) = Seek Time (T) + Average Rotational Latency (L) + Internal Transfer Time (X)
        ' Seek Time (T)
        SetValue(T_set, T_value, T_name, T_unit)

        ' Avg Rot Lat (L)
        Console.WriteLine()
        Console.WriteLine(L_name & ": " & L_formula)
        If L_set = False Then
            AvgRotationalLatency()
        Else
            Console.WriteLine(L_name & " value is " & L_value & L_unit & ".")
        End If

        ' Int Trans Time (x)
        Console.WriteLine()
        Console.WriteLine(X_name & ": " & X_formula)
        If X_set = False Then
            InternalTransferTime()
        Else
            Console.WriteLine(X_name & " value is " & X_value & X_unit & ".")
        End If

        Ts_value = Math.Round(T_value + L_value + X_value, 2)
    End Sub

    Public Sub IOPS()
        ' 1 / Service Time (Ts) * 1000 Seconds

        ' Service Time (Ts)
        Console.WriteLine()
        Console.WriteLine(Ts_name & ": " & Ts_formula)
        If Ts_set = False Then
            ServiceTime()
        Else
            Console.WriteLine(Ts_name & " value is " & Ts_value & Ts_unit & ".")
        End If

        IOPS_value = Math.Round(1 / Ts_value * 1000, 2)
    End Sub

    Public Sub ArrivalTime()
        ' 1 / Arrival Rate (A) * 1000

        ' Arrival Rate (A)
        SetValue(A_set, A_value, A_name, A_unit)

        Ra_value = Math.Round(1 / A_value * 1000, 2)
    End Sub

    Public Sub Utilization()
        ' Service Time (Ts) / Arrival Time (Ra) * 100

        ' Service Time (Ts)
        Console.WriteLine()
        Console.WriteLine(Ts_name & ": " & Ts_formula)
        If Ts_set = False Then
            ServiceTime()
        Else
            Console.WriteLine(Ts_name & " value is " & Ts_value & Ts_unit & ".")
        End If

        ' Arrival Time (Ra)
        Console.WriteLine()
        Console.WriteLine(Ra_name & ": " & Ra_formula)
        If Ra_set = False Then
            ArrivalTime()
        Else
            Console.WriteLine(Ra_name & " value is " & Ra_value & Ra_unit & ".")
        End If

        U_value = Math.Round(Ts_value / Ra_value * 100, 2)
    End Sub

    Public Sub ResponseTime()
        ' Service Time (Ts) / (1 – Utilization (U))

        ' Service Time (Ts)
        Console.WriteLine()
        Console.WriteLine(Ts_name & ": " & Ts_formula)
        If Ts_set = False Then
            ServiceTime()
        Else
            Console.WriteLine(Ts_name & " value is " & Ts_value & Ts_unit & ".")
        End If

        ' Utilization (U)
        Console.WriteLine()
        Console.WriteLine(U_name & ": " & U_formula)
        If U_set = False Then
            Utilization()
        Else
            Console.WriteLine(U_name & " value is " & U_value & U_unit & ".")
        End If
        
        R_value = Math.Round(Ts_value / (1 - (U_value / 100)), 2)
    End Sub

    Public Sub DiskCapacity()
        ' Application Disk Size Requirement (As) / Actual Disk Size (Ds)

        ' Application Disk Size Requirement (As)
        SetValue(As_set, As_value, As_name, As_unit)

        ' Actual Disk Size (Ds)
        SetValue(Ds_set, Ds_value, Ds_name, Ds_unit)

        Dc_value = Math.Round(As_value / Ds_value, 1)
    End Sub

    Public Sub DiskIOPS()
        ' Application IOPS Requirement (Ai) / (Actual Disk IOPS (Dai) * Maximum Disk Utilization (Du))

        ' Application IOPS Requirement (Ai)
        SetValue(Ai_set, Ai_value, Ai_name, Ai_unit)

        ' Actual Disk IOPS (Dai)
        SetValue(Dai_set, Dai_value, Dai_name, Dai_unit)

        ' Maximum Disk Utilization (Du)
        SetValue(Du_set, Du_value, Du_name, Du_unit)

        Di_value = Math.Round(Ai_value / (Dai_value * Du_value), 2)
    End Sub

    Public Sub DisksRequired()
        ' Max ( Disk Capacity (Dc) , Disk IOPS (Di) )

        ' Disk Capacity (Dc)
        Console.WriteLine()
        Console.WriteLine(Dc_name & ": " & Dc_formula)
        If Dc_set = False Then
            DiskCapacity()
        Else
            Console.WriteLine(Dc_name & " value is " & Dc_value & " " & Dc_unit & ".")
        End If

        ' Disk IOPS (Di)
        Console.WriteLine()
        Console.WriteLine(Di_name & ": " & Di_formula)
        If Di_set = False Then
            DiskIOPS()
        Else
            Console.WriteLine(Di_name & " value is " & Di_value & " " & Di_unit & ".")
        End If

        Dr_value = "Max( " & Dc_value & ", " & Di_value & " )"
    End Sub
End Class