Option Explicit

Dim objIEA

Set objIEA = CreateObject("InternetExplorer.Application")

objIEA.Navigate "www.imageil.com/newattendance/admin/AttendanceSchedular.aspx?img_id=10"

objIEA.visible = true

While objIEA.Busy

Wend

objIEA.Quit

Set objIEA = Nothing