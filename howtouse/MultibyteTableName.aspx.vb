Imports Gears
Imports DataSource

Partial Class howtouse_MultibyteTableName
    Inherits GearsPage

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        grvCustomer.PageIndex = 0 'ObjectDataSouceが走るので、DataBindのみでOK
        grvCustomer.DataBind()
    End Sub

    Protected Sub odsData_ObjectCreating(sender As Object, e As ObjectDataSourceEventArgs) Handles odsData.ObjectCreating
        e.ObjectInstance = New Customer(Master.ConnectionName)
    End Sub

    Protected Sub odsData_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles odsData.Selecting
        'GPackは、指定されたコントロールの値を収集してGearsDTOにまとめます。
        'ここでは、"data"に指定したこのDTOがSelectMethodに指定したgSelectPageByで引数として使用されます
        e.InputParameters("data") = GPack(pnlGFilter, grvCustomer)
    End Sub

End Class
