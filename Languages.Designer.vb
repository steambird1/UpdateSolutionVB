﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '此类是由 StronglyTypedResourceBuilder
    '类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    '若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    '(以 /str 作为命令选项)，或重新生成 VS 项目。
    '''<summary>
    '''  一个强类型的资源类，用于查找本地化的字符串等。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Languages
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  返回此类使用的缓存的 ResourceManager 实例。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("UpdateSolution.Languages", GetType(Languages).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  重写当前线程的 CurrentUICulture 属性
        '''  重写当前线程的 CurrentUICulture 属性。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  查找类似 Checking update... 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property CheckPrompt() As String
            Get
                Return ResourceManager.GetString("CheckPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Cannot update your application: 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property FailPrompt() As String
            Get
                Return ResourceManager.GetString("FailPrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Error 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property FailTitle() As String
            Get
                Return ResourceManager.GetString("FailTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Please wait until your applications are updated ... 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property UpdatePrompt() As String
            Get
                Return ResourceManager.GetString("UpdatePrompt", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Application Updater 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property UpdateTitle() As String
            Get
                Return ResourceManager.GetString("UpdateTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 Your application is up to date. 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property UpToDatePrompt() As String
            Get
                Return ResourceManager.GetString("UpToDatePrompt", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
